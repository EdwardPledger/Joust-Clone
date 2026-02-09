using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        private int numberOfEnemiesToSpawn = 3;
        private Vector3[] spawnPositions;

        // Start is called before the first frame update
        void Start()
        {
            spawnPositions = new Vector3[] { new(-8.03f, 0.27f, 0f), new(-1.37f, 2.43f, 0f), new(-0.31f, -4.06f, 0f) };

            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            int index = 0;

            while (numberOfEnemiesToSpawn > 0)
            {
                yield return new WaitForSeconds(2);

                var enemy = Resources.Load<GameObject>($"Prefabs/Enemy{index}");
                Instantiate(enemy, spawnPositions[index], Quaternion.identity);

                index++;
                numberOfEnemiesToSpawn--;
            }
        }

        public void SpawnEnemyAtPosition(Vector3 position)
        {
            var enemy = Resources.Load<GameObject>("Prefabs/Enemy3");  // Hard coded ref for now
            Instantiate(enemy, position, Quaternion.identity);
        }
    }
}
