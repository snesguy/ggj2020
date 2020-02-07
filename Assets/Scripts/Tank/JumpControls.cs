using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControls : ItemControl
{

    public float baseVelocity = 2.0f;

    public float steamVelocityMultiplier = 1.1f;
    private Rigidbody2D body;

    public bool jump;

    public float devPresureAmount;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(jump)
        {
            jump = false;
            Jump(devPresureAmount);
        }

        ControlPart();
    }

    public override void ControlPart()
    {

    }

    public void Jump(float pressure)
    {
        body.velocity = transform.up * (baseVelocity + (pressure * steamVelocityMultiplier));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
