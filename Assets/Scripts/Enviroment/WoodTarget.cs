using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTarget : MonoBehaviour
{
  
    public float health = 50f;
    [TextArea]
    public string notes = "0=fragile 1=wood 2=stone 3=metal";
    public int resistance;
    public int XPAmount; 
    public GameObject DropToSpawn;
    public Transform anchor;

    void Start() {
         
    }
    public void TakeDamage(float amount)

    {
        health -= amount;
        Debug.Log("Health= " + health);
        if (health <= 0f)
        {
            Die();
         }
    }

    void Die() 
    {
        Destroy(gameObject);
        SpawnObject();
       
    }

  
    public void SpawnObject()
    {
        Instantiate(DropToSpawn, anchor.position, anchor.rotation);
        Instantiate(DropToSpawn, anchor.position, anchor.rotation);
        Instantiate(DropToSpawn, anchor.position, anchor.rotation);
    }
}
