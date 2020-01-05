using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        // Change to queue size
        int numTowners = towerQueue.Count;

        if (numTowners < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;

        // Set the baseWaypoints
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }
    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();

        // Set the placeable flags
        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        // Set the baseWaypoints
        oldTower.baseWaypoint = newBaseWaypoint;

        // Move tower
        oldTower.transform.position = newBaseWaypoint.transform.position;

        // Put the old tower back on the queue
        towerQueue.Enqueue(oldTower);
    }
}
