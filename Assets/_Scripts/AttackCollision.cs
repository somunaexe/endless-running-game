using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Collider))]

public class AttackCollision : MonoBehaviour
{
    public GameObject thePlayer; //The player object
    public GameObject charModel; //The character prefab
	public GameObject hitSound; //The sound played when the weapon collides with the enemy(bull)

	//Runs when the collider intersects
    void OnTriggerEnter(Collider col)
    {
		//Runs if the colliders gameObject tag is "Weapon"
        if(col.gameObject.tag == "Weapon")
        {
            hitSound.GetComponent<AudioSource>().Play(); //Play the attack sound
			
            Destroy(gameObject); //Remove the bull prefab from the scene

			Destroy(col.gameObject); //Remove the weapon from the scene

			gameObject.transform.parent.Find("Ham").gameObject.SetActive(true); // Enable the meat in the scene
        }
    }
}
