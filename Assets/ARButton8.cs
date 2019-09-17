using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARButton8 : MonoBehaviour, OnTouch3D
{
	public GameObject textBtn8;

	//button8 : position 7
	public void OnTouch(){
		Console.WriteLine("Enter Button 8 OnTouch"); 
		Console.WriteLine(GeneralControl.count); 

		//check if postion 7 alreayd filled color 
		if(GeneralControl.ifEmpty(7))
		{
			GeneralControl.count++;
			GeneralControl.mark[7] = GeneralControl.count % 2 == 0? "O" : "X";
			//text
			textBtn8 = GameObject.Find("/GameBoard/Button8/TextBtn8");
			textBtn8.GetComponent<TextMeshPro>().text = GeneralControl.mark[7];
			//color
			gameObject.GetComponent<Renderer>().material.color = GeneralControl.mark[7] == "X"? Color.red: Color.blue;

			//if #count >= 5, check if anyone wins 
			if(GeneralControl.count >= 5){
				if(checkWin())
				{
					//win => message shown 
					Color textcolor = GeneralControl.mark[7] == "X"? Color.red: Color.blue;
					GeneralControl.showMsg(GeneralControl.mark[7]+" Wins! ",textcolor);
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
		if((GeneralControl.mark[7] == GeneralControl.mark[1] && GeneralControl.mark[7] == GeneralControl.mark[4])||
			(GeneralControl.mark[7] == GeneralControl.mark[6] && GeneralControl.mark[7] == GeneralControl.mark[8]))
			return true;
		else
			return false;	
	}   
}


