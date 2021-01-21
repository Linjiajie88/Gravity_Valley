using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float turnSpeed = 6.0f;
    

    public float minTurnAngle = -70.0f;
    public float maxTurnAngle = 90.0f;
  
    private float mouseY; 
    private float mouseX;
    private float clampY = 0;
    public Transform playerBody;

    
    // Update is called once per frame
    void Update()
    {
        // mouse inputs
        mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        mouseY = Input.GetAxis("Mouse Y") * turnSpeed;
        
        clampY += mouseY;
        
        // prevent camera from rotating past certain point
        if(clampY > maxTurnAngle){
            clampY = maxTurnAngle;
            mouseY = 0f;
        }
        if(clampY < minTurnAngle){
            clampY = minTurnAngle;
            mouseY = 0f;
        }

        // rotate camera
        transform.Rotate(Vector3.left * mouseY);
                
        playerBody.Rotate(Vector3.up * mouseX);
       
       }
    
}
