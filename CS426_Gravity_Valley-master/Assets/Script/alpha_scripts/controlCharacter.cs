using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCharacter : MonoBehaviour
{
    public float force = 700f;
    public float speed = 3f;
    Rigidbody rb;
    Transform t;

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * speed;
        var z = Input.GetAxis("Vertical")*speed;
     
        Vector3 foward = transform.forward * z;
        Vector3 right = transform.right * x;

        characterController.SimpleMove(foward+right);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(t.up * force);   
    }
}
