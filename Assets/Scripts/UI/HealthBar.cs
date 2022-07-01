using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider healthBar;
    DamageTakerPlayer HP;

    void Start()
    {
        HP = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageTakerPlayer>();
    }

    
    void Update()
    {
        healthBar.value = HP.playerHealth;
    }
}
