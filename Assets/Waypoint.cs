﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;

    // public is ok as a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
        }
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
                gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize),
                gridPos.y = Mathf.RoundToInt(transform.position.z / gridSize)
                );
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();

        topMeshRenderer.material.color = color;
    }
}
