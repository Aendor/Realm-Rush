using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; // todo: Make private

    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        //ExploreNeighbours();
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        
        while (queue.Count > 0)
        {
            Waypoint searchCenter = queue.Dequeue();
            HaltIfEndFound(searchCenter);
            print($"Searching from: {searchCenter}"); // todo: remove log
        }

        print("Finished pathfinding");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            //queue.Dequeue();
            print("End point has been found therefore stopping"); // todo: remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;

            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch { }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning($"Skipping overlapping block: {waypoint.name}");
            }
            else
            {
                // add to dictionary
                grid.Add(gridPos, waypoint);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
