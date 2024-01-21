using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    public GameObject liveCoins; //HUD element displaying coins collected
	public GameObject liveMeats; //HUD element displaying number of meat collected
    public GameObject liveDis; //HUD element displaying total distance ran
    public GameObject endScreen; //HUD element displaying total stats (number of coins and meats collected, total distance ran)
    public GameObject hints; //HUD element displaying hints for the next run
    public GameObject settingsButton; //HUD element displaying hints for the next run
    public GameObject fadeOut; //Fade out with animation to be played
    public TextMeshProUGUI endDis; //HUD element displaying distance in the total stats/end screen

	//Runs before the first frame
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(3); //Wait for 3 seconds
        transform.GetComponent<AudioSource>().enabled = false; //Disable the background music
        liveCoins.SetActive(false); //Disable the HUD element displaying the number of coins collected
		liveMeats.SetActive(false); //Disable the HUD element displaying the number of meats collected
        endDis.text = liveDis.transform.Find("Distance Count").GetComponent<TextMeshProUGUI>().text; //Display the total distance ran in the total stats screen
        liveDis.SetActive(false); //Disable the HUD element displaying the total distance ran
        settingsButton.SetActive(false); //Disable the settings button
        endScreen.SetActive(true); //Display the HUD element displaying the total stats
        hints.SetActive(true); //Display the HUD element displaying the hints for the next run
        yield return new WaitForSeconds(7); //Wait for 7 seconds
        fadeOut.SetActive(true); //Play the fade in animation
        yield return new WaitForSeconds(0.90f); //Wait for animation
        SceneManager.LoadScene(0); //Loads the main menu

    }
}
