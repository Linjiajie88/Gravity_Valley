using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private bool inventoryEnabled;
    private int allSlots;
    private int slotCounter = 0;
    private GameObject[] slots;
    public Sprite temp;
    public Sprite partIcon;
    public GameObject slotHolder;
    private SimpleSmoothMouseLook playerLook;
    private CharacterControllerBeta playerMove;
    private GameObject mainCam;

    AudioSource audioSource;
    public AudioClip invOpen;
    public AudioClip invClose;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        playerMove = GetComponent<CharacterControllerBeta>();
        mainCam = GameObject.Find("Main Camera");
        playerLook = mainCam.GetComponent<SimpleSmoothMouseLook>();

        allSlots = 20;
        slots = new GameObject[allSlots];
        for(int i = 0; i < allSlots; i++){
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            inventoryEnabled = !inventoryEnabled;
            if(inventoryEnabled){
                audioSource.PlayOneShot(invOpen);
            }
            else{
                audioSource.PlayOneShot(invClose);
            }
        }
        
        if(inventoryEnabled == true){
            inventory.SetActive(true);
            playerLook.enabled = false;
            playerMove.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else{
            inventory.SetActive(false);
            playerLook.enabled = true;
            playerMove.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void addItem(GameObject obj){
        if(slotCounter < allSlots && obj.tag == "item"){
           slots[slotCounter].gameObject.GetComponent<Image>().sprite = temp;
           slotCounter++;
        }
        else if(slotCounter < allSlots && obj.tag == "part"){
           slots[slotCounter].gameObject.GetComponent<Image>().sprite = partIcon;
           slotCounter++;
        }
    }
}
