using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARButton2 : MonoBehaviour, OnTouch3D
{
	public GameObject textBtn2;

	//button2 : position 1
	public void OnTouch(){
		Console.WriteLine("Enter Button 2 OnTouch"); 
		Console.WriteLine(GeneralControl.count); 

		//check if postion 1 alreayd filled color 
		if(GeneralControl.ifEmpty(1))
		{
			GeneralControl.count++;
			GeneralControl.mark[1] = GeneralControl.count % 2 == 0? "O" : "X";
			//text
			textBtn2 = GameObject.Find("/GameBoard/Button2/TextBtn2");
			textBtn2.GetComponent<TextMeshPro>().text = GeneralControl.mark[1];
			//color
			gameObject.GetComponent<Renderer>().material.color = GeneralControl.mark[1] == "X"? Color.red: Color.blue;

			//if #count >= 5, check if anyone wins 
			if(GeneralControl.count >= 5){
				if(checkWin())
				{
					//win => message shown 
					Color textcolor = GeneralControl.mark[1] == "X"? Color.red: Color.blue;
					GeneralControl.showMsg(GeneralControl.mark[1]+" Wins! ",textcolor);
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
		if((GeneralControl.mark[1] == GeneralControl.mark[0] && GeneralControl.mark[1] == GeneralControl.mark[2])||
			(GeneralControl.mark[1] == GeneralControl.mark[4] && GeneralControl.mark[1] == GeneralControl.mark[7]))
			return true;
		else
			return false;	
	}
}


