using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    
    public BoilerRoom boilerRoom;

    Vector3 scaler;

    public float maxHealth = 100f;

    private float health = 100f;

    protected float pressure = 0f;

    public float maxPressure = 100f;

    public float pressureLeakRate = 0.1f;

    public float pressureLeakThreshold = .75f;

    private void Start()
    {
        scaler = gameObject.transform.localScale;
        gameObject.transform.localScale.Set(scaler.x, pressure / maxPressure, scaler.z);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            addPressure(10f);
        }
    }

    void FixedUpdate()
    {

        if(health < (maxHealth * pressureLeakThreshold))
        {
            reducePressure(pressureLeakRate);
        }
    }

    public bool usePressure()
    {
        return true;
    }

    public bool reducePressure(float amt)
    {
        pressure -= amt;
        if(pressure < 0)
        {
            pressure = 0;
        }
        gameObject.transform.localScale.Set(scaler.x, pressure / maxPressure, scaler.z);
        return true;
    }

    public virtual bool addPressure(float amt)
    {
        if (amt <= boilerRoom.pressure)
        {
            boilerRoom.reducePressure(amt);
            pressure += amt;
            gameObject.transform.localScale.Set(scaler.x, pressure / maxPressure, scaler.z);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void repair(float amt)
    {
        health += amt;
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void damage(float amt)
    {
        health -= amt;
        if(health <= 0)
        {
            health = 0;
        }
    }
}
