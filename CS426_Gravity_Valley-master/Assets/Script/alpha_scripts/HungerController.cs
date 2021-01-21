using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HungerController : MonoBehaviour
{
    private float maxHunger = 100;
    private float currentHunger = 0;
    private float losePoints = 0.001f;

    public Text hungerText;

    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        // lower hunger over time
        
        if(currentHunger > 0 ){
            currentHunger -= losePoints;
        }
            
        hungerText.text = "Hunger: " + currentHunger;
    }
}
