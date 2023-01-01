using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyFollow[] enemies;

    private void Start()
    {
        enemies = GetComponentsInChildren<EnemyFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            Debug.Log("HumanIn");
            foreach (var enemy in enemies)
            {
                if(enemy != null)
                {
                    enemy.aggressive = true;
                    enemy.GetComponent<Animator>().SetBool("Run", true);
                }
                
            }
        }
    }
}
