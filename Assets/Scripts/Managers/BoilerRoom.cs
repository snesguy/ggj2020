using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerRoom : RoomController
{

    public float totalUranus = 0f;
    public float pressurePerUranus = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            addUranium(10f);
        }
    }

    public override bool addPressure(float amt)
    {
        pressure += amt;
        if(pressure > maxPressure)
        {
            pressure = maxPressure;
        }
        return true;
    }

    public void addUranium(float amount)
    {
        addPressure(pressurePerUranus * amount);
        totalUranus += amount;
    }

    public void addUranium()
    {
        addPressure(pressurePerUranus);
        totalUranus++;
    }

}
