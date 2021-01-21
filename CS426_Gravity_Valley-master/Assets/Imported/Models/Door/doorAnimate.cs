using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimate : MonoBehaviour
{
    private Animator anim;
    AudioSource audioSource;
    private bool hasPlayed = false;

    void Start(){
        anim = transform.parent.gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            anim.SetBool("DoorOpen", true);
            if(!hasPlayed){
                if (!audioSource.isPlaying){audioSource.Play();}
                hasPlayed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            anim.SetBool("DoorOpen", false);
        }
    }
}
