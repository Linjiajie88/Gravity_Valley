using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GravityControllerBeta : MonoBehaviour
{
    public float targetTime = 60.0f;
    public float playerGravity = -9.81f;
    private float timer;
    public Text timerText;
    public Text gravityText;
    public GameObject player;
    float elapsed = 0f;
    bool inSafeZone = false;
    public Image image_ui;

    void Start(){
        timer = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * playerGravity);
         
        /*
        //We don't want to push the player up too strongly
        if(playerGravity < 1.00f)
            playerGravity +=  0.0020f;

        timer -= Time.deltaTime;

        if(timer <= 0){
            timer = targetTime;
            playerGravity = -9.81f;
        } */

        //If the player is in a safe zone do not alter gravity
        if(!inSafeZone){

            //Check the change in time
            float d = Time.deltaTime;

            timer -= d; //Elapse the timer
            elapsed += d; //Increment the elapse

            if(elapsed >= 1f){ //If we elapsed more or around a second, we alter gravity
                elapsed = elapsed % 1f;
                image_ui.fillAmount -= 0.02222222f;
                if(playerGravity < 4.00f){ //Prevent the player from being propelled too strongly
                    playerGravity += 0.218f;
                }
                timerText.text = "Time: " + Mathf.Round(timer);
            }

            if(timer <= 0){ //If the timer is equal to zero, reset gravity
                resetTimer();
            }
        }

        //timerText.text = "Time: " + Mathf.Round(timer);
        gravityText.text = "Gravity: " + playerGravity;
    }

    private void resetTimer(){
        timer = targetTime;
        playerGravity = -9.81f;
        elapsed = 0f;
        image_ui.fillAmount = 1f;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Safezone"){
            inSafeZone = true;
            resetTimer();
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Safezone"){
            inSafeZone = false;
        }
    }

}