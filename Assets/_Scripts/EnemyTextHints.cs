using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyTextHints : MonoBehaviour {

    public TextMeshProUGUI textHints; //Text component of HUD element displaying the text hints

	//Runs if the collider is intersected
    void OnTriggerEnter(Collider col) {
		
		//Runs if the colliders gameObject tag is "Player"
		if (col.gameObject.tag == "Player")
        {
			textHints.text = "Press the enter key to attack the bull or move with A or D before it hits you!"; //Displays the specified text in the text component of the text hints HUD element
        }
    }
}
