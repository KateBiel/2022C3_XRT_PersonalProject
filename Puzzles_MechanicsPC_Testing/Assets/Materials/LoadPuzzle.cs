using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzle : MonoBehaviour
{
    //public GameObject currentTask;
    public GameObject canvasPressButton;
    public GameObject canvasPuzzle;

    private bool pressed = false;

    private ThirdPersonMovement charecterMovement; 




    // Start is called before the first frame update
    void Start()
    {
        canvasPressButton.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyPressed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvasPressButton.SetActive(true);
            KeyPressed();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasPressButton.SetActive(false);
            
        }

    
    }

    void KeyPressed()
    {
        charecterMovement = FindObjectOfType<ThirdPersonMovement>();

        if (Input.GetKeyDown(KeyCode.E) && pressed == false) 
        {
          
            Debug.Log("E pressed OPEN CANWAS");
            canvasPressButton.SetActive(false);
            canvasPuzzle.SetActive(true);
            charecterMovement.enabled = false; 

            
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            canvasPuzzle.SetActive(false);
            charecterMovement.enabled = true;
            Debug.Log("Q pressed CLOSE CANWAS");
        }
    }
}
