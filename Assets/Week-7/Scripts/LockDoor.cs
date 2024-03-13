using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Week7
{
    public class LockDoor : MonoBehaviour
    {
        [SerializeField] GameObject door;
        GameObject player;

        Vector3 target;
        Vector3 origin;

        float alpha;
        bool isOpening;

        void Awake()
        {
            origin = transform.position;
            target = origin + (Vector3.up * 3);
        }

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            alpha += isOpening ? Time.deltaTime : -Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            door.transform.position = Vector3.Lerp(origin, target, alpha);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name == "Player")
            {
                if (player.GetComponent<Player>().keyAmount != 0)
                {
                    // Unlock and open the door
                    isOpening = true;
                    player.GetComponent<Player>().keyAmount -= 1;
                }
            }
        }
    }
}
