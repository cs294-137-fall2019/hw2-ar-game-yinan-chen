using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARButton4 : MonoBehaviour, OnTouch3D
{
	public GameObject textBtn4;

	//button4 : position 3
	public void OnTouch(){
		Console.WriteLine("Enter Button 4 OnTouch"); 
		Console.WriteLine(GeneralControl.count); 

		//check if postion 3 alreayd filled color 
		if(GeneralControl.ifEmpty(3))
		{
			GeneralControl.count++;
			GeneralControl.mark[3] = GeneralControl.count % 2 == 0? "O" : "X";
			//text
			textBtn4 = GameObject.Find("/GameBoard/Button4/TextBtn4");
			textBtn4.GetComponent<TextMeshPro>().text = GeneralControl.mark[3];
			//color
			gameObject.GetComponent<Renderer>().material.color = GeneralControl.mark[3] == "X"? Color.red: Color.blue;

			//if #count >= 5, check if anyone wins 
			if(GeneralControl.count >= 5){
				if(checkWin())
				{
					//win => message shown 
					Color textcolor = GeneralControl.mark[3] == "X"? Color.red: Color.blue;
					GeneralControl.showMsg(GeneralControl.mark[3]+" Wins! ",textcolor);
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
		if((GeneralControl.mark[3] == GeneralControl.mark[4] && GeneralControl.mark[3] == GeneralControl.mark[5])||
			(GeneralControl.mark[3] == GeneralControl.mark[0] && GeneralControl.mark[3] == GeneralControl.mark[6]))
			return true;
		else
			return false;	
	} 
}


