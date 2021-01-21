using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject light;
    AudioSource audioSource;
    float timeElapsed;
    void Start()
    {
        light.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){ //Check if the right mouse button is down
            {
                light.SetActive(true);
                audioSource.Play();
                timeElapsed = Time.time;
            }
        }
        else{
            if(light.activeSelf)
                if((Time.time - timeElapsed) > 0.1f)
                    light.SetActive(false);
        }
    }
}
