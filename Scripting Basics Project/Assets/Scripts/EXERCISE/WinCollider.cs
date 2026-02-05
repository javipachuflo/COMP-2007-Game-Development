using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Win Collider
 * prints a win message and changes the material colour when an object collides
 * 
 */ 

public class WinCollider : MonoBehaviour
{

    public Rigidbody rb;
    public float jumpPower = 15f;

    // set a starting colour for our win collider
    public Color startColour = Color.green;

    // set a colour to change to when the player wins
    public Color winColour = Color.blue;

    // create a field to store a reference to the MeshRenderer component
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MeshRenderer.html
    private MeshRenderer meshRenderer;

    private void Start()
    {
        // [my comment] only need this if the rb is inside the object already.
        // rb = GetComponent<Rigidbody>();

        // use GetComponent to fill our "meshRenderer" field
        // NOTE: specify the type of the component in the angle backets <MeshRenderer>
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Component.GetComponent.html
        meshRenderer = GetComponent<MeshRenderer>();

        // change the material colour on our mesh renderer to the start colour fields value
        meshRenderer.material.color = startColour;
    }

    private void Jump()
    {
        Vector3 jumpForce = new Vector3(0, jumpPower, 0);
        rb.AddForce(jumpForce, ForceMode.Impulse);

    }

    // when something collides with us, print the win message and change the colour of the material on our mesh renderer
    private void OnCollisionEnter(Collision collision)
    {
        // print a win message to the console
        print("You Win!");

        // change the material colour on our mesh renderer to the win colour fields value
        meshRenderer.material.color = winColour;
        Jump();
    }
}
