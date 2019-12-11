using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;

    public float speed = 1f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        rigidBody2D = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {

       float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
       animator.SetBool("walk",(h != 0));
        if (h<0) {
            spriteRenderer.flipX = true;
        }else if (h > 0) {
            spriteRenderer.flipX = false;
        }

        transform.Translate (Vector3.right * h * speed);

        if (Input.GetKeyDown (KeyCode.Space)) {
            rigidBody2D.AddForce (Vector2.up * 2, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidBody2D.AddForce (Vector2.up*10);
        }
    }
}
