
using UnityEngine;

namespace Plataformer {
    public class BulletRock : MonoBehaviour {

        public Direction direction = Direction.right;
        public float speed = 5f;
        private float lifetime = 3f;
        //private bool left = false;

        // Start is called before the first frame update
        void Start ()
        {
            Destroy (gameObject, lifetime);
        }

        // Update is called once per frame
        void Update ()
        {
            //int direction = 1;
            //if (left) {
            //    direction = -1;
            //}
            Vector3 pos = ((int)direction * Vector3.right * speed * Time.deltaTime);
            transform.position += pos;
        }

        public void Init (float multiplier, Direction direction)
        {
            speed = speed * multiplier;
            this.direction = direction;
        }

        private void OnCollisionEnter2D (Collision2D collision)
        {
            Destroy (gameObject);
        }
    }
}

