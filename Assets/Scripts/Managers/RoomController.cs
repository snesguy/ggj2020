using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class RoomController
{
    [SerializeField]
    private BoilerRoom boilerRoom;

    [SerializeField]
    private float maxHealth;

    private float health;

    private float pressure;

    private float maxPressure;

    public virtual bool usePressure()
    {
        return true;
    }

    public virtual bool reducePressure(float amt)
    {
        pressure -= amt;
        if(pressure < 0)
        {
            pressure = 0;
        }
        return true;
    }

    public virtual bool addPressure(float amt)
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

    public virtual void repair(float amt)
    {
        health += amt;
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void damage(float amt)
    {
        health -= amt;
        if(health <= 0)
        {
            health = 0;
        }
    }
}
