using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceGameBoard : MonoBehaviour{
    public GameObject gameBoard;
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager; 
    private bool placed = false;

    // Start is called before the first frame update
    void Start(){
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update(){
        if(!placed){
        	if(Input.touchCount > 0){
        		Vector2 touchPosition = Input.GetTouch(0).position; 

        		List<ARRaycastHit> hits = new List<ARRaycastHit>();
        		if(raycastManager.Raycast(touchPosition,hits,TrackableType.PlaneWithinPolygon)){
        			var hitPose= hits[0].pose;
        			gameBoard.SetActive(true);
        			gameBoard.transform.position = hitPose.position;
                    Console.WriteLine(gameBoard.transform.position); 
                    gameBoard.transform.Translate(new Vector3(0.25f,-0.1f,0.25f));
                    Console.WriteLine(gameBoard.transform.position); 
        			placed = true;
        			planeManager.SetTrackablesActive(false);
        		} 
        	}
        }
        else{
        	planeManager.SetTrackablesActive(false);
        }
    }

    //if user place game board in an undesired location and would like to change     
    public void AllowMoveGameBoard(){
    	placed = false;
    	planeManager.SetTrackablesActive(true);

    }

    public bool Placed(){
    	return placed;
    }

}
