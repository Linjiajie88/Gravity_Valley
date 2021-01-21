using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pickupSound;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!audioSource.isPlaying && hasPlayed)
        {

            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            print("item picked up " + gameObject.name);


            audioSource.Play();
            hasPlayed = true;
            if (!audioSource.isPlaying && hasPlayed)
            {

                Destroy(gameObject);
            }
            //Destroy(gameObject);   
        }

    }

    public void pickupObject(){
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            hasPlayed = true;
            Destroy(gameObject);
            //Destroy(gameObject);  
    }
}
