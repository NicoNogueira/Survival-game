using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerMechanic : MonoBehaviour
{
   public int maxHunger = 100;
   public int hunger = 100;
   public float hungerTimer;
   public float currentHungerTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hunger > 0){
              currentHungerTimer -= Time.deltaTime;
        }
     
       if(currentHungerTimer <= 0)
       {
        TakeHunger(1);
       }
       
        if(Input.GetKeyDown(KeyCode.L))
        {
            addHunger(10);
        }
        

    }


    public void addHunger(int a)
    {
        if(hunger < maxHunger)
        {
             hunger += a;
        }
      
    }

    public void TakeHunger(int a)
    {
        hunger -= a;
        currentHungerTimer = hungerTimer;
    }


}
