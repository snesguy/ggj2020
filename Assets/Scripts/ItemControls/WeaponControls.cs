using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : ItemControl
{

    [SerializeField]
    private float rotateSpeed;

    private Rigidbody2D body;

    private float rotationVector;



    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    public override void ControlPart()
    {
        rotationVector = Input.GetAxisRaw("Horizontal") * rotateSpeed;
        body.transform.Rotate(0,0,rotationVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
