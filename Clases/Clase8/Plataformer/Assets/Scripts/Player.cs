using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;


    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody2D;
    private Vector3 initialPos;
    private bool onGround = false;

    public int jumpForce = 5;
    public float speed = 1f;
    public Animator animator;
    public bool grounded { get { return RoundAbsoluteToZero(rbody2D.velocity.y)==0 || onGround; } }


    static public Vector3 setPosition {
        set {
            instance.transform.position = value;
        }
    }


    // Start is called before the first frame update
    void Start ()
    {
        initialPos = transform.position;
        instance = this;
        DontDestroyOnLoad (gameObject);
        spriteRenderer = GetComponent<SpriteRenderer> ();
        rbody2D = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {

       float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
       animator.SetBool("walk",(h != 0));
       animator.SetBool ("jump", !grounded);
       animator.SetFloat ("vertical", Mathf.Sign(rbody2D.velocity.y));
        if (h!=0) {
            spriteRenderer.flipX = (h < 0);
        }

        transform.Translate (Vector3.right * h * speed);

        if (grounded && Input.GetKeyDown (KeyCode.Space)) {
            rbody2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rbody2D.AddForce (Vector2.up*10);
        }
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Death") {
            transform.position = initialPos;
        }

        if (col.gameObject.tag == "Floor") {
            onGround = true;
        }

    }

    private void OnCollisionExit2D (Collision2D col)
    {
        if (col.gameObject.tag == "Floor") {
            onGround = false;
        }
    }

    float RoundAbsoluteToZero (float decimalValue) {
        decimalValue = Mathf.Abs (decimalValue);
        if (decimalValue < 0.01f) {
            decimalValue = 0;
        }
        return decimalValue;
    }
}
