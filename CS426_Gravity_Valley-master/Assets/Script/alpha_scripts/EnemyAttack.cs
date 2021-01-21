using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   
    public GameObject attackingFist;
 
    
    public void activateFist()
    {
        attackingFist.GetComponent<Collider>().enabled = true;
    }

    public void deactivateFist()
    {
        attackingFist.GetComponent<Collider>().enabled = true;
    }
}
