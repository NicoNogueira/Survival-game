using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildGun : MonoBehaviour
{
   
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public bool isAuto;
    public string type;
    public GameObject floor;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;

    public Animator animator;

    public Transform fpsCam;
    public ParticleSystem muzzleFlash;
    

    private float nextTimeToFire = 0f;

    void Start () 
    {
      
        currentAmmo = maxAmmo;
    }

    void OnEnable() 
    {
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
     

        if (isAuto == true){
             if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
             {
                nextTimeToFire = Time.time + 1f/fireRate;
                Build();
                if(type == "tool") {
                                 animator.GetComponent<Animator>().Play("AttackTool");
                                 Debug.Log("AttackToolAnimTriggered");
                             }  
                           if(type == "gun") {
                               animator.GetComponent<Animator>().Play("AttackGun");
                               Debug.Log("AttackGunAnimTriggered");
                           } 
                
                Debug.Log("pow pow");
            } 
        }else {
                    if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) 
                        {
                            nextTimeToFire = Time.time + 1f/fireRate;
                            Build();
                           if(type == "tool") {
                                 animator.GetComponent<Animator>().Play("AttackTool");
                                 Debug.Log("AttackToolAnimTriggered");
                             }  
                           if(type == "gun") {
                               animator.GetComponent<Animator>().Play("AttackGun");
                               Debug.Log("AttackGunAnimTriggered");
                           }  
                            Debug.Log("pow pow2");
                        }
                    }

    }

    //coroutine
  
    

    void Build () 
    {


        if(Physics.Raycast(fpsCam.position, fpsCam.forward, out RaycastHit hitInfo))
        {

            if(hitInfo.transform.tag == "Block")
            {   
                Debug.Log("Hit1: " + hitInfo.collider.gameObject.name);
                Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hitInfo.point.x + hitInfo.normal.x/2), Mathf.RoundToInt(hitInfo.point.y + hitInfo.normal.y/2), Mathf.RoundToInt(hitInfo.point.z + hitInfo.normal.z/2));
                Instantiate(floor, spawnPosition, Quaternion.identity);
            }else
            {
                 Debug.Log("Hit2: " + hitInfo.collider.gameObject.name);
                Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hitInfo.point.x), Mathf.RoundToInt(hitInfo.point.y), Mathf.RoundToInt(hitInfo.point.z));
                Instantiate(floor, spawnPosition, Quaternion.identity);
            }

        }

  
}
}

