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
    private TankInventory tankInventory;

    public bool tankMovementControl = false;
    public bool resourceMovementControl = false;
    public bool resourceGetControl = false;
    public bool uraniumMovementControl = false;
    public bool uraniumGetControl = false;


    /** Inventory **/
    public bool handsFull = false;
    public int uranium = 0;
    public int gear = 0;

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
            teamTank = GameObject.Find("ProtoTank2");
            playerTeam = 1;
        }

        tankInventory = teamTank.GetComponent<TankInventory>();
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
        else if(resourceGetControl && uranium == 0)
        {
            if(tankInventory.gearCount > 0 && Random.Range(0, 100) == 50)
            {
                tankInventory.gearCount--;
                gear++;
                handsFull = true;
            }
        }
        else if(resourceMovementControl)
        {
            if (gear > 0 && Random.Range(0, 100) == 50)
            {
                gear--;
                // Repair
                if(gear == 0)
                {
                    handsFull = false;
                }
            }
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
        // Other movement control
    }

    private void OnMovement (InputValue value) {
        objectMovement = value.Get<Vector2> ();
    }

    private void OnGetOut () {
        playerInput.SwitchCurrentActionMap ("PlayerControl");
    }

    public int getGear()
    {
        return gear;
    }
    public void addGear(int newGear)
    {

        gear += newGear;
    }
    public void useGear(int gearUsed)
    {

        gear -= gearUsed;
    }
    public int getUranium()
    {
        return uranium;
    }
    public void addUranium(int newUranium)
    {

        uranium += newUranium;
    }
    public void useUranium(int uraniumUsed)
    {

        uranium += uraniumUsed;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.name == "Button_RM") {
            tankMovementControl = true;
        }
        else if(col.gameObject.name == "ButtonLB")
        {
            resourceMovementControl = true;
        }
        else if (col.gameObject.name == "Button_Resource_Get")
        {
            resourceGetControl = true;
        }
        else if (col.gameObject.name == "ButtonRB")
        {
            uraniumMovementControl = true;
        }
        else if (col.gameObject.name == "Button_Uranium_Get")
        {
            uraniumGetControl = true;
        }
    }

    void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.name == "Button_RM") {
            tankMovementControl = false;
        }
        else if (col.gameObject.name == "ButtonLB")
        {
            resourceMovementControl = false;
        }
        else if (col.gameObject.name == "Button_Resource_Get")
        {
            resourceGetControl = false;
        }
        else if (col.gameObject.name == "ButtonRB")
        {
            uraniumMovementControl = false;
        }
        else if (col.gameObject.name == "Button_Uranium_Get")
        {
            uraniumGetControl = false;
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
