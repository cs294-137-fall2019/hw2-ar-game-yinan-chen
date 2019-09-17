using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARButton6 : MonoBehaviour, OnTouch3D
{
	public GameObject textBtn6;

	//button6 : position 5
	public void OnTouch(){
		Console.WriteLine("Enter Button 6 OnTouch"); 
		Console.WriteLine(GeneralControl.count); 

		//check if postion 5 alreayd filled color 
		if(GeneralControl.ifEmpty(5))
		{
			GeneralControl.count++;
			GeneralControl.mark[5] = GeneralControl.count % 2 == 0? "O" : "X";
			//text
			textBtn6 = GameObject.Find("/GameBoard/Button6/TextBtn6");
			textBtn6.GetComponent<TextMeshPro>().text = GeneralControl.mark[5];
			//color
			gameObject.GetComponent<Renderer>().material.color = GeneralControl.mark[5] == "X"? Color.red: Color.blue;

			//if #count >= 5, check if anyone wins 
			if(GeneralControl.count >= 5){
				if(checkWin())
				{
					//win => message shown 
					Color textcolor = GeneralControl.mark[5] == "X"? Color.red: Color.blue;
					GeneralControl.showMsg(GeneralControl.mark[5]+" Wins! ",textcolor);
					GeneralControl.finished = true;
				}
				else
				{	
					//no win & count = 9 => draw => message shown 
					if (GeneralControl.count == 9)
					{
						GeneralControl.showMsg("Cat's Game!",Color.black);
						GeneralControl.finished = true;
					}
					//no win & count < 9 => continue
				}
			}  
		}
		Console.WriteLine(GeneralControl.count); 
	}
	public bool checkWin(){
		if((GeneralControl.mark[5] == GeneralControl.mark[3] && GeneralControl.mark[5] == GeneralControl.mark[4])||
			(GeneralControl.mark[5] == GeneralControl.mark[2] && GeneralControl.mark[5] == GeneralControl.mark[8]))
			return true;
		else
			return false;	
	}  
}


