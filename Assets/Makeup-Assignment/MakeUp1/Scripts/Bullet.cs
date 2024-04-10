using UnityEngine;

namespace SpaceShooter
{
    public class Bullet : MonoBehaviour
    {
        //TODO: Expose a float variable for speed here that you can
        //      change in the inspector
        [SerializeField] float speed = 5f;

        void Update()
        {
            //TODO: Write 1 line of code that moves the bullet UP along the Y axis here
            //      You need to apply speed and Time.deltaTime
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            //TODO: check if the y positive is greater than 7 and if so then destroy the bullet
            if (transform.position.y > 7)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //TODO: Destroy the bullet here since our collision system will
            //      only detect collisions with asteroids it is safe to assume we hit an asteroid
            Destroy(gameObject);
        }
    }
}