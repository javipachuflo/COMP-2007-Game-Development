using UnityEngine;

/* Character
 * central place for setting up a character
 * controls the animator, input, health and abilities
 * requires a CharacterController and Rigidbody
 */
namespace com.game.characters
{
    // an enum for setting the charcter type
    // setting as play will allow input to control movement
    public enum CharacterType {
        Player,
        AI
    }

    [SelectionBase]
    [RequireComponent(typeof(CharacterController), typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [Header("Default settings")]
        // set the character type here, default is player
        [SerializeField] private CharacterType characterType = CharacterType.Player;

        // store the animator here
        // the animator component is often on a different GameObject, eg downloaded from mixamo etc
        [SerializeField] private Animator characterAnimator;

        // the following are sets of transforms that contain FX like particles etc
        // the character will activate the transforms for a short time 
        [Header("FX Feedback modules")]
        // activates when taking damage
        [SerializeField] private Transform damagedFX;
        [SerializeField] private float damagedTime = 1;

        // activate when buffing health
        [SerializeField] private Transform buffedFX;
        [SerializeField] private float buffTime = 1;

        // activated when character dies
        [SerializeField] private Transform dieFX;
        [SerializeField] private float dieTime = 1;

        // a getter is used to access the input manager from other components
        // used by the move ability component to get directional input
        public InputManager CharacterInput { get { return inputManager; } }

        // a standard CharacterController is used for these characters
        // if you prefer to use a nav mesh agent, create a separate character class
        protected CharacterController controller;

        public CharacterController Controller { get { return controller; } }

        // the rigibody is used for interaction with other transforms (pickups, bullets etc)
        // by default this is kinematic and movement is handled elsewhere
        protected Rigidbody body;

        // the health system component sends events when health changes or the character dies
        // we will connect to these events for our FX transforms to trigger 
        protected HealthSystem health;

        // the input manager send input from the keyboard and be easily toggled
        protected InputManager inputManager;
        
        // the animator setup has a "Speed" setting for the movement blend tree
        // we will trigger the correct animations from the update method using the input manager
        protected const string moveSpeedAnimationName = "Speed";

        // the calculated speed of the input manager
        // used to set the "Speed" parameter in the animator
        private float processedSpeed;

        private void Start()
        {
            // get references to the CharacterController and Rigidbody components
            controller = GetComponent<CharacterController>();
            body = GetComponent<Rigidbody>();

            // we check whether the character is player controlled or AI
            if (characterType == CharacterType.Player) // Player
            {
                // get the input manager for the player
                inputManager = GetComponent<InputManager>();
                if (inputManager == null)
                {
                    // if no input manager is found, send a warning message to the console
                    Debug.LogWarning("Attach an input manager to the character if it is player controlled");
                }
            }
            else if(characterType == CharacterType.AI) // AI
            {
                // insert AI behaviour code here ;)
            }


            // deactivate all fx transforms
            if (damagedFX != null)
            {
                damagedFX.gameObject.SetActive(false);
            }

            if (buffedFX != null)
            {
                buffedFX.gameObject.SetActive(false);
            }

            if (dieFX != null)
            {
                dieFX.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            // here we process input and send to the animator component
            if (characterAnimator != null && inputManager != null)
            {
                // to get a speed value between 0 and 1, we clamp the value from the input manager
                // the input manager sends a vector2 called "Primary", - we clamp the magnitude of it for our speed
                processedSpeed = Mathf.Clamp(inputManager.Primary.magnitude, 0, 1);

                // set the "Speed" parameter of the animator using the processed speed
                characterAnimator.SetFloat("Speed", processedSpeed);
            }
        }

        // FX triggered when the health system takes damage
        private void OnDamagedFX()
        {
            // if we have dmamage FX
            if (damagedFX != null)
            {
                // activate the damage fx
                damagedFX.gameObject.SetActive(true);

                // use an invoke to deactivate the fx after a short time
                Invoke(nameof(ResetDamagedFX), damagedTime);
            }
        }

        // reset method for the invoke from OnDamageFX 
        private void ResetDamagedFX()
        {
            // deactivate the damage fx gameobject
            damagedFX.gameObject.SetActive(false);
        }

        // FX triggered when the health system add health
        private void OnAddHealthFX()
        {
            // if we have a health fx
            if (buffedFX != null)
            {
                // activate the buff fx
                buffedFX.gameObject.SetActive(true);

                // use an invoke to deactivate fx after a short time
                Invoke(nameof(ResetBuffedFX), buffTime);
            }
        }

        // reset method for the invoke from OnAddHealthFX
        private void ResetBuffedFX()
        {
            // deactivate the buff fx gameobject
            buffedFX.gameObject.SetActive(false);
        }

        // FX triggered when the character dies
        private void OnDieFX()
        {
            // if we have a die fx
            if (dieFX != null)
            {
                // activate the die fx
                dieFX.gameObject.SetActive(true);
            }

            // disable character controller to stop movement and collisions
            controller.enabled = false;

            // use an invoke to deactivate fx after a short time
            Invoke(nameof(Die), dieTime);
        }

        // final method for a character's death
        // after the die fx has finished, we turn off the gameobject
        // #cue funeral march music#
        private void Die()
        {
            // if we have a die fx
            if (dieFX != null)
            {
                // deactivate the die fx
                dieFX.gameObject.SetActive(false);
            }

            // turn off this gameobject
            // ## WARNING! will turn off ALL components on the player! ## 
            gameObject.SetActive(false);
        }

        // we setup the health component's events when the gameobject enables
        // there are 3 events: take damage, add health, on die
        private void OnEnable()
        {
            // store the health component
            health = GetComponent<HealthSystem>();

            // if we have a health component
            if (health != null)
            {
                // connect the take damage event to OnDamageFX
                health.onTakeDamage.AddListener(OnDamagedFX);

                // connect the add health event to OnAddHealthFX
                health.onAddHealth.AddListener(OnAddHealthFX);

                // connect the die event to OnDieFX
                health.onDie.AddListener(OnDieFX);
            }
        }

        // we disconnect the health component's events when the gameobject disables
        // there are 3 events: take damage, add health, on die
        private void OnDisable()
        {
            // if we have a health component
            if (health != null)
            {
                // disconnect the take damage event to OnDamageFX
                health.onTakeDamage.RemoveListener(OnDamagedFX);

                // disconnect the add health event to OnAddHealthFX
                health.onAddHealth.RemoveListener(OnAddHealthFX);

                // disconnect the die event to OnDieFX
                health.onDie.RemoveListener(OnDieFX);
            }
        }
    }
}