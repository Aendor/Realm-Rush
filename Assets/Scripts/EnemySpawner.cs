﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)][SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemy());
        spawnedEnemies.text = score.ToString();
    }

    private IEnumerator RepeatedlySpawnEnemy()
    {
        while (true) // forever
        {
            AddSCore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            newEnemy.transform.parent = enemyParentTransform;

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddSCore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
