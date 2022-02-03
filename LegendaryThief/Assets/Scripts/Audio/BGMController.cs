using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
      private GameObject mainCamera;
      private GameObject[] checker;
      private AudioSource audioSource;

      public AudioClip agit;
      public AudioClip title;
      public AudioClip tuto;

      private void Awake()
      {
            Debug.Log("BGMController Awake");
            checker = GameObject.FindGameObjectsWithTag("BGM");
            if(checker.Length >= 2)
            {
                  Debug.Log("BGM Destroy");
                  Destroy(this.gameObject);
            }
            DontDestroyOnLoad(transform.gameObject);
            audioSource = GetComponent<AudioSource>();
            mainCamera = Camera.main.gameObject;
      }

      private void FixedUpdate()
      {
            this.transform.position = Camera.main.transform.position;
      }

      public void ChangeAgitBGM()
      {
            audioSource.clip = agit;
            audioSource.Play();
      }
      public void ChangeTitleBGM()
      {
            audioSource.clip = title;
            audioSource.Play();
      }

      public void ChangeTutoBGM()
      {
            Debug.Log("clip : " + audioSource.clip);
            if (audioSource.clip == tuto && audioSource.isPlaying)
            {
                  Debug.Log("TuTo BGM Already playing");
            }
            else
            {
                  audioSource.clip = tuto;
                  audioSource.Play();
                  
               //   audioSource.
            }
      }
}
