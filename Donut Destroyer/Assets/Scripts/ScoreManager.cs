using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int levelValue = 1;

    //Text Level;
    TMP_Text Level;

    void Start()
    {
        Level = GetComponent<TMP_Text>();
        
    }

    void Update()
    {
        Level.text = "Level: " + levelValue;
    }
}
