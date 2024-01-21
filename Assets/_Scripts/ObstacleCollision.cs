using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer; //The character parent game object
    public GameObject charModel; //The character prefab
    public GameObject mainCam; //The characters main camera
    public GameObject collisionSound; //The object pointing to the audio of the character and obstacle colliding

    public Behaviour endRunScript; //Displays the total stats (number of coins and meat collected, total distance ran)
    public Behaviour distanceCounterScript;	//Calculates the total distance ran
    public Behaviour generateTerrain; //Generates terrains

	//Runs when the collider has been intersected
    void OnTriggerEnter(Collider col)
    {
		//Runs if intersected by the character
        if(col.gameObject.tag == "Player")
        {
            Time.timeScale = 1.0f;
            gameObject.GetComponent<Collider>().enabled = false; //Deactivates the collider to prevent calling this method multiple times
            thePlayer.GetComponent<PlayerMove>().enabled = false; //Stops the character from being able to move
			distanceCounterScript.enabled = false; //Stops the distance ran from being added to
			WeaponThrower.canThrow = false; //Prevents the character from throwing weapons
			
            mainCam.GetComponent<Animation>().Play(); //Shakes the camera for visual effects
            charModel.GetComponent<Animator>().SetBool("isHit", true); //Plays the animation of the character falling down
            collisionSound.GetComponent<AudioSource>().Play(); //Plays the audio of the character and obstacle colliding
			
            endRunScript.enabled = true; //Brings up the total stats screen
            generateTerrain.enabled = false; //Stops more terrains from being generated
        }
    }
}
