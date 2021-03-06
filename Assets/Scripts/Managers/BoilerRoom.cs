﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerRoom : MonoBehaviour
{
    public GameObject[] emitters;

    Vector3 scaler;

    private Health hp;

    public float pressure = 0f;

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
        if (Input.GetKey(KeyCode.F))
        {
            addPressure(.1f);
            foreach (GameObject emitter in emitters)
            {
                emitter.GetComponent<SteamEmitterScript>().setEmissions(1000f);
            }
        }
    }

    void FixedUpdate()
    {

        if (hp.current < (hp.max * pressureLeakThreshold))
        {
            foreach (GameObject emitter in emitters)
            {
                emitter.GetComponent<SteamEmitterScript>().setEmissions(1000f);
            }
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
        if (pressure < 0)
        {
            pressure = 0;
        }
        UpdateSteamGaugeVisual();
        return true;
    }

    public virtual bool addPressure(float amt)
    {
        pressure += amt;
        if (pressure > maxPressure)
        {
            pressure = maxPressure;
        }
        UpdateSteamGaugeVisual();
        return true;
    }

    public void repair(int amt)
    {
        hp.current += amt;
        if (hp.current >= hp.max)
        {
            hp.current = hp.max;
        }
    }

    public void damage(int amt)
    {
        hp.current -= amt;
        if (hp.current <= 0)
        {
            hp.current = 0;
        }
    }
}
