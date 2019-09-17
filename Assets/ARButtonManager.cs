using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARButtonManager : MonoBehaviour
{
    private Camera arCamera;
    private PlaceGameBoard placeGameBoard;

    // Start is called before the first frame update
    void Start()
    {
    	//AR Session Origin Camera 
    	arCamera = GetComponent<ARSessionOrigin>().camera;
    	//get reference of game board 
    	placeGameBoard = GetComponent<PlaceGameBoard>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(placeGameBoard.Placed() && Input.touchCount > 0){ 
        	
            Vector2 touchPosition = Input.GetTouch(0).position;
        	//convert 2d position into a ray 
        	Ray ray = arCamera.ScreenPointToRay(touchPosition);
        	//check if this hits an object < 100m fo the user
        	RaycastHit hit; 

        	if(Physics.Raycast(ray,out hit,100)){
                //interactable object + game is not finished
                if(hit.transform.tag == "Interactable" && !GeneralControl.finished){
                    hit.transform.GetComponent<OnTouch3D>().OnTouch();
                }
        	}
        }
    }
}
