/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerBeta : MonoBehaviour {

    public GameObject respawnPoint;
    public float speed = 10.0f;
    public float jumpHeight = 7f;
    private float translation;
    private float straffe;
    private bool isGrounded;
    private bool canMove;
    private Rigidbody rb;
    AudioSource audioSource;

    public AudioClip jumpSound;

    // Use this for initialization
    void Start () {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();	
        audioSource = GetComponent<AudioSource>();
        canMove = true;
        isGrounded = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(transform.position.y <= -15.0f){
            transform.position = respawnPoint.transform.position;
        }
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            if (!audioSource.isPlaying && isGrounded){audioSource.Play();}
        }

        checkGrounded();
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // jump
                audioSource.PlayOneShot(jumpSound);
            
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }

void checkGrounded(){
    RaycastHit hit;
    Debug.DrawRay (transform.position, Vector3.down * 1.3f, Color.red);
    Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f);
    Collider c = hit.collider;
    if(c != null && c.gameObject.tag == "Ground"){
        isGrounded = true;
    }
    else{
        isGrounded = false;
    }
}
/*
void OnCollisionEnter(Collision other)
{
    if (other.gameObject.tag == "Ground")
    {
        isGrounded = true;
    }
}
 
void OnCollisionExit(Collision other)
{
    if (other.gameObject.tag == "Ground")
    {
        isGrounded = false;
    }
} */

}
