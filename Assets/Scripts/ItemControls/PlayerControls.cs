using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : ItemControl
{
    [SerializeField]
    protected float acceleration;

    [SerializeField]
    protected float maxSpeed;

    [SerializeField]
    protected float frictionConstant;

    private Vector2 movementVector = new Vector2(0, 0);
    private Rigidbody2D body;
    private bool onControls = false;
    private PlayerController.PlayerStates itemState;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    public override void ControlPart()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal") * acceleration;
        movementVector.x = Mathf.Clamp(movementVector.x, -maxSpeed, maxSpeed);

        if (Input.GetKeyDown("space") && onControls)
        {
            
        }
        if (body.velocity.x + movementVector.x < frictionConstant && body.velocity.x + movementVector.x > -frictionConstant)
        {
            body.velocity = new Vector2(0, body.velocity.y + movementVector.y);
        }
        else
        {
            movementVector.x += -Mathf.Sign(body.velocity.x) * frictionConstant;
            body.velocity += movementVector;
        }
        body.velocity = new Vector2(Mathf.Clamp(body.velocity.x, -maxSpeed, maxSpeed), body.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemState = collision.GetComponent<ItemControl>().itemControl;
        onControls = true;
    }
}