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

    private GameObject playerCount;
    private GameObject parentObject;

    GameObject teamTank;
    Vector2 objectMovement;

    Vector2 inputMovement;
    public float moveSpeed = 10f;
    public int playerNumber;
    public int playerTeam;

    PlayerInput playerInput;

    bool tankMovementControl = false;

    void Start () {
        body = gameObject.GetComponent<Rigidbody2D> ();
        playerCount = GameObject.Find ("PlayerCount");
        parentObject = GameObject.Find ("Subsystem_Prefab");
        playerInput = gameObject.GetComponent<PlayerInput> ();

        playerNumber = playerCount.GetComponent<playerCount> ().getCount ();
        playerCount.GetComponent<playerCount> ().incrementCount ();

        if (playerNumber % 2 == 0) {
            transform.position = new Vector3 (-9, -4, 0);
            transform.parent = parentObject.transform;
            teamTank = GameObject.Find ("ProtoTank");
            playerTeam = 0;
        } else {
            transform.position = new Vector3 (5, -4, 0);
            playerTeam = 1;
        }
    }

    void Update () {
        Move ();
        MoveControlledObject ();
    }

    private void Move () {
        Vector3 movement = new Vector3 (inputMovement.x, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate (movement);
    }

    private void MoveControlledObject () {
        if (tankMovementControl) {
            Vector3 movement = new Vector3 (objectMovement.x, 0, 0) * moveSpeed * Time.deltaTime;

            teamTank.transform.Translate (movement);
        }
    }

    private void OnMove (InputValue value) {
        inputMovement = value.Get<Vector2> ();
    }

    private void OnMoveLeft () {
        inputMovement = new Vector2 (-23.5f, 0) * moveSpeed * Time.deltaTime;
    }

    private void OnMoveRight () {
        inputMovement = new Vector2 (23.5f, 0) * moveSpeed * Time.deltaTime;
    }

    private void OnStopMoveLeft () {
        inputMovement = new Vector2 (0, 0);
    }

    private void OnStopMoveRight () {
        inputMovement = new Vector2 (0, 0);
    }

    private void OnUseControl () {
        if (tankMovementControl) {
            playerInput.SwitchCurrentActionMap ("TankMovementControl");
        }
    }

    private void OnMovement (InputValue value) {
        objectMovement = value.Get<Vector2> ();
    }

    private void OnGetOut () {
        playerInput.SwitchCurrentActionMap ("PlayerControl");
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.name == "Button_RM") {
            tankMovementControl = true;
        }
    }

    void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.name == "Button_RM") {
            tankMovementControl = false;
        }
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
