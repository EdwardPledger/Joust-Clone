using Spawners;
using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class EnemyLogic : EntityLogic
    {
        [SerializeField]
        public float[] JumpWaitTime;
        private EggSpawner eggSpawner;

        private Rigidbody2D rb;
        private Vector2 startPosition;
        private bool firstJumpMade = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            eggSpawner = GameObject.FindGameObjectWithTag("EggSpawner").GetComponent<EggSpawner>();
        }

        private void Start()
        {
            startPosition = transform.position;

            StartCoroutine(RepeatJump());
        }

        // Update is called once per frame
        private void Update()
        {
            Move();

            // So the method isn't triggered on first frame
            if (firstJumpMade)
            {
                DetectIfStartPositionIsHit();
            }
        }

        private IEnumerator RepeatJump()
        {
            var index = 0;
            var keepJumping = true;

            while (keepJumping)
            {
                //Debug.Log("Index: " + index);
                //Debug.Log("Time: " + JumpWaitTime[index]);
                yield return new WaitForSeconds(JumpWaitTime[index]);

                Jump();

                if (index == 1)
                {
                    firstJumpMade = true;
                }

                if (index == JumpWaitTime.Length - 1)
                {
                    keepJumping = false;
                }

                ++index;
            }
        }

        private void Move()
        {
            rb.velocity = new Vector2(1 * VerticalSpeed, rb.velocity.y);
        }

        private void Jump()
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

        // Need to start the coroutine on the start position so the jumps are the same
        private void DetectIfStartPositionIsHit()
        {
            // Only care about x coordinate
            if (Math.Round(transform.position.x, 1) == Math.Round(startPosition.x, 1))
            {
                //Debug.Log("Start pos hit");
                StartCoroutine(RepeatJump());
                firstJumpMade = false;
            }
        }

        public void Defeated(float xCoordinate)
        {
            if (transform.position.x < xCoordinate)
            {
                // Remove clone part of name
                eggSpawner.SpawnEgg(transform.position, gameObject.name[..6], true);
            }
            else
            {
                // Remove clone part of name
                eggSpawner.SpawnEgg(transform.position, gameObject.name[..6], false);
            }

            Destroy(gameObject);
        }
    }
}
