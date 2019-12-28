using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Range(1f,20f)] [SerializeField] float gridSize = 10f;
    TextMesh TextMesh;
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = snapPos;

        TextMesh = GetComponentInChildren<TextMesh>();

        string labelText = (snapPos.x / gridSize) + "," + (snapPos.z / gridSize);
        TextMesh.text = labelText;
        gameObject.name = labelText;
    }
}
