using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class PlayerLogic : EntityLogic
    {
        [SerializeField]
        public UIManager uiManager;

        private Rigidbody2D rb;
        private Vector2 startPosition;
        

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            startPosition = transform.position;
        }

        private void Update()
        {
            Jump();
            MoveHorizontally();
            CheckIfFallenOffEdge();
        }

        private void OnEnable()
        {
            
        }

        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            }
        }

        void MoveHorizontally()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * VerticalSpeed, rb.velocity.y);
            }
        }

        void CheckIfFallenOffEdge()
        {
            if (transform.position.y < -7)
            {
                transform.position = startPosition;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                var enemyPosition = collision.gameObject.transform.position;

                // Just check who has a higher y coordinate
                if (enemyPosition.y > transform.position.y)
                {
                    uiManager.UpdateLives(false);

                    if (uiManager.GetLives() != 0)
                    {
                        transform.position = startPosition;
                    }
                    else
                    {
                        // game over screen
                    }
                }
                else
                {
                    // Apply slight upward force on player
                    rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

                    collision.gameObject.GetComponent<EnemyLogic>().Defeated(transform.position.x);

                    uiManager.UpdateScore(50);  // Give the player 50 points
                }
            }
        }
    }
}
