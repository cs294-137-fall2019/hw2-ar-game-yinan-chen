using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARButton7 : MonoBehaviour, OnTouch3D
{
	public GameObject textBtn7;

	//button7 : position 6
	public void OnTouch(){
		Console.WriteLine("Enter Button 7 OnTouch"); 
		Console.WriteLine(GeneralControl.count); 

		//check if postion 6 alreayd filled color 
		if(GeneralControl.ifEmpty(6))
		{
			GeneralControl.count++;
			GeneralControl.mark[6] = GeneralControl.count % 2 == 0? "O" : "X";
			//text
			textBtn7 = GameObject.Find("/GameBoard/Button7/TextBtn7");
			textBtn7.GetComponent<TextMeshPro>().text = GeneralControl.mark[6];
			//color
			gameObject.GetComponent<Renderer>().material.color = GeneralControl.mark[6] == "X"? Color.red: Color.blue;

			//if #count >= 5, check if anyone wins 
			if(GeneralControl.count >= 5){
				if(checkWin())
				{
					//win => message shown 
					Color textcolor = GeneralControl.mark[6] == "X"? Color.red: Color.blue;
					GeneralControl.showMsg(GeneralControl.mark[6]+" Wins! ",textcolor);
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
		if((GeneralControl.mark[6] == GeneralControl.mark[7] && GeneralControl.mark[6] == GeneralControl.mark[8])||
			(GeneralControl.mark[6] == GeneralControl.mark[0] && GeneralControl.mark[6] == GeneralControl.mark[3])||
			(GeneralControl.mark[6] == GeneralControl.mark[4] && GeneralControl.mark[6] == GeneralControl.mark[2]))
			return true;
		else
			return false;	
	}   
}


