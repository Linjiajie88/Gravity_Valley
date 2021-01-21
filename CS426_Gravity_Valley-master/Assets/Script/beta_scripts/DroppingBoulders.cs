using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingBoulders : MonoBehaviour
{
    public GameObject boulder;
    public float targetTime = 5.0f;
    private float timer;
    float elapsed = 0f;

    void Start(){
        timer = targetTime;
    }
    // Update is called once per frame
    void Update()
    {
        float d = Time.deltaTime;

        timer -= d; //Elapse the timer
        elapsed += d; //Increment the elapse

        if(elapsed >= 1f){ //If we elapsed more or around a second, we alter gravity
            elapsed = elapsed % 1f;
        }

        if(timer <= 0){ //If the timer is equal to zero, reset gravity
            resetTimer();
            GameObject spawned = Instantiate(boulder, transform.position, Quaternion.identity);
            spawned.transform.GetComponent<Rigidbody>().AddForce(Vector3.down * 2500);
        }
    }

    void resetTimer(){
        timer = targetTime;
        elapsed = 0f;
    }
}
