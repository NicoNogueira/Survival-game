using UnityEngine;

public class Target : MonoBehaviour
{
   
    public float health;
    public int XPAmout; 
    LevelUp levelUp;

  

    void Start() {
           levelUp = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelUp>();
    }
    public void TakeDamage(float amount)

    {
        health -= amount;
        Debug.Log("Health= " + health);
        if (health <= 0f)
        {  
            levelUp.AddXP(XPAmout);
            Die();
         }
    }

    void Die() 
    {
        Destroy(gameObject);
       
    }

  




}
