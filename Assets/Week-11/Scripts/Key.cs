using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week11
{
    public class Key : MonoBehaviour
    {
        GameObject player;

        private void OnTriggerEnter(Collider other)
        {
                
            player.GetComponent<Player>().GetKey(1);
            gameObject.SetActive(false); // Using SetActive to be use for reset

        }


        private void Reset()
        {
            gameObject.SetActive(true);
        }

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");

            GameManager.GetGameResetEvent().AddListener(Reset);
        }
    }
}

