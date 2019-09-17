using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralControl : MonoBehaviour
{
    public static int count = 0;
    public static String[] mark = new String[9];
    public static bool finished = false;
    //textbox used for end message
    public static GameObject endMsg = GameObject.Find("/Canvas/AlertText");

    public static bool ifEmpty(int pos)
    {
        if(mark[pos] != "X" && mark[pos] != "O")
            return true;
        else 
            return false;    
    }

    public static void showMsg(String msg, Color textcolor)
    {
        //set endMsg if there is a result
		endMsg.GetComponent<Text>().text = msg;
		endMsg.GetComponent<Text>().color = textcolor;

    }

    public static void hideMsg()
    {
        //clear message area after reset
    	endMsg.GetComponent<Text>().text = "";
    }
}
