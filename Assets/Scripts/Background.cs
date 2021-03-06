﻿using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeY;

    private Vector3 startPosition;

    void Start ()
    {
        startPosition = transform.position;
    }

    void Update ()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.down * newPosition;
    }
}
