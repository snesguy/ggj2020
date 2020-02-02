using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInventory : MonoBehaviour
{
    public int gearCount;
    public int maxGear;
    // Start is called before the first frame update
    void Start()
    {
        gearCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ResorceContence gear;
        if (null != (gear = collision.gameObject.GetComponent<ResorceContence>()))
        {
            int avalibleGears = gear.get();
            int gearsTaken = 0;
            if (gearCount + avalibleGears <= maxGear)
            {
                gearsTaken = avalibleGears;
            }
            else
            {
                gearsTaken = avalibleGears - (gearCount + avalibleGears - maxGear);
            }
            setGear(gearsTaken);
            gear.set(gearsTaken);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ResorceContence gear;
        if (null != (gear = collider.gameObject.GetComponent<ResorceContence>()))
        {
            int avalibleGears = gear.get();
            int gearsTaken = 0;
            if (gearCount + avalibleGears <= maxGear) {
                gearsTaken = avalibleGears;
            }
            else
            {
                gearsTaken = avalibleGears - (gearCount + avalibleGears - maxGear);
            }
            setGear(gearsTaken);
            gear.set(gearsTaken);
        }
    }

    public int getGear() {
        return gearCount;
    }
    public void setGear(int newGear)
    {
        
        gearCount += newGear;
    }
}
