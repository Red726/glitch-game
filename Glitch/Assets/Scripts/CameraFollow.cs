using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    public Transform player;
    public Camera cam;
    private Vector3 camOffset;

    void Start()
    {
        camOffset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player)
        {
            Vector3 newPos = player.position + camOffset;

            transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        }
    }
}