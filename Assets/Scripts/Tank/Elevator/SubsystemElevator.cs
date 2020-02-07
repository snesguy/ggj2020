using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsystemElevator : MonoBehaviour
{
    float yStart;
    public float framerate = 60.0f;
    public float timeToStopInSeconds = 1.0f;
    public float pauseBeforeMovingInSeconds = 1.0f;
    public float movementSpeed;
    public bool waitingToMove = true;
    public float timeTilMove = 0.0f;
    public float direction = 1.0f;
    private float bottomLocation = 0.0f;//-4.75f;
    private float topLocation = 4.75f + 1.58333333333f;

    private float distanceToMove = 3.17f;

    // Start is called before the first frame update
    void Start()
    {
        yStart = transform.position.y;
        topLocation = yStart + topLocation;
        bottomLocation = yStart;
        timeTilMove = timeToStopInSeconds;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementSpeed = distanceToMove / framerate * timeToStopInSeconds;

        if(waitingToMove)
        {
            timeTilMove -= Time.deltaTime;
            if(timeTilMove < 0.0f)
            {
                waitingToMove = false; 
            }
        }
        else
        {
            transform.Translate(0, movementSpeed * direction, 0);
            if(direction > 0.0f && transform.position.y > topLocation)
            {
                transform.position = new Vector2(transform.position.x, topLocation);
                direction *= -1.0f;
                waitingToMove = true;
                timeTilMove = timeToStopInSeconds;
            }
            else if (direction < 0.0f && transform.position.y < bottomLocation)
            {
                transform.position = new Vector2(transform.position.x, bottomLocation);
                direction *= -1.0f;
                waitingToMove = true;
                timeTilMove = timeToStopInSeconds;
            }
        }
    }
}
