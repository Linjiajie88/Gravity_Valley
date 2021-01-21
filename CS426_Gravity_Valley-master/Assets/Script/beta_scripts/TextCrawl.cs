using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextCrawl : MonoBehaviour
{
    public float scrollSpeed = 20;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 localVectorUp = transform.TransformDirection(0,1,0);
        pos+=localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position=pos;
        if(transform.position.y >= 350){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
