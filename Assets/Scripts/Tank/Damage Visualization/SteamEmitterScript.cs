using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamEmitterScript : MonoBehaviour
{

    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void setEmissions(float rate)
    {
        ParticleSystem.EmissionModule emission = ps.emission;
        emission.rateOverTime = rate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
