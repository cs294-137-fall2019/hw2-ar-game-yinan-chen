using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetButton : MonoBehaviour
{
	public GameObject btn;
	public GameObject btn_text;

    public void resetGame(){
    	if(GeneralControl.finished)
    	{
            Console.WriteLine("Rest Game is enabled"); 
    		GeneralControl.count = 0;
    		GeneralControl.mark = new String[9];
    		GeneralControl.finished = false;
    		GeneralControl.hideMsg();
            clearBoard();
    	}
    }

    public void clearBoard(){
    	String path_btn = "/GameBoard/Button";
    	String path_text = "/TextBtn";

    	for(int i = 1; i <= 9; i++){
    		btn = GameObject.Find(path_btn+i);
    		btn_text = GameObject.Find(path_btn+i+path_text+i);
    		btn.GetComponent<Renderer>().material.color = Color.white;
    		btn_text.GetComponent<TextMeshPro>().text = "";
    	}
    }
}
