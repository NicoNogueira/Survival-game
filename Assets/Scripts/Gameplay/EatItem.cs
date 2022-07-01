using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour
{   
    public int hungerValue; 
    public HungerMechanic hunger;
 
    void Start()
    {

    }

 
    void Update()
    {
       
         if(Input.GetButtonDown("Fire1")) 
             {
             
                Eat();
                // animator.GetComponent<Animator>().Play("AttackShotgun");
                Debug.Log("eating");
            }


  
    }

    void Eat()
    {
        hunger.addHunger(hungerValue);
      
    }


}
