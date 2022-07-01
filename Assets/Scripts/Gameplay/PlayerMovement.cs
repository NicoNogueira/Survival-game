using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
   
    public Interactable focus;

    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.91f;

    public float dashMultiplier = 2f;

    public Camera fpsCam;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask; 

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }
        if(Input.GetButtonDown("Dash"))
        {
            Debug.Log("Dash");
            controller.Move(move * speed * Time.deltaTime * dashMultiplier);
            
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



    //Interacting


        if(Input.GetButtonDown("Interact"))
        {
            Debug.Log("Interacting");
            Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 5.9f))
                {
                 Interactable interactable = hit.collider.GetComponent<Interactable>();
                 if(interactable != null)
                 {
                    SetFocus(interactable);
                 }
                }
        }
        if(Input.GetButtonDown("Inventory"))
        {
             Debug.Log("Interacting closed");
             RemoveFocus();
        }
       

    }

    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();

                focus = newFocus;
               
        }

    newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
       if(focus != null)
        focus.OnDefocused();

        focus = null;
        
    }

    //Interacting
}
