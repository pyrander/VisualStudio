using System.Collections;
using UnityEngine;

namespace Plataformer { 
    public class Spawner : MonoBehaviour
    {
        public Enemy enemy;

        static private Spawner instance;

        private Coroutine coroutine;

        static public void Spawn ()
        {
            instance.Create (3f);
        }

        private void Awake ()
        {
            instance = this;
        }


        void Create (float delay)
        {
            coroutine =  StartCoroutine (CreateEnemy(delay));
        }

        private IEnumerator CreateEnemy (float delay)
        {
            yield return new WaitForSecondsRealtime (delay);
            Instantiate<Enemy> (enemy);
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
