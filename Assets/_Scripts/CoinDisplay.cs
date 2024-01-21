using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public static int coinCount ; //The number of coins collected
    public GameObject coinCountDisplay; //The HUD element displaying the number of coins collected
	
	//Runs every frame
    void Update()
    {
        coinCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + coinCount; //Reflects number of coins collected in the coin display HUD element
    }
}