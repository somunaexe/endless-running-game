using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogTextHints : MonoBehaviour {

    public TextMeshProUGUI textHints; //Text component of the text hints HUD element

	//Runs if the collider is intersected
    void OnTriggerEnter(Collider col) {
		//Runs if the colliders gameObject tag is "Player"
        if (col.gameObject.tag == "Player")
        {		
           textHints.text = "Jump with W to avoid the obstacle!"; //Set the text hint to be displayed
        }
    }
}
