using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObstacleTextHints : MonoBehaviour {

    public TextMeshProUGUI textHints; //Text component of HUD element displaying hints for the next run

	//Runs if the collider is intersected
    void OnTriggerEnter(Collider col) {
		
		//Runs if the colliders game object tag is "Player"
        if (col.gameObject.tag == "Player")
        {		
            textHints.text = "Move with A or D to avoid the obstacle!"; //Sets the hint displayed in the text hint HUD element for the next run
        }
    }
}
