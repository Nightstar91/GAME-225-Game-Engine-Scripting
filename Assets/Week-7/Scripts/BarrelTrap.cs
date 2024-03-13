using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Week7
{
    public class BarrelTrap : MonoBehaviour
    {
        // Damage dealt to player
        private float damageInflict = 11.5f;

        GameObject playerObject; 
        


        // When player enters the trigger point, the barrel will deal damage and will be destroy
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name == "Player")
            {
                playerObject.GetComponent<Player>().DamagePlayer(damageInflict);
                Destroy(gameObject);
            }

        }


        // Start is called before the first frame update
        void Start()
        {
            // Initializing the player object for the barrel to deal damage to
            playerObject = GameObject.Find("Player");
        }

    }
}

