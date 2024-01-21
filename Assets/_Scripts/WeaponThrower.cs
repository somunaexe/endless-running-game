using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : MonoBehaviour {

    public GameObject throwSound; //Plays whenever the character throws an object
    public Rigidbody weaponPrefab; //Rigidbody of the weapon
    public float throwSpeed; //Speed at which the weapon travels
    public static bool canThrow; //Determines whether the character can throw a weapon

	//Runs before the first frame
    void Start()
    {
        throwSpeed = 30.0f; //Set the weapon speed to 30 unity units
		canThrow = false; //Character can not throw a weapon
    }
	
    // Update is called once per frame
    void Update () {
		
		//Runs if spacebar is pressed and the character can throw weapons
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return)) && canThrow)
        {
            StartCoroutine(ThrowWeapon());
        }
	}

	//Throws the weapon
    IEnumerator ThrowWeapon()
    {
        canThrow = false; //Prevents the player from throwing another weapon
        throwSound.GetComponent<AudioSource>().Play(); //Plays audio of weapon being thrown
        Rigidbody newWeapon = Instantiate(weaponPrefab, transform.position, transform.rotation) as Rigidbody; //Instantiates the weapon into the scene
        newWeapon.name = "weapon"; //Names the weapon
        newWeapon.velocity = transform.forward * throwSpeed; //Sets the weapons velocity and moves it in the direction being looked at
        //Physics.IgnoreCollision(transform.Find("Ch09_nonPBR@Standard Run").GetComponent<Collider>(), newWeapon.GetComponent<Collider>(), true); //Ignores the collision between the weapon and the character
        
		//Allows the player throw a weapon after 0.5 seconds
		yield return new WaitForSeconds(0.5f);
        canThrow = true;
    }
}
