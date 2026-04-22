using System;
using System.Data;
using UnityEngine;

public class LevelZooming : MonoBehaviour
{
    private float minZoom = 5;
    private float maxZoom = 15;
    private float zoomSpeed = 2;
    public bool isLevel;

    public Camera camera;
    private float initZoom;
    private float targetZoom;

    private float priorZoomDist = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initZoom = camera.orthographicSize;
        targetZoom = initZoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevel == false ) {
            return;
        }
        if (Input.touchCount == 2)
        {
            Vector2 touch0, touch1;
            touch0 = Input.GetTouch(0).position;
            touch1 = Input.GetTouch(1).position;

            float distance = Vector2.Distance(touch0, touch1);

            if (priorZoomDist == 0)
            {
                priorZoomDist = distance;
                return;
            }

            float change = distance - priorZoomDist;

            targetZoom -= change * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

            priorZoomDist = distance;
        }
        else
        {
            priorZoomDist = 0;
        }

        // for editor testing
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            targetZoom -= scroll * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }
    }

    private void LateUpdate()
    {
        camera.orthographicSize = Mathf.Lerp(
            camera.orthographicSize,
            targetZoom,
            Time.deltaTime * 10f);
    }
}
