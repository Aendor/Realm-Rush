using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)][SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemy());
    }

    private IEnumerator RepeatedlySpawnEnemy()
    {
        while (true) // forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            newEnemy.transform.parent = enemyParentTransform;

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
