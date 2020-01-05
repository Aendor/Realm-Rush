using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public is ok as a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
                gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize),
                gridPos.y = Mathf.RoundToInt(transform.position.z / gridSize)
                );
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
        }
    }
}
