
using UnityEngine;
using Plataformer;

public class Enemy : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        BulletRock bullet = collision.gameObject.GetComponent<BulletRock> ();
        if (bullet != null) {
            animator.SetBool ("isDead", true);
        }

    }

    void onDeath () {
        SpawnController.Create ();
        Destroy (gameObject);
    }
}
