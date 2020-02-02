using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : ItemControl
{

    public float baseSpeed = 2.0f;

    public float steamSpeedMultiplier = 1.1f;

    public float baseDamage = 5.0f;

    public float steamDamageMultiplier = 1.1f;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float maxAngle;

    [SerializeField]
    private float minAngle;

    public Transform spawnPoint;

    public GameObject bulletPrefab;

    private Rigidbody2D body;

    private float rotationVector;

    public bool fire = false;
    public float devPresureAmount = 1.0f;




    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(fire)
        {
            fire = false;
            Fire(devPresureAmount);
        }

        ControlPart();
    }

    public override void ControlPart()
    {
        rotationVector = Input.GetAxisRaw("Horizontal") * -rotateSpeed;
        transform.Rotate(0,0,rotationVector);

        if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 240)
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 270);
        else if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 120)
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 90);

        //Debug.Log(transform.eulerAngles.z);
    }

    public void Fire(float pressure)
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.velocity =  transform.up * (baseSpeed + (pressure * steamSpeedMultiplier));

        DamageDealer script = bullet.GetComponent<DamageDealer>();
        script.damage = (int) (baseDamage + (pressure * steamDamageMultiplier));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
