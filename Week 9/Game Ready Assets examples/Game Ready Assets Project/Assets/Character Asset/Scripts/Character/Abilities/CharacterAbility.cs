using UnityEngine;

/* CharacterAbility
 * an abstract class for creating character abilities like movement, jumping, shooting etc
 * this is the skeleton for an extandable system that hooks into the character component
 */
namespace com.game.characters
{
    // make sure we have a character component to use
    [RequireComponent(typeof(Character))]
    public abstract class CharacterAbility : MonoBehaviour
    {
        // any classes extending this class can use this protected character field
        protected Character character;
        
        // we create a virutal method from the start method to setup our character
        // since it is virutal, we can override in extending classes while still keeping this functionality
        protected virtual void Start()
        {
            // set character component for use in our ability classes!
            character = GetComponent<Character>();
        }
        
    }
}