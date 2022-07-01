using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageTakerPlayer : MonoBehaviour
{
   
    public bool isAlive = true;
    public int playerHealth = 100;
    public GameObject player;
    public GameObject deathCam;

   
    private void Start()
    {
           
    }


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int value)
    {
     
        if(playerHealth > 0) {
               playerHealth -= value;
         Debug.Log("Life: " + playerHealth);
        } else if (playerHealth <= 0) {
            Debug.Log("Dead");
            
            deathCam.transform.position = player.transform.position;
           
            isAlive = false;
            // StartCoroutine(Restart(timeToRestart));
           
         
           
                   
             }
    }




  

    //  public IEnumerator Restart(float f)
    //  {
    //      Debug.Log("Restart() ativado");
    //      yield return new WaitForSeconds(f);
    //      Debug.Log("Restart() quase terminado");
    //      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //      Debug.Log("Restart() terminado");
    //  }
}
