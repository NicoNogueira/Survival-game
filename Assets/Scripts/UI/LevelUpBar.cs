using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpBar : MonoBehaviour
{

  
   public Slider LevelBar;
   LevelUp levelUp;

    void Start()
    {
        levelUp = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelUp>();

    }

    
    void Update()
    {
        LevelBar.value = levelUp.currentXP;
        LevelBar.maxValue = levelUp.maxXP;
    }
}
