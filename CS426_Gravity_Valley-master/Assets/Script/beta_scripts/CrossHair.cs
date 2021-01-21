//Attach this script to your Camera
//This draws a line in the Scene view going through a point 200 pixels from the lower-left corner of the screen
//To see this, enter Play Mode and switch to the Scene tab. Zoom into your Camera's position.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    Camera cam;
    public RectTransform crosshair;
    public RectTransform crosshairAlt;

    void Start()
    {
        cam = GetComponent<Camera>();
        crosshairAlt.GetComponent<Image>().gameObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(crosshair.position);
        //Debug.DrawRay(ray.origin, ray.direction * 2, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2)) {
            Collider c = hit.collider;
            if(c.gameObject.tag == "item"){
                crosshairAlt.GetComponent<Image>().gameObject.SetActive(true);
                crosshair.GetComponent<Image>().gameObject.SetActive(false);
                if (Input.GetMouseButtonDown(0)){
                    transform.parent.gameObject.GetComponent<Inventory>().addItem(c.gameObject);
                    c.gameObject.GetComponent<Pickup>().pickupObject();
                }
            }
            else if(c.gameObject.tag == "part"){
                crosshairAlt.GetComponent<Image>().gameObject.SetActive(true);
                crosshair.GetComponent<Image>().gameObject.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                {
                    transform.parent.gameObject.GetComponent<Goal>().ObtainPart();
                    transform.parent.gameObject.GetComponent<Inventory>().addItem(c.gameObject);
                    c.gameObject.GetComponent<Pickup>().pickupObject();
                }
            }
        }
        else if (Physics.Raycast(ray, out hit, 7)){
            Collider c = hit.collider;
            if(c.gameObject.tag == "enemy"){ //If it's an enemy, check if the gun is firing and switch crosshairs
                crosshairAlt.GetComponent<Image>().gameObject.SetActive(true);
                crosshair.GetComponent<Image>().gameObject.SetActive(false); //Switch crosshairs
                if (Input.GetMouseButtonDown(1)) //Check if the right mouse button is down
                {
                    c.gameObject.GetComponent<Rigidbody>().useGravity = false; //Turn off the enemy's gravity
                    c.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 9.81f, ForceMode.Impulse); //Launch them up in the air
                }
            }
        }
        // Do something with the object that was hit by the raycast.
        else{
                crosshairAlt.GetComponent<Image>().gameObject.SetActive(false);
                crosshair.GetComponent<Image>().gameObject.SetActive(true);
        }
    }
}