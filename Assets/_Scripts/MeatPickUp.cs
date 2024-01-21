using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class MeatPickUp : MonoBehaviour
{
	public GameObject MeatPickUpSound; //Audio clip of meat being eaten
	public float rotationSpeed; //Rotation speed of the meat
	
	//Runs before the first frame
	void Start(){
		rotationSpeed = 100.0f; //Rotation speed is 100 Unity units
	}
	
	//Runs every frame
	void Update() {
		transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0)); //Meat rotates along the y-axis in the world space
	}

	//Runs if the collider is intersected
	void OnTriggerEnter(Collider col)
	{
		MeatPickUpSound.GetComponent<AudioSource>().Play(); //Plays the sound of meat being eaten
		MeatDisplay.meatCount++; //Increments the number of meat eaten by 1
		Destroy(gameObject); //Removes the meat game object from the scene
	}
}