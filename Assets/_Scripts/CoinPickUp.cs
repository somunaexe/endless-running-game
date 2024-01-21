using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
	public GameObject coinPickUpSound; //Sound of coin being collected
	public float rotationSpeed; //Speed at which the coin rotates
	
	//Runs before the first frame 
	void Start(){
		rotationSpeed = 100.0f; //Coin rotation speed along the y-axis
	}
	
	//Runs every frame
	void Update()
	{
		transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime)); //Coin rotates at 100 unity units per deltaTime along the z-axis in local space but y-axis in the world space
	}

	//Runs when the collider is intersected
	void OnTriggerEnter(Collider col) {
		
		//Runs if the colliders gameObject tag is "Player"
		if(col.gameObject.tag == "Player")
        {
			coinPickUpSound.GetComponent<AudioSource>().Play(); //Plays sound of coin being picked up
			CoinDisplay.coinCount++; //Increments the number of coins collected by 1
			Destroy(gameObject); //Removes the coin from the scene
		}
	}
}
