using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockTextHints : MonoBehaviour
{

    public TextMeshProUGUI textHints; //HUD element displaying hints for the next run

	//Runs if the collider is intersected
    void OnTriggerEnter(Collider col)
    {
		//Runs if the colliders game object tag is "Player"
        if (col.gameObject.tag == "Player")
        {
            textHints.text = "Move with A or D or Jump with W to avoid the obstacle!"; //Sets the hint being displayed in the text hints HUD elements
        }
    }
}
