using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   
    public Text score;



    void Start()
    {
        score.text = ("Score: " + 0);
    }


    void Update()
    {
        
    }

    public int newScore;
    public void AddScore(int a)
    {
       
        newScore += a;
        Debug.Log("Updating Score to " + newScore);
       score.text = ("Score: " + newScore);
    }
}
