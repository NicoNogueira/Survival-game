using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseLook : MonoBehaviour

    
{
  

    public GameObject inventoryHud;
    public GameObject HealthSlider;
    public GameObject HungerSlider;
    public Transform healthBarPos;
    public Transform healthBarAlt;
    public Transform hungerBarPos;
    public Transform hungerBarAlt;
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
       inventoryHud.SetActive(false);
       Cursor.lockState = CursorLockMode.Locked; 
       Cursor.visible = false;
       HealthSlider.transform.position = healthBarPos.position;
       HungerSlider.transform.position = hungerBarPos.position;

    }

  
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        // if(EventSystem.current.IsPointerOverGameObject())
        //     return;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

       if(Input.GetButtonDown("Inventory"))
       {

        //Fechar Inventario
        if(Cursor.visible ==true)
        {
            inventoryHud.SetActive(false);
            
            HealthSlider.transform.position = healthBarPos.position;
             HungerSlider.transform.position = hungerBarPos.position;
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;

        } else //Abrir Inventario
        {
            inventoryHud.SetActive(true);
          HealthSlider.transform.position = healthBarAlt.position;
            HungerSlider.transform.position = hungerBarAlt.position;
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;

        }
        
       }



       
      
    }


    





}
