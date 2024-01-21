using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceCount : MonoBehaviour
{
    public static int distanceCount; //Distance ran by the character
    public GameObject distanceCountDisplay; //HUD element displaying the distance ran
    public bool addingDis; //Determines whether the distance will be added to
    public float gameSpeed; //The difficulty/speed of the game

	//Runs before the first frame
    void Start()
    {
		addingDis = false;
        gameSpeed = 1.0f; //Set the difficulty to 1.0f time scale
    }
	
	//Runs every frame
    void Update()
    {
		//Runs if the game is not paused
        if (!LevelManager.isPaused)
        {
            Time.timeScale = gameSpeed; //Set the time scale to the current difficulty
            if (!addingDis)
            {
                addingDis = true;
                StartCoroutine(AddingDis());
            }
        }
    }

	//Increments the distance ran every 0.35 seconds
    IEnumerator AddingDis()
    {
        distanceCount++; //Increments the distance ran
        distanceCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + distanceCount; //Displays the total distance ran
		yield return new WaitForSeconds(0.35f); //Wait for 0.35 seconds
        addingDis = false;

		//Increases the difficulty by 0.1 if the distance ran is a multiple of 50
        if(distanceCount % 50 == 0)
        {
            gameSpeed += 0.1f;
        }
    }
}