using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public Camera camera;
    public Transform[] objects;
    public float maxOrtho = 15.0f;
    public float minOrtho = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xSum = 0.0f;
        float ySum = 0.0f;
        float miny = objects[0].position.y;
        float maxy = objects[0].position.y;
        float minx = objects[0].position.x;
        float maxx = objects[0].position.x;
        foreach (Transform obj in objects)
        {
            xSum += obj.position.x;
            ySum += obj.position.y;
            if (obj.position.y < miny)
                miny = obj.position.y;
            else if (obj.position.y > maxy)
                maxy = obj.position.y;
            if (obj.position.x < minx)
                minx = obj.position.x;
            else if (obj.position.x > maxx)
                maxx = obj.position.x;
        }
        float height = Mathf.Abs(maxy - miny);
        float width = Mathf.Abs(maxx - minx);

        float minyOrtho = height;
        float minxOrtho = width * camera.rect.height / camera.aspect;

        float ortho = Mathf.Max(minxOrtho, minyOrtho);
        ortho = Mathf.Min(ortho, maxOrtho);
        ortho = Mathf.Max(ortho, minOrtho);
        camera.orthographicSize = ortho;
        if (ortho == maxOrtho)
        {
            transform.position = new Vector3(0.0f, 0.0f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3((xSum / objects.Length), -6.0f, transform.position.z);
        }
    }
}
