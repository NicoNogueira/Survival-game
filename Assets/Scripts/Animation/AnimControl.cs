using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
  
    public GameObject theGun; 
    public GameObject viewModel;
 
    void Update()
    {
    

        if (Input.GetButtonDown("M1Fire"))
        {
           

            // theGun.GetComponent<Animator>().Play("PistolFire");
            viewModel.GetComponent<Animator>().Play("Shot");
            Debug.Log("pow pow");
           
        }
    }
}
