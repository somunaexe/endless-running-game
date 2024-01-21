using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName; //Name of the section gameObject

	//Runs before the first frame
    void Start()
    {
        parentName = transform.name; //Return the name of the section gameObject
    }

	//Runs if the collider is intersected
	void OnTriggerEnter(Collider col) {
		
		//Runs if the colliders gameObject tag is "Player"
		if (col.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyClone());
        }
	}
	
    IEnumerator DestroyClone()
    {
		Debug.Log("deletion pending");
		
        yield return new WaitForSeconds(15); //Wait for 15 seconds
		
		//Runs if the name of the section gameObject is "Section(Clone)" or "Section 1")
        if (parentName == "Section(Clone)" || parentName == "Section 1")
        {
            Destroy(gameObject); //Remove the section gameObject from the scene
        }
    }
}
