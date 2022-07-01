using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider hungerBar;
    HungerMechanic hungerMechanic;

    void Start()
    {
        hungerMechanic = GameObject.FindGameObjectWithTag("Player").GetComponent<HungerMechanic>();
    }

    
    void Update()
    {
        hungerBar.value = hungerMechanic.hunger;
    }
}
