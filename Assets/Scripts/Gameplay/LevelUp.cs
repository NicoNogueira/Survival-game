using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUp : MonoBehaviour
{

    public int maxXP;
    public int currentXP;
    public int maxLevel;
    public int currentLevel;
     public TextMeshProUGUI textDisplay;
     public int XPCheat;



    void Start()
    {
        
    }

 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            AddXP(XPCheat);
            Debug.Log("XP added");
        }

        if(currentXP >= maxXP)
        {
            if(currentLevel < maxLevel)
            {
                AddLevel();
                currentXP = currentXP - maxXP;
                maxXP = maxXP*currentLevel;
            }
            
        }
    }

    public void AddXP(int amount)
    {
        Debug.Log("XP ADDED");
        currentXP += amount;
    }

    public void AddLevel()
    {
        currentLevel++;
        textDisplay.SetText(currentLevel.ToString());
    }
}
