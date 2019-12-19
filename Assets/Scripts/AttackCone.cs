using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    public BossAI boss;
    public bool isLeft = false;


    private void Awake()
    {
        boss = gameObject.GetComponentInParent<BossAI>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
                boss.Attack(false);

            else
                boss.Attack(true);


        }
    }
}
