using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class ScreenLogic : MonoBehaviour
    {
        [SerializeField]
        private float LeftBound = -9.3f;
        [SerializeField]
        private float RightBound = 9.3f;

        private void Update()
        {
            DetectIfOffScreen();
        }

        private void DetectIfOffScreen()
        {
            // Left side of screen
            if (transform.position.x < LeftBound)
            {
                transform.position = new Vector2(RightBound, transform.position.y);
            }

            // Right side of screen
            if (transform.position.x > RightBound)
            {
                transform.position = new Vector2(LeftBound, transform.position.y);
            }
        }
    }
}
