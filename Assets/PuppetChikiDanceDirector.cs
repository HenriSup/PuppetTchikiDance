using UnityEngine;
using System.Collections;

public class PuppetChikiDanceDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string[] JoystickInitialisation(int joystickNumber){
		string[] manette = new string[14] {"Xaxis", "Yaxis", "4thAxis","9thAxis", "10thAxis","R5thAxis","R6thAxis","7thAxis", "Button2", "Button0", "Button1", "Button3", "Button4", "Button5"};
		string padNumber = "J"+joystickNumber.ToString()+".";
	//	print (Input.GetJoystickNames () [joystickNumber - 1]);
		if (Input.GetJoystickNames().Length > 0) {
			string padname = Input.GetJoystickNames()[joystickNumber-1];
			if (padname == "Wireless Controller") {
				manette = new string[14] {"Xaxis", "Yaxis", "3rdAxis","4thAxis","5thAxis", "6thAxis","7thAxis","8thAxis", "Button0", "Button1", "Button2", "Button3", "Button4", "Button5"};
				//                           0       1         2           3       4           5         6         7          8         9 			10		  11		 12			 13    
				//                        LStickX  LStickY   RStickX      l2	   R2	    RStickY     DpadX    DpadY      Carré     Croix        Rond     Triangle     L1          R1
				// INVERTED? 				 0 		 0          0		   0        0		   0		  0        0  
				// Set					  [-1;1]    [-1;1]    [-1;1]    [-1;1]	  [-1;1]    [-1;1]     [-1;1]    [-1;1]
				//Default value				0 		  0			0		  -1		-1		   0         0          0	
			}
		}
		//else {manette = new string[14] {"Xaxis", "Yaxis", "4thAxis","9thAxis", "10thAxis","5thAxis","6thAxis","7thAxis", "Button0", "Button1", "Button2", "Button3", "Button4", "Button5"};}
		//Reflechir à une manière de gerer les gachettes ps4, peut etre (resultat+1)/2 ?
		//Reflechir à gerer le INVERTED Pour Xbox : DPADX et RStickY DONE !!!!
		for (int i=0; i<manette.Length; i++) {
			manette[i] = padNumber+manette[i];
		}
		
		return manette;
	}
}
