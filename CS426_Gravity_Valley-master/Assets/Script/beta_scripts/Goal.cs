using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// takes care of number of parts and win condition
public class Goal : MonoBehaviour
{
    private static int totalParts = 5;
    private int numParts;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        numParts = 0;   
    }

    // Update is called once per frame
    
    // call in CrossHare click 
    // get required number and win
    public void ObtainPart()
    {
        Debug.Log("Click");
        numParts++;
        if(numParts == totalParts)
        {
            // win
            Debug.Log("win");
        }
    }
}
