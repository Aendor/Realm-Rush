using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 40f;
    [SerializeField] ParticleSystem ProjectileParticle;

    void Update()
    {
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
