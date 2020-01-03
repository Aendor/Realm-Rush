using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)][SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemy());
    }

    private IEnumerator RepeatedlySpawnEnemy()
    {
        while (true) // forever
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
