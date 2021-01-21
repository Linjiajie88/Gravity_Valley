using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float targetTime = 60.0f;
    private float timer;
    public Text timerText;
    public Text gravityText;

    void Start(){
        timer = targetTime;
    }
    // Update is called once per frame
    void Update()
    {
        Physics.gravity += new Vector3(0, 0.0010f, 0);
        timer -= Time.deltaTime;
        if(timer <= 0){
            timer = targetTime;
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
        timerText.text = "Time: " + Mathf.Round(timer);
        gravityText.text = "Gravity: " + Physics.gravity.y;
    }
}
