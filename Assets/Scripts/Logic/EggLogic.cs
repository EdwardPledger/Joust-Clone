using Managers;
using Spawners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLogic : MonoBehaviour
{
    private UIManager uiManager;
    private EnemySpawner enemySpawner;

    private bool eggSmashed = false;
    private string prefabName = string.Empty;

    private void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            uiManager.UpdateScore(100);  // TODO: Make the score amount a constant
            eggSmashed = true;

            enemySpawner.SpawnEnemyAtPosition(prefabName, transform.position);

            Destroy(gameObject);
        }
    }

    /*
     * If the egg is hit by the player within 5 seconds then this code will never execute.
     */
    public IEnumerator HatchEgg(string prefabName)
    {
        this.prefabName = prefabName;

        while (!eggSmashed)
        {
            yield return new WaitForSeconds(5);

            if (!eggSmashed)
            {
                Destroy(gameObject);
            }
        }
    }
}
