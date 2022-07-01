using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Interactable : MonoBehaviour
{
    public float radius = 5f;
    public Transform interactionTransform;
	public GameObject thisObject;
	Outline outline;
	PlayerMovement playerMovement;
	public bool InInteractRange;
	[SerializeField]LayerMask PlayerLayer;
	[SerializeField]Color AtiveColor;
	[SerializeField]Color UnactiveColor;

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;


	void Start()
	{
		
	}

    public virtual void Interact ()
	{
		// This method is meant to be overwritten
		Debug.Log("Interacting with " + transform.name);
	}

    void OnDrawGizmosSelected ()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    void Update ()
	{

	//Outline Checker
	InInteractRange = Physics.CheckSphere(transform.position, radius, PlayerLayer);
	if(InInteractRange)
	{	
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			outline = thisObject.GetComponent<Outline>();
			outline.OutlineColor = AtiveColor;
		} else
		{
			outline = thisObject.GetComponent<Outline>();
			outline.OutlineColor = UnactiveColor;
		}
	
	
	}else
		{
			outline = thisObject.GetComponent<Outline>();
			outline.OutlineColor = UnactiveColor;
		}
		


		// If we are currently being focused
		// and we haven't already interacted with the object
		if (isFocus && !hasInteracted)
		{
			// If we are close enough
				float distance = Vector3.Distance(player.position, interactionTransform.position);
			if (distance <= radius)
			{
				// Interact with the object
				Interact();
				hasInteracted = true;	
			}
		} else {
			OnDefocused();
		}
	}

    // Called when the object starts being focused
	public void OnFocused (Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	// Called when the object is no longer focused
	public void OnDefocused ()
	{
		isFocus = false;
		player = null;
		hasInteracted = false;
	}

}
