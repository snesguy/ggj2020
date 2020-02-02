using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{

    public GameObject[] emitters;
    
    public BoilerRoom boilerRoom;

    Vector3 scaler;

    private Health hp;

    protected float pressure = 0f;

    public float maxPressure = 100f;

    public float pressureLeakRate = 0.1f;

    public float pressureLeakThreshold = .75f;

    private void Start()
    {

        hp = gameObject.GetComponent<Health>();

        scaler = gameObject.transform.localScale;
        UpdateSteamGaugeVisual();
    }

    void UpdateSteamGaugeVisual()
    {
        Vector3 newLocalScale = gameObject.transform.localScale;
        newLocalScale.Set(scaler.x, pressure / maxPressure, scaler.z);
        gameObject.transform.localScale = newLocalScale;
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {

        if(hp.current < (hp.max * pressureLeakThreshold))
        {
            reducePressure(pressureLeakRate);
        }
        foreach (GameObject emitter in emitters)
            {
                emitter.GetComponent<SteamEmitterScript>().setEmissions(1f-((float)hp.current/hp.max) * 500f);
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
        UpdateSteamGaugeVisual();
        return true;
    }

    public virtual bool addPressure(float amt)
    {
        if (amt <= boilerRoom.pressure)
        {
            boilerRoom.reducePressure(amt);
            pressure += amt;
            if (pressure > maxPressure)
            {
                pressure = maxPressure;
            }
            UpdateSteamGaugeVisual();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void repair(int amt)
    {
        hp.current += amt;
        if(hp.current >= hp.max)
        {
            hp.current = hp.max;
        }
    }

    public void damage(int amt)
    {
        hp.current -= amt;
        if(hp.current <= 0)
        {
            hp.current = 0;
        }
    }
}
