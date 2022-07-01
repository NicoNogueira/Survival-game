using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoText : MonoBehaviour
{
   
   
    public TextMeshProUGUI textDisplay;
    private int currentAmmo1;

    Gun gunScript;

    void Start()
    {
        chooseGun();
    }

    public void chooseGun() 
    {
        Debug.Log("ChooseGunActive");
        if(GameObject.FindGameObjectWithTag("Weapon").activeSelf) {
            gunScript = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Gun>();
            Debug.Log("Selecting New Ammo: "+ gunScript);
        }
        
    }

    public void teste() 
    {
        Debug.Log("teste");
    }

    void Update()
    {
        if(!gunScript)
            currentAmmo1 = gunScript.currentAmmo;
        
            currentAmmo1.ToString();
            textDisplay.SetText(currentAmmo1.ToString());
    }
}
