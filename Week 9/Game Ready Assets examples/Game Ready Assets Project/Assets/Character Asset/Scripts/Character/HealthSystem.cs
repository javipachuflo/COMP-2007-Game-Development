using UnityEngine;
using UnityEngine.Events;

/* HealthSystem
 * handles a characters health
 * can be invincible for a short time using InvincibleMode
 * 
 * has 3 events:
 *  Take Damage
 *  Add Health
 *  Die
 */
namespace com.game.characters
{
    public class HealthSystem : MonoBehaviour
    {
        // initial health for the character
        // sets current health when component starts
        [SerializeField]
        private int initialHealth = 10;

        // maximum allowed health value
        [SerializeField]
        private int maxHealth = 10;


        // Take Damage event
        [HideInInspector]
        public UnityEvent onTakeDamage;

        // Add Health event
        [HideInInspector]
        public UnityEvent onAddHealth;

        // Die event
        [HideInInspector]
        public UnityEvent onDie;


        // the current health of the 
        [SerializeField]
        private int current = 0;

        // used in invincible mode
        private bool invincible = false;

        private void Start()
        {
            // set the current health to the initial value on start
            current = initialHealth;
        }

        // this method is used by other gameobjects to damage the character e.g. a bullet etc
        // other gameobjects can use SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver)
        public void TakeDamage(int damage)
        {
            // quit the method if we are invincible
            if (invincible) return;

            // quit the method if we are not recieving any damage
            if (damage < 1) return;
            
            // check if the damage is less than zero
            if (current - damage <= 0)
            {
                // set the damage to zero - so the value does not go below zero
                // this helps any UI etc to display health within a specific range
                current = 0;

                // our character is dead - run the die method '(
                Die();

                // quit this method so we dont adjust the health or send the take damage event
                return;
            }

            // apply the damage
            current -= damage;

            // send the on damaged event
            onTakeDamage.Invoke();
        }

        // here we add health to the character
        // technically, we can use the TakeDamage with a minus number
        // but its better to have a specific named method
        // also helps with testing
        public void AddHealth(int health)
        {
            // quit the method if we didn't get any health
            if (health <= 0) return;

            // check the health increase is greater than the max health
            if (current + health > maxHealth)
            {
                // set to max health only if the increase is more
                current = maxHealth;
            }
            else
            {
                // add the health to our current health
                current += maxHealth;
            }

            // send the add health event
            onAddHealth.Invoke();
        }


        // character has died
        // send the on die event here
        public void Die()
        {
            onDie.Invoke();
        }

        // if the player has been resurrected, we can reset the health here
        public void ResetHealth()
        {
            // reset health to max
            current = maxHealth;
        }

        // sets the character to invincible mode for a specified time (invincibleTime)
        // NOTE: you may want to setup an event here is you want fx to play ;)
        public void InvincibleMode(float invincibleTime)
        {
            // the invincible field will stop damage being applied in the Take Damage method
            invincible = true;

            // reset the mode after the time has run out using an Invoke
            Invoke(nameof(ResetInvincibleMode), invincibleTime);
        }

        // resets invincible mode
        void ResetInvincibleMode()
        {
            invincible = false;
        }
    }
}