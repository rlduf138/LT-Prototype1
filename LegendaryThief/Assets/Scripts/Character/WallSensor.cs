using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
      private CharacterBase characterBase;

      void Start()
      {
            characterBase = GetComponentInParent<CharacterBase>();
      }

      void Update()
      {

      }

      private void OnTriggerEnter2D(Collider2D collision)
      {
            // 벽에 닿으면
            if(collision.tag == "Ground")
            {
                  if(characterBase.chSprite.gameObject.transform.localScale.x == -1)
                  {
                        characterBase.isLeftWall = true;
                  }else if(characterBase.chSprite.gameObject.transform.localScale.x == 1)
                  {
                        characterBase.isRightWall = true;
                  }
            }
      }
      private void OnTriggerExit2D(Collider2D collision)
      {
            // 벽에서 나오면
            if(collision.tag == "Ground")
            {
                  characterBase.isLeftWall = false;
                  characterBase.isRightWall = false;
            }
      }
}
