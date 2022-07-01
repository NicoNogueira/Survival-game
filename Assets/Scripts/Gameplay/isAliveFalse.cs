using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isAliveFalse : MonoBehaviour
{
    DamageTakerPlayer die;
    
    public GameObject praga;


    void Start()
    {
        die = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageTakerPlayer>();
    }

    void Update()
    {
        if (die.isAlive == false)
        {
            Debug.Log(praga + "Destroyed");
            Destroy(praga, 0);
        }
    }
}
