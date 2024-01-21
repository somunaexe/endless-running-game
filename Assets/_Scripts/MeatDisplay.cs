using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeatDisplay : MonoBehaviour
{
    public static int meatCount; //Number of meat collected
    public GameObject meatCountDisplay; //HUD element display number if meat collected

	//Runs every frame
    void Update()
    {
        meatCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + meatCount; //Reflects number of meat collected in the meat display HUD element
    }
}