using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Collider))]

public class TidyWeapon : MonoBehaviour {

	//time to remove the weapon in seconds
    public float removeTime;

	// Runs before the first frame
	void Start () {
		removeTime = 3.0f;
        Destroy(gameObject, removeTime);
	}

}
