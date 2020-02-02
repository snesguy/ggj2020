using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerRoom : RoomController
{

    public int totalUranus = 0;
    public float pressurePerUranus = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void addUranium(int amount)
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
