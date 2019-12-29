using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
    private IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol..");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;

            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol..");
    }
}
