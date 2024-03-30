using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartMaxScore : MonoBehaviour
{
    private GameData gameData;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        gameData= SaveSystem.Load(); 

		text.text= "MAX SCORE : "+gameData.maxScore.ToString();
    }

   
}
