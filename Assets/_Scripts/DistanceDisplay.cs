using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    public static int distanceCount; //Distance ran in integers
    public GameObject canvas;
	
	//Runs every frame
    void Update()
    {
		//Runs if there is a gameObject with the name Distance Count
        if(canvas.transform.Find("Distance Count"))
        {
            canvas.transform.Find("Distance Count").GetComponent<TextMeshProUGUI>().text = "" + distanceCount; //Returns the distance ran
        }

    }
}
