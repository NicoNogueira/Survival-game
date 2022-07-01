using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float fragileDamage;
    public float stoneDamage;
    public float woodDamage;
    public float metalDamage;
    public float range = 100f;
    public float fireRate = 15f;
    public bool isAuto;
    public string type;
    public int GunID;
    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public bool AddBulletSpread;
    public int shotgunSpread = 1;
    public Transform BulletOrigin;
    public Vector3 BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
    public ParticleSystem ImpactParticleSystem;
    public TrailRenderer BulletTrail;


    public Animator animator;

    public Transform fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitmarker;

    private float nextTimeToFire = 0f;

    void Start () 
    {
        
      
        
    
  
      if(BulletOrigin == null)
      {
        BulletOrigin = fpsCam;
      }
        hitmarker.SetActive(false);
        currentAmmo = maxAmmo;
    }

    void OnEnable() 
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {

         animator.SetInteger("GunID", GunID);
        if(Input.GetKeyDown(KeyCode.R) == true)
        {
            if(currentAmmo != maxAmmo) 
            {
                 StartCoroutine(Reload());
            }
           
        }

        if (isReloading)
        return;

        if (currentAmmo <= 0)
        {
            
            StartCoroutine(Reload());
         
            return;
        }

        if (isAuto == true){
             if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
             {
                nextTimeToFire = Time.time + 1f/fireRate;
                Shoot();
                if(type == "tool") {
                                 animator.GetComponent<Animator>().Play("AttackAxe");
                                 Debug.Log("AttackToolAnimTriggered");
                             }  
                           if(type == "gun") {
                              animator.SetBool("isAttacking", true);
                               Debug.Log("AttackGunAnimTriggered");
                           } 
                
                Debug.Log("pow pow");
            } 
        }else {
                    if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) 
                        {
                            nextTimeToFire = Time.time + 1f/fireRate;
                            Shoot();
                           if(type == "tool") {
                                 animator.GetComponent<Animator>().Play("AttackAxe");
                                 Debug.Log("AttackToolAnimTriggered");
                             }  
                           if(type == "gun") {
                               animator.SetBool("isAttacking", true);
                               Debug.Log("AttackGunAnimTriggered");
                           }  
                            Debug.Log("pow pow2");
                        }
                    }

    }

    //coroutine
    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);
        
        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

         yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;


         isReloading = false;

    }

    void Shoot () 
    {
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        
        for (int i = 0; i < shotgunSpread; i++)
        {
            Vector3 direction = GetDirection();
           if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range))
        {
            
            if(BulletTrail != null){
                TrailRenderer trail = Instantiate(BulletTrail, BulletOrigin.position, Quaternion.identity);  
                StartCoroutine(SpawnTrail(trail, hit));
            Debug.Log(hit.transform.name);
            }
            

                WoodTarget woodTarget = hit.transform.GetComponent<WoodTarget>();
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    
                    target.TakeDamage(damage);
                    HitActive();
                    StartCoroutine(HitDisable(0.4f));
                } 
                
    
                if (woodTarget != null)
                {
                    
                    if ( woodTarget.resistance == 0)
                    {
                        if(fragileDamage > 0)
                        {
                            woodTarget.TakeDamage(fragileDamage);
                            HitActive();
                            StartCoroutine(HitDisable(0.4f));
                            
                    
                        }
                        
                
                    } else if ( woodTarget.resistance == 1)
                    {
                        if(woodDamage > 0)
                        {
                            woodTarget.TakeDamage(woodDamage);
                            HitActive();
                            StartCoroutine(HitDisable(0.4f));
                            
                        
                
                        }
                    
                    }else if ( woodTarget.resistance == 2)
                    {
                        if(stoneDamage > 0)
                        {
                        woodTarget.TakeDamage(stoneDamage);
                        HitActive();
                        StartCoroutine(HitDisable(0.4f));
                        
                
                        }
                
                    }else if ( woodTarget.resistance == 3)
                    {
                        if(metalDamage > 0)
                        {
                        woodTarget.TakeDamage(metalDamage);
                        HitActive();
                        StartCoroutine(HitDisable(0.4f));
                        
                    
                        }               
                    }
                } 

            }  
        }
       
                          
            
    }
         
    
    //Hitmarker
     void HitActive()
    {
        hitmarker.SetActive(true);
    }
   IEnumerator HitDisable(float f)
     {
         yield return new WaitForSeconds(f);
           hitmarker.SetActive(false);
     }
   //Hitmarker

    private Vector3 GetDirection()
    {
        Vector3 direction = fpsCam.forward;

        if (AddBulletSpread)
        {
            direction += new Vector3(
                Random.Range(-BulletSpreadVariance.x, BulletSpreadVariance.x),
                Random.Range(-BulletSpreadVariance.y, BulletSpreadVariance.y),
                Random.Range(-BulletSpreadVariance.z, BulletSpreadVariance.z)
            );

            direction.Normalize();
        }

        return direction;
    }


    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while(time<1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = Hit.point;
        // ParticleSystem hitEffect;
  Instantiate(ImpactParticleSystem, Hit.point, Quaternion.LookRotation(Hit.normal));
        // Destroy(hitEffect, 1);
        Destroy(Trail.gameObject, Trail.time); 

 
        
     
       
    }

      
}
 
