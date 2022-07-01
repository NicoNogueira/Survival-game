using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
  public GameObject objectToSpawn;

  public float timeToStart;
  public float timeToSpawn;

  private float currentTimeToSpawn;
  private float currentTimeToStart;
    void Start()
    {
     
        currentTimeToSpawn = timeToSpawn;
        currentTimeToStart = timeToStart;

    }

    // Update is called once per frame
    void Update()
    {
      
        if(currentTimeToStart > 0)
        {
          currentTimeToStart -= Time.deltaTime;
        //   Debug.Log("TimeToStartAmongla: " + currentTimeToStart);
        } else {
            if(currentTimeToSpawn > 0)
            {
                currentTimeToSpawn -= Time.deltaTime;
                // Debug.Log("TimeToSpawnAmongla: " + currentTimeToSpawn);
            }
            else if(currentTimeToStart <= 0 && currentTimeToSpawn <= 0)
            {
                SpawnObject();
                currentTimeToSpawn = timeToSpawn;
            }
        }
        
        
    


       
    }

    public void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
