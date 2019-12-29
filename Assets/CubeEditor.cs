using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }
    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPos = waypoint.GetGridPos();

        transform.position = new Vector3(gridPos.x, 0, gridPos.y);
    }

    private void UpdateLabel()
    {
        TextMesh TextMesh = GetComponentInChildren<TextMesh>();

        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPos = waypoint.GetGridPos();

        string labelText = (gridPos.x / gridSize) + "," + (gridPos.y / gridSize);
        TextMesh.text = labelText;
        gameObject.name = labelText;
    }
}
