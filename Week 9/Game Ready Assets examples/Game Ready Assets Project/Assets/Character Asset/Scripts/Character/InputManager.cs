using UnityEngine;

/* InputManager
 * gets standard and saves it to a vector2
 * the Primary property allows other components to easily access the current direction
 * 
 */
namespace com.game.characters
{
    public class InputManager : MonoBehaviour
    {
        // set our axis names from unity input
        public string horizontalAxis = "Horizontal";
        public string verticalAxis = "Vertical";

        // we can easily disable any input using this toggle form other components
        public bool inputEnabled = true;

        // the primary direction input property
        // used by the character and movement components
        public Vector2 Primary { get { return primaryAxes; } }

        // this is our raw input from the axes used in the update method
        protected Vector2 primaryAxes = Vector2.zero;



        void Update()
        {
            // only set input if it is enabled
            if (inputEnabled)
            {
                // set the x and y of our primary axes to unitys standard input
                // NOTE: we are using get axis raw here to we can control smoothing ourselves
                primaryAxes.x = Input.GetAxisRaw(horizontalAxis);
                primaryAxes.y = Input.GetAxisRaw(verticalAxis);
            }
        }
    }
}