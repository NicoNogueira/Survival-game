using UnityEngine;
using UnityEngine.UI;


public class WeaponWheelController : MonoBehaviour
{
    public Animator anim;
    private bool weaponWheelSelected = false;
    public Sprite noImage;
    public static int weaponID;
    public GameObject buttonHolder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Q))
       {

        Debug.Log("Wheel Opening");
         weaponWheelSelected = !weaponWheelSelected;



         if(weaponWheelSelected)
         {
            buttonHolder.gameObject.SetActive(true);
            anim.SetBool("OpenWeaponWheel", true);
         }
         else
         {
            buttonHolder.gameObject.SetActive(false);
            anim.SetBool("OpenWeaponWheel", false);
         }
         switch (weaponID)
         {
            case 0: //nothing selected
            Debug.Log("nothing");
                break;
            case 1: //nothing selected
            Debug.Log("1");
                break;
            case 2: 
            Debug.Log("2");
                break;
            case 3: 
            Debug.Log("3");
                break;
            case 4: 
            Debug.Log("4");
                break;
            case 5: 
            Debug.Log("5");
                break;
            case 6: 
            Debug.Log("6");
                break;
            case 7: 
            Debug.Log("7");
                break;
            case 8: 
            Debug.Log("8");
                break;
            case 9: 
            Debug.Log("9");
                break;
           
         }
       if(Cursor.visible ==true)
        {
           
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;

        } else
        {
            
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;

        }
        
       }
    }
}
