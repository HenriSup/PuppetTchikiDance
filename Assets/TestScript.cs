using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {
	private string[] joystick;
	// Use this for initialization
	void Start () {
		joystick = JoystickInitialisation (1);

		//joystick = JoystickInitialisation (2);

		//print (Input.GetJoystickNames().Length);
	}
	
	// Update is called once per frame
	void Update () {
		float a = Input.GetAxis (joystick[0]);
		float b = Input.GetAxis (joystick[1]);
		float c = Input.GetAxis (joystick[2]);
		float d = Input.GetAxis (joystick[3]);
		float e = Input.GetAxis (joystick[4]);
		float f = Input.GetAxis (joystick[5]);
		float g = Input.GetAxis (joystick[6]);
		float h = Input.GetAxis (joystick[7]);
		float i = Input.GetAxis (joystick[8]);
		float j = Input.GetAxis (joystick[9]);
		print (a + " " + b + + c +" " + "0" + " " + d + " " + e + " " + f + " " + g + " " + h + " " + i + " " + j); 
	

	}



	string[] JoystickInitialisation(int joystickNumber){
		string[] manette = null;
		string padNumber = "J"+joystickNumber.ToString()+".";
		print (Input.GetJoystickNames () [joystickNumber - 1]);
		if (Input.GetJoystickNames().Length != 0) {
			string padname = Input.GetJoystickNames()[joystickNumber-1];
			if (padname == "Wireless Controller") {
				manette = new string[14] {"Xaxis", "Yaxis", "3rdAxis","4thAxis","5thAxis", "6thAxis","7thAxis","8thAxis", "Button0", "Button1", "Button2", "Button3", "Button4", "Button5"};
				//                           0       1         2           3       4           5         6         7          8         9 			10		  11		 12			 13    
				//                        LStickX  LStickY   RStickX      l2	   R2	    RStickY     DpadX    DpadY
				// INVERTED? 				 0 		 0          0		   0        0		   0		  0        0  
				// Set					  [-1;1]    [-1;1]    [-1;1]    [-1;1]	  [-1;1]    [-1;1]     [-1;1]    [-1;1]
				//Default value				0 		  0			0		  -1		-1		   0         0          0	
			}
			else {
				manette = new string[14] {"Xaxis", "Yaxis", "4thAxis","9thAxis", "10thAxis","5thAxis","6thAxis","7thAxis", "Button0", "Button1", "Button2", "Button3", "Button4", "Button5"};
				//                           0        1         2         3          4          5         6         7          8          9          10       
				//						  LStickX  LStickY    RStickX     LT         RT      RStickY    DpadX     DpadY                
				//INVERTED?                  0        0         0         0          1          1         1         0       
				//Set					  [-1;1]    [-1;1]   [-1;1]     [0;1]      [0;1]     [-1;1]    [-1;1]     [-1;1] 
				//Default value              0         0        0         0         0          0         0         0     
			}
		}
		else {manette = new string[14] {"Xaxis", "Yaxis", "4thAxis","9thAxis", "10thAxis","5thAxis","6thAxis","7thAxis", "Button0", "Button1", "Button2", "Button3", "Button4", "Button5"};}
		//Reflechir à une manière de gerer les gachettes ps4, peut etre (resultat+1)/2 ?
		for (int i=0; i<manette.Length; i++) {
			manette[i] = padNumber+manette[i];
		}
		
		return manette;
	}
}
