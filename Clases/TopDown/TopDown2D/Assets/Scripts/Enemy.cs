using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown {
    public class Enemy : MonoBehaviour
    {
        public ElementType type = ElementType.fire;
        public ElementType weak = ElementType.fire;

        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
            Proyectile projectile = collision.GetComponent<Proyectile>();

            if (projectile != null)
                if (projectile.type == weak)
                    Destroy(gameObject);
        }
    }
}


