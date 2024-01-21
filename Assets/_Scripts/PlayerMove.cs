using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	
    public GameObject character; //The character prefab
    public Animator animator; //The animator component attached to the character prefab
	
    public static float leftSide; //The lowest position the character can go on the x-axis
    public static float rightSide; //The highest position the character can go on the x-axis
	
    public float forwardSpeed; //The forward speed of the character
    public float moveSpeed; //The left/right speed of the character
    public float jumpSpeed; //The jump speed of the character
	
    public static bool canMove; //Determines when the character can move left/right
    public bool comingDown; //Determines when the character is falling down after a jump animation

    //Runs before the first frame
    void Start()
    {
		animator = character.GetComponent<Animator>(); //Returns the characters animator component and points to it/stores it

        //Initializes the values
        leftSide = -3.9f;
		rightSide = 2.8f;
		forwardSpeed = 9;
		moveSpeed = 7;
        jumpSpeed = 5;
		
		//Sets the variables to false
		canMove = false;
		comingDown = false;
    }

	//Runs every frame
    void Update()
    {
		//Moves the player forward at a speed of 9 Unity units per deltaTime
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);
		
		//Runs if the player can move
        if (canMove)
        {
			//Runs if the player presses A or left arrow key to move left
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && this.gameObject.transform.position.x > leftSide)
            {
                Debug.Log("left");
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed); //Moves the character to the left
            }
			
			//Runs if the player presses D or right arrow key to move right
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && this.gameObject.transform.position.x < rightSide)
            {
				Debug.Log("right"); 
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * 1); //Moves the character to the right
            }
			
			//Runs if the player presses W or up arrow key to move up
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !animator.GetBool("isJumping"))
            {
                animator.SetBool("isJumping", true); //Plays the jump animation on the character
                StartCoroutine(JumpSequence()); //Starts the jump coroutine
            }

			//Runs if the jump animation is playing and has not reached its peak height
            if(animator.GetBool("isJumping") && !comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed, Space.World); //Move the player upwards
            }
			
			//Runs if the idle jumping is playing
            if (animator.GetBool("isJumping") && comingDown)
            {
				transform.Translate(Vector3.down * Time.deltaTime * jumpSpeed, Space.World); //Move the player downwards
            }

            if (!animator.GetBool("isJumping") && gameObject.transform.position.y > 0.6)
            {
                transform.Translate(Vector3.down * Time.deltaTime * jumpSpeed, Space.World); //Move the player downwards
                Debug.Log("brought down");
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.65f); //Wait for 0.65 seconds

        comingDown = true; //Makes the character go down
        animator.SetBool("isJumpingIdle", true); //Start the isJumpingIdle animation
		
        yield return new WaitForSeconds(0.65f); //Wait for 0.65 seconds
        animator.SetBool("isJumping", false); //Stops the jumping animation
        comingDown = false; //Stops the character from moving below the terrain
        animator.SetBool("isJumpingIdle", false); //Stops the jumping idle animation and starts the running animation
    }
}
