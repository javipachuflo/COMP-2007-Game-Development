/* 
 * PlatformerPlayer
 *
 * public variables
 *  moveSpeed 
 *      speed of left and right movement speed of player character
 *      moveSpeed is a float, a type of decimal number
 *      higher values move the player faster
 *  
 *  jumpPower
 *      height of the jump for the player
 *      jumpPower is a float, a type of decimal number
 *      higher values jump the character higher
 *  
 *  
 * private variables
 *  body
 *      the Rigidbody2D component belonging to the character 
 *      body is a reference to the Rigidbody2D component on the player GameObject in the Unity Editor
 *      body is used for movement and jumping in the game
 *      link to online reference https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
 *      
 * canJump
 *      canJump stops the player from jumping in mid air by checking if the player is touching the floor or not
 *      canJump is a bool, which has 2 values true or false 
 *      if the player is touching a Floor, canJump will be set to true
 *      if the player is not touching a floor, canJump will be set to false
 *      
 * private methods     
 *  Start
 *      when the game begins, this method will run only once
 *      used to get the Rigidbody2D component from the GameObject this script is attached to
 *      the Rigidbody2D component is used to move the player later in the script
 *      link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
 *      
 * Update
 *      Runs constantly while the GameObject this script is attached to is in the game
 *      Update runs as fast as the computer will allow, often 30-60 times per second or much more
 *      link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
 *      
 *      
 * OnCollisionStay2D
 *      Runs constantly while the Collider2D on this GameObject is in contact with another Collider2D
 *      the player will be in constant contact with the floor while not jumping, we set canJump here to true
 *      link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionStay2D.html
 *      
 * OnCollisionExit2D
 *      Runs when the Collider2D on this GameObject stops contact with another Collider2D
 *      when the player jumps, its Collider2D will break contact with the floor, we set canJump to false here so the player cannot jump until contact with the flooar again
 *      link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
 *      
*/

using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    // speed of left and right movement of player character
    // adjust this value in the Unity Editor
    public float moveSpeed = 5;

    // height of the jump for the player
    // adjust this value in the Unity Editor
    public float jumpPower = 200;

    // the Rigidbody2D component belonging to the character 
    // we will set this value in the Start method
    // link to online reference https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
    private Rigidbody2D body;

    // canJump stops the player from jumping in mid air by checking if the player is touching the floor or not
    // this is set during gameplay
    private bool canJump = false;


    // when the game begins, this method will run only once
    // we get our Rigidbody2D component to move the player
    // link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
    private void Start()
    {
        // use GetComponent to look for a Rigidbody2D component on the GameObject in the Unity Editor
        // link to online reference https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html
        body = GetComponent<Rigidbody2D>();
    }


    // this method runs constantly while the GameObject this script is attached to is in the game
    // link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
    private void Update()
    {
        // we create a bool (true/false) variable to store if the jump button is currently pressed
        // link to online reference https://docs.unity3d.com/ScriptReference/Input.GetButtonDown.html
        bool jumpButtonDown = Input.GetButtonDown("Jump");

        // we create a bool (true/false) variable to store if the player is not moving up (jumping)
        // we check this to stop wall jumping hacks, it doesn't totally stop wall jumping - give it a try in the game!
        // if we take the body's "velocity", its up/down movement (which is the "y" part) we can check if it is moving up (a value more than zero)
        // if the body "velocity" is moving up we set this to false - the player is not falling or standing still
        bool playerIsFalling = body.velocity.y <= 0;

        // this "if" statement will determine if the player can jump
        // we use the "jumpButtonDown" and "playerIsFalling" variables created above as well as the "canJump" variable
        // note all 3 variables are "bool" (true/false) types
        // we use the "&&" operator (short for AND) to check if ALL values are true
        // the statement goes as follows:
        // IF "jumpButtonDown" is true AND "playerIsFalling" is true AND "canJump" is true
        // if all 3 are true we can run the code inside the IF statement
        if (jumpButtonDown && playerIsFalling && canJump)
        {
            // we create a "Vector2" variable here to store our jump amount
            // we will use this Vector2 to add a force to the player Rigidbody2D, making the player jump!
            // a Vector2 is a container for 2 variables, "x" and "y"
            // link to online reference https://docs.unity3d.com/ScriptReference/Vector2.html
            // we are insterested in setting the "y" to our variable "jumpPower"
            Vector2 jumpVector = new Vector2
            {
                // we set the "x" to zero, so no sideways movement will be added to our player
                x = 0,

                // we set the "y" to jumpPower so the player gets pushed up 
                y = jumpPower
            };

            // here we use the "AddForce" method on the body (Rigidbody2D) to push the player up
            // Addforce requires a Vector2 for the direction to move (in our case up)
            // optionally, Addforce can be given a "ForceMode2D" setting: "Impulse" for a hard shove or "Force" for a gentle push
            // we require a "Impulse" setting to give the body a hard shove upward - like a jump!
            // link to online reference https://docs.unity3d.com/ScriptReference/Rigidbody2D.AddForce.html
            body.AddForce(jumpVector, ForceMode2D.Impulse);
        }

        // we want to get our user input for left/right key presses
        // we also want to make sure the input is instant, so the player character left and right movement is instant and "snappy"
        // we can use "GetAxisRaw" to get instant keyboard input with no "smoothing" applied
        // link to online reference https://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        // we create a "Vector2" variable here to store our movement amount
        // we will use this Vector2 to add set the velocity (the move speed) of our Rigidbody2D
        // we might be jumping at the time of moving left or right, so we need to keep to upward velocity (upward move speed)
        // we can access our upward velocity using its "y" value
        Vector2 moveVector = new Vector2
        {
            // we will set the "x" of this Vector2 to the moveSpeed multiplied by our "horizontalInput" (left/right key press)
            // if no key is pressed, "x" is zero, if left is pressed "x" is -1, if right is pressed "x" is 1
            x = horizontalInput * moveSpeed,

            // here we get the current upward move speed of the Rigidbody2D "body.velocity.y" and apply it to our "y" value
            // this ensures we do not lose any momentum in our jump if moving in mid-air
            y = body.velocity.y
        };

        // here we set the velocity of the Rigidbody2D "body.velocity" to our "moveVector" variable created above
        // "body.velocity" is the exact move speed in the x and y direction
        // link to online reference https://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html
        body.velocity = moveVector;
    }

    // OnCollisionStay2D runs constantly while the Collider2D on this GameObject is in contact with another Collider2D
    // link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionStay2D.html
    private void OnCollisionStay2D(Collision2D collision)
    {
        // we will be touching the floor at this point, so we set canJump to true
        canJump = true;
    }

    // OnCollisionExit2D runs when the Collider2D on this GameObject stops contact with another Collider2D
    // link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
    private void OnCollisionExit2D(Collision2D collision)
    {
        // we will not be touching the floor at this point, so we set canJump to false
        canJump = false;
    }

}
