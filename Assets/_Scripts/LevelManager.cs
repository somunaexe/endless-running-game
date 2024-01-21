using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{	
    public static bool isPaused = false; //Reflects whether the game is paused and is determined by the time scale
    public GameObject PauseMenu; //The pause/settings menu/screen that shows when the game is paused


	//Pauses the game
    public void Pause()
    {
        Time.timeScale = 0.0f; //Pauses the game by reducing the time scale to 0
        isPaused = true; //The game is paused
	}

	//Resumes the game
    public void Resume()
    {
		Time.timeScale = 1.0f; //Resumes the game by setting the time scale to 1
		isPaused = false; //The game is not paused
	}

	//Exits the game and opens the main menu
    public void ExitScene()
    {
        SceneManager.LoadScene(0); //Loads the main menu
    }
}
