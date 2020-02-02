using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController
{
    
    public BoilerRoom boilerRoom;

    public float maxHealth;

    private float health;

    private float pressure;

    private float maxPressure;

    public float pressureLeakRate = 0.1f;

    public float pressureLeakThreshold = .75f;

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
        return true;
    }

    public bool addPressure(float amt)
    {
        if (amt >= boilerRoom.pressure)
        {
            boilerRoom.reducePressure(amt);
            pressure += amt;
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
