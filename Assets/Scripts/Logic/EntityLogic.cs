using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public abstract class EntityLogic : MonoBehaviour
    {
        [SerializeField]
        protected float JumpForce = 4.0f;
        [SerializeField]
        protected float VerticalSpeed = 2.0f;
    }
}
