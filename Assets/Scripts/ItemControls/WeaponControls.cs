using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : ItemControl
{

    [SerializeField]
    private float rotateSpeed;

    private Rigidbody2D body;

    private Vector3 rotationVector;



    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    public override void ControlPart()
    {
        rotationVector = Quaternion.Euler(Vector3.forward * Input.GetAxisRaw("Horizontal"));
        body.transform.Rotate(rotationVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
