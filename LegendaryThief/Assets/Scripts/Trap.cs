using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
      Stage01 stage;
      // Start is called before the first frame update
      void Start()
      {
            stage = FindObjectOfType<Stage01>();
      }

      // Update is called once per frame
      void Update()
      {

      }

      private void OnTriggerStay2D(Collider2D collision)
      {
            if(collision.tag == "GroundSensor")
            {
                  CharacterBase characterBase = collision.GetComponentInParent<CharacterBase>();
                  if (characterBase.isGrounded == true)
                  {
                        if (characterBase.isInvinsible == false)
                        {
                              characterBase.OnDamage(1, transform.position);  // 캐릭터 데미지 주고.
                                                                              // 시작지점으로 보낸다.
                             // stage.CharacterDameged();
                        }
                  }
            }
      }
      private void OnCollisionEnter2D(Collision2D collision)
      {
            if (collision.gameObject.tag == "GroundSensor")
            {
                  CharacterBase characterBase = collision.gameObject.GetComponentInParent<CharacterBase>();
                  if (characterBase.isInvinsible == false)
                  {
                        characterBase.OnDamage(1, transform.position);  // 캐릭터 데미지 주고.
                        // 시작지점으로 보낸다.
                        //stage.CharacterDameged();
                  }
            }
      }
}
