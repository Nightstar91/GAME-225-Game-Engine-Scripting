using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week7
{
    public class Key : MonoBehaviour
    {
        GameObject player;

        private void OnTriggerEnter(Collider other)
        {
                
            player.GetComponent<Player>().GetKey(1);
            Destroy(gameObject);

        }

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
        }
    }
}

