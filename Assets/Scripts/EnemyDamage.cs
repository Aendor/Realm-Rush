﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }
    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}