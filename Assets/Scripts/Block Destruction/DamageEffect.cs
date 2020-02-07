using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        UpdateDamageEffect();
    }

    // Update is called once per frame
    public void UpdateDamageEffect()
    {
        Color currentColor = gameObject.GetComponent<SpriteRenderer>().color;
        float healthPercent = (float) health.current / (float) health.max;
        Color newColor = new Color(currentColor.r, healthPercent, healthPercent); 
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }


}
