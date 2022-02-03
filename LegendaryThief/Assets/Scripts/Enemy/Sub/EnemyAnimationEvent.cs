using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
      private PoliceBall policeBall;

      private void Start()
      {
            policeBall = GetComponentInParent<PoliceBall>();
      }


      public void ReadyToChase()
      {
            policeBall.ChaseStart();
      }
      public void EndToPatrol()
      {
            policeBall.StartPatrol();
      }
      public void ChaseToAttack()
      {
            policeBall.AttackAnimation();
      }
}
