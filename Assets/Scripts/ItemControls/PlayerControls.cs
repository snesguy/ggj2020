using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    Vector2 inputMovement;
    float moveSpeed = 10f;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update () {
        Move ();
    }

    private void Move () {
        Vector3 movement = new Vector3 (inputMovement.x, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate (movement);
    }

    private void OnMove (InputValue value) {
        inputMovement = value.Get<Vector2>();
    }

    private void OnMoveLeft () {
        inputMovement = new Vector2 (-20, 0) * moveSpeed * Time.deltaTime;
    }

    private void OnMoveRight () {
        inputMovement = new Vector2 (20, 0) * moveSpeed * Time.deltaTime;
    }

    private void OnStopMoveLeft () {
        inputMovement = new Vector2 (0, 0);
    }

    private void OnStopMoveRight () {
        inputMovement = new Vector2 (0, 0);
    }

    // public override void ControlPart()
    // {
    //     movementVector.x = Input.GetAxisRaw("Horizontal") * acceleration;
    //     movementVector.x = Mathf.Clamp(movementVector.x, -maxSpeed, maxSpeed);
    //
    //     if (Input.GetKeyDown("space") && grounded)
    //     {
    //         //AudioManager.instance.PlaySound(SoundName.PlayerJump);
    //         movementVector.y = 10;
    //         jumped = true;
    //     }
    //     else movementVector.y = 0;
    //
    //     if (Input.GetKeyUp("space"))
    //     {
    //         jumped = false;
    //     }
    //
    //     if (body.velocity.x + movementVector.x < frictionConstant && body.velocity.x + movementVector.x > -frictionConstant)
    //     {
    //         body.velocity = new Vector2(0, body.velocity.y + movementVector.y);
    //     }
    //     else
    //     {
    //         movementVector.x += -Mathf.Sign(body.velocity.x) * frictionConstant;
    //         body.velocity += movementVector;
    //     }
    //     body.velocity = new Vector2(Mathf.Clamp(body.velocity.x, -maxSpeed, maxSpeed), body.velocity.y);
    // }
}
