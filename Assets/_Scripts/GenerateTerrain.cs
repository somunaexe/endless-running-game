using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    public GameObject[] terrain; //ArrayList of sections/terrains
    public int zPos = 50; //Position of the end of the current section on the z-axis
    public bool creatingTerrain = false; //Determines whether another terrain/section can be added into the scene
    public int terrainNum; //List position of section/terrain to be added
	
	//Runs every frame
    void Update()
    {
        if (creatingTerrain == false)
        {
            creatingTerrain = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        terrainNum = Random.Range(0, 3);//Generate a random number from 0 to 2
        Instantiate(terrain[terrainNum], new Vector3(0, 0, zPos), Quaternion.identity); //Add a section/terrain at the end of the last terrain on the z-axis
        zPos += 50;//Increase the z-axis position to be spawned at by 50
        yield return new WaitForSeconds(3); //Wait for 3 seconds
        creatingTerrain = false;
    }
}
