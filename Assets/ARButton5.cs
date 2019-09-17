using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARButton5 : MonoBehaviour, OnTouch3D
{
	public GameObject textBtn5;

	//button5 : position 4
	public void OnTouch(){
		Console.WriteLine("Enter Button 5 OnTouch"); 
		Console.WriteLine(GeneralControl.count); 

		//check if postion 4 alreayd filled color 
		if(GeneralControl.ifEmpty(4))
		{
			GeneralControl.count++;
			GeneralControl.mark[4] = GeneralControl.count % 2 == 0? "O" : "X";
			//text
			textBtn5 = GameObject.Find("/GameBoard/Button5/TextBtn5");
			textBtn5.GetComponent<TextMeshPro>().text = GeneralControl.mark[4];
			//color
			gameObject.GetComponent<Renderer>().material.color = GeneralControl.mark[4] == "X"? Color.red: Color.blue;

			//if #count >= 5, check if anyone wins 
			if(GeneralControl.count >= 5){
				if(checkWin())
				{
					//win => message shown 
					Color textcolor = GeneralControl.mark[4] == "X"? Color.red: Color.blue;
					GeneralControl.showMsg(GeneralControl.mark[4]+" Wins! ",textcolor);
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
		if((GeneralControl.mark[4] == GeneralControl.mark[1] && GeneralControl.mark[4] == GeneralControl.mark[7])||
			(GeneralControl.mark[4] == GeneralControl.mark[3] && GeneralControl.mark[4] == GeneralControl.mark[5])||
			(GeneralControl.mark[4] == GeneralControl.mark[0] && GeneralControl.mark[4] == GeneralControl.mark[8])||
			(GeneralControl.mark[4] == GeneralControl.mark[6] && GeneralControl.mark[4] == GeneralControl.mark[2]))
			return true;
		else
			return false;	
	}  
}


