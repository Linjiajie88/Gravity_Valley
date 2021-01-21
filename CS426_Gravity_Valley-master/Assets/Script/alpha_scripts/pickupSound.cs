using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSound : MonoBehaviour
{
    public AudioSource audioSource;
    private bool hasPlayed = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("item picked up " + gameObject.name);
            if (!hasPlayed)
            {
                if (!audioSource.isPlaying) { audioSource.Play(); }
                hasPlayed = true;
               
            }


        }

    }
}
