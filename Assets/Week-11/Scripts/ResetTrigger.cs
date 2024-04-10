using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week11
{
    public class ResetTrigger : MonoBehaviour
    {
        GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                player.GetComponent<Player>().HasPlayerEscape();
            }
        }
    }
}
