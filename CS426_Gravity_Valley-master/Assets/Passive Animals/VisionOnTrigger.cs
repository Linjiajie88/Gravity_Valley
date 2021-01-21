using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionOnTrigger : MonoBehaviour
{
    public PassiveAnimalAi passiveAnimalAi;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            passiveAnimalAi.inVision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            passiveAnimalAi.inVision = false;
        }
    }
}
