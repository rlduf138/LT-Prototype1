using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage01 : MonoBehaviour
{
      public Transform startPos;
      CharacterBase characterBase;
      public GameObject startParticle;
      public MissionObject warp;

      public List<EnemyBase> enemyList;

      [Header("Audio")]
      private BGMController bgmController;
      public GameObject bgmPrefab;
      public GameObject menuPrefab;
      public AudioMixerSlider audiomixer;

      void Awake()
      {
            Debug.Log("Stage0101 Awake");
            characterBase = FindObjectOfType<CharacterBase>();
          
            bgmController = FindObjectOfType<BGMController>();
            if (bgmController == null)
            {
                  GameObject obj;
                  obj = Instantiate(bgmPrefab);
                  bgmController = obj.GetComponent<BGMController>();
            }
            audiomixer = FindObjectOfType<AudioMixerSlider>();
            if(audiomixer == null)
            {
                  GameObject obj;
                  obj = Instantiate(menuPrefab);
                  audiomixer = obj.GetComponent<AudioMixerSlider>();
            }
            FadeController.Instance.OpenScene(Active);

      }

      private void Start()
      {
            Debug.Log("Stage0101 Start");
            bgmController = FindObjectOfType<BGMController>();
            bgmController.ChangeTutoBGM();
            characterBase.OffSprite();
            characterBase.transform.position = startPos.position;

            warp.SetWarp(NextScene);
      }

      protected void Active()
      {
            StartCoroutine(StartParticle());
      }
      protected IEnumerator StartParticle()
      {
            characterBase.isTuto = true;

            GameObject particle = Instantiate(startParticle, characterBase.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);

            characterBase.isTuto = false;
            characterBase.OnSprite();

            yield return new WaitForSeconds(0.3f);

            Destroy(particle);
      }

      public void CharacterDameged()
      {
            FadeController.Instance.FadeIn(ResetPosition);
      }
      private void ResetPosition()
      {
            characterBase.transform.position = startPos.position;
            for(int i = 0; i<enemyList.Count; i++)
            {
                  enemyList[i].ResetPosition();       // 적들 원래 포지션으로.
            }
            FadeController.Instance.OpenScene(ResetPosition02);
            
      }
      private void ResetPosition02()
      {
           
       //     characterBase.isTuto = false;
      }

      void Update()
      {

      }

      public void NextScene()
      {
            FadeController.Instance.FadeIn(ActiveNextScene);
      }
      private void ActiveNextScene()
      {
            //UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Tutorial");
            UnityEngine.SceneManagement.SceneManager
                  .LoadSceneAsync(StageOrder.Instance.stageOrder[StageOrder.Instance.currendOrder++]);
      }
}
