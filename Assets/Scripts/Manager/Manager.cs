using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Manager : MonoBehaviour
{
    DamageTakerPlayer die;
     public float timeToRestart;

    void Start()
    {
        die = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageTakerPlayer>();
    }

   
    void Update()
    {
       if (die.isAlive == false)
        {
             Invoke("Restart", timeToRestart);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
