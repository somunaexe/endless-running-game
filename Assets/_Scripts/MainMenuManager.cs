using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayScene()
    {
        SceneManager.LoadScene(1); //Load the running/game scene
    }

    public void Quit()
    {
        Application.Quit(); //Closes the whole gaming application
    }
}
