﻿using UnityEngine;

namespace Plataformer {
    public class Player : MonoBehaviour {
        static public Player instance;


        [SerializeField]
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rbody2D;
        private Vector3 initialPos;
        private bool onGround = false;

        [SerializeField]
        private HealthBarController healthBarController;
        private HealthBarPointController healthBarPointController;

        [Header ("Attack")]
        public float maxLife = 50;
        [Range (0f, 50f)]
        public float _currentLife;

        public int jumpForce = 5;
        public float speed = 1f;

        [Header ("Attack")]
        [Tooltip ("bullet Prefab")]
        public BulletRock Bullet;


        public Animator animator;
        public bool grounded { get { return RoundAbsoluteToZero (rbody2D.velocity.y) == 0 || onGround; } }
        public float CurrentLife {
            set {
                _currentLife = Mathf.Clamp (value, 0, maxLife);
            }
            get {
                return _currentLife;
            }
        }


        public static Vector3 setPosition {
            set {
                instance.transform.position = value;
            }
        }

        public static HealthBarController HealthBar {
            set {
                instance.healthBarController = value;
            }

            get {
                return instance.healthBarController;
            }
        }

        public static HealthBarPointController HealthBarPoint {
            set {
                instance.healthBarPointController = value;
            }

            get {
                return instance.healthBarPointController;
            }
        }

        private void Awake ()
        {
            instance = this;
            DontDestroyOnLoad (gameObject);
        }

        // Start is called before the first frame update
        void Start ()
        {
            initialPos = transform.position;
            DontDestroyOnLoad (gameObject);
            spriteRenderer = GetComponent<SpriteRenderer> ();
            rbody2D = GetComponent<Rigidbody2D> ();
        }

        // Update is called once per frame
        void Update ()
        {

            float h = Input.GetAxisRaw ("Horizontal") * Time.deltaTime;
            animator.SetBool ("walk", (h != 0));
            animator.SetBool ("jump", !grounded);
            animator.SetFloat ("vertical", Mathf.Sign (rbody2D.velocity.y));
            if (h != 0) {
                spriteRenderer.flipX = (h < 0);
            }

            transform.Translate (Vector3.right * h * speed);

            if (grounded && Input.GetKeyDown (KeyCode.Space)) {
                rbody2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
            }


            if (Input.GetKeyDown (KeyCode.O)) {
                TakeDamage (1f);
            }

            if (Input.GetKeyDown (KeyCode.P)) {
                GainHealth (1f);
            }

            if (Input.GetKeyDown (KeyCode.F)) {
                Attack (spriteRenderer.flipX);
            }

            if (Input.GetKeyDown (KeyCode.G)) {
                FastAttack (spriteRenderer.flipX);
            }

        }

        void FixedUpdate ()
        {
            if (Input.GetKeyDown (KeyCode.Space)) {
                rbody2D.AddForce (Vector2.up * 10);
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

        float RoundAbsoluteToZero (float decimalValue)
        {
            decimalValue = Mathf.Abs (decimalValue);
            if (decimalValue < 0.01f) {
                decimalValue = 0;
            }
            return decimalValue;
        }

        void TakeDamage (float damage)
        {
            CurrentLife -= damage;
            HealthBar.CurrentLife = CurrentLife;

        }

        void GainHealth (float heal)
        {
            CurrentLife += heal;
            HealthBar.CurrentLife = CurrentLife;
            HealthBarPoint.CurrentLife = CurrentLife;
        }

        void Attack (bool left)
        {
            BulletRock clonado = Instantiate<BulletRock> (Bullet, transform.position, Quaternion.identity);
            clonado.Init (1f, left ? Direction.left : Direction.right);
        }

        void FastAttack (bool left)
        {
            BulletRock clonado = Instantiate<BulletRock> (Bullet, transform.position, Quaternion.identity);
            clonado.Init (10f, left ? Direction.left : Direction.right);
        }

    }

}
