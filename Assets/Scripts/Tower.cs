using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameter
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 40f;
    [SerializeField] ParticleSystem ProjectileParticle;

    public Waypoint baseWaypoint; // What the tower is standing on

    // State
    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        EnemyDamage[] sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        float distToA = Vector3.Distance(objectToPan.position, transformA.position);
        float distToB = Vector3.Distance(objectToPan.position, transformB.position);

        if (distToA < distToB)
        {
            return transformA;
        }

        return transformB;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(objectToPan.position, targetEnemy.position);

        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }
    private void Shoot(bool isActive)
    {
        var emissionModule = ProjectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
