using UnityEngine;

/* CharacterMoveAbility
 * an ability to make the character move
 * uses the characters character controller component to move
 */
namespace com.game.characters
{
    public class CharacterMoveAbility : CharacterAbility
    {
        // the character move speed 
        public float speed = 1;
        
        void Update()
        {
            // we create a direction from the character's input manager
            // input manager has a vector2 for movement called "Primary"
            // we are moving on the X-Z axis
            Vector3 direction = new Vector3
            {
                x = character.CharacterInput.Primary.x,
                y = 0,
                z = character.CharacterInput.Primary.y
            };

            // normalize the direction for smooth XZ values below 1
            direction.Normalize();

            // use the CharacterController's move method
            // NOTE: to use a nav agent, make a move method on the character class to use here instead of using the controller directly
            character.Controller.Move(direction * (Time.deltaTime * speed));
        }
    }
}