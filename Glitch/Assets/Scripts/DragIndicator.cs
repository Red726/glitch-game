using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIndicator : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    public Camera cam;
    public LineRenderer lr;

    Vector3 camOffset = new Vector3(0, 0, 10);

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lr.enabled = true;
            lr.positionCount = 2;
            startPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            lr.SetPosition(0, startPos);
            lr.useWorldSpace = true;
            lr.numCapVertices = 1;
        }

        if (Input.GetMouseButton(0))
        {
            endPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            lr.SetPosition(1, endPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
        }
    }
}
