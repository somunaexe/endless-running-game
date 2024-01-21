using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countdown3; //Number 3 animation
    public GameObject countdown2; //Number 2 animation
    public GameObject countdown1; //Number 1 animation
    public GameObject countDownGo; //GO! animation
    public GameObject fadeIn; //Fade in animation
    public GameObject settings; //Settings button HUD element
    public AudioSource readyFX; //Ready sound
    public AudioSource goFX; //GO! sound

	//Runs before the first frame
    void Start()
    {
        StartCoroutine(CountSequence());
    }

	//Prevents the player from moving the character unless the countdown is finished
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f); //Wait for 1.5 seconds
        Destroy(fadeIn); //Remove the fade in object from the scene
        settings.SetActive(true); //Display the settings button
		
        countdown3.SetActive(true); //Display and play the 3 countdown animation
        readyFX.Play(); //Play the ready sound
        yield return new WaitForSeconds(1); //Wait for 1 second
        Destroy(countdown3); //Remove the 3 text object from the scene

        countdown2.SetActive(true); //Display and play the 2 countdown animation
        readyFX.Play(); //Plays the ready sound
        yield return new WaitForSeconds(1); //Wait for 1 second
        Destroy(countdown2); //Remove the 2 text object from the scene

        countdown1.SetActive(true); //Display and play the 1 countdown animation
        readyFX.Play(); //Play the ready sound
        yield return new WaitForSeconds(1); //Wait for 1 second
        Destroy(countdown1); //Remove the 1 text object from the scene

        countDownGo.SetActive(true); //Display and play the GO! animation
        goFX.Play(); //Play the GO! sound
        yield return new WaitForSeconds(1); //Wait for 1 second
        PlayerMove.canMove = true; //Player can move the character
        WeaponThrower.canThrow = true; //Player can throw weapons
        Destroy(countDownGo); //Remove the GO! text object
    }
}