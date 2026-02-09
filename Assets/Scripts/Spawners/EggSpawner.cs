using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    public class EggSpawner : MonoBehaviour
    {
        [SerializeField]
        public GameObject egg;
        [SerializeField]
        public EggLogic eggLogic;

        private List<GameObject> eggs = new();

        /*
        * Spawn egg and apply force depending on which side the enemy was hit from
        */
        public void SpawnEgg(Vector3 position, string prefabName, bool pushLeft)
        {
            var eggInstance = Instantiate(egg, new Vector3(position.x, position.y - 0.5f, 0), new Quaternion());
            eggs.Add(eggInstance);
            var eggRigidBody = eggInstance.GetComponent<Rigidbody2D>();

            // If the enemy was on the right side
            if (pushLeft)
            {
                eggRigidBody.AddForce(Vector2.left * 6, ForceMode2D.Impulse);
            }
            else
            {
                eggRigidBody.AddForce(Vector2.right * 6, ForceMode2D.Impulse);
            }

            StartCoroutine(eggLogic.HatchEgg(prefabName));
        }
    }
}
