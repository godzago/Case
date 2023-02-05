using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    [SerializeField] UIManager u�manager;
    private int enemyTrigger;

    private void OnTriggerEnter(Collider other)
    {
         // Game over 
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            u�manager.FinishArea();
        }

        //  if all the enemies die 
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            enemyTrigger += 1;
            if (enemyTrigger == 3)
            {
                Time.timeScale = 0;
                u�manager.FinishArea();
            }
        }
    }
}
