using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public static EndManager instance = null;
    public GameObject DefeatWindow = null;
    public GameObject VictoryWindow = null;

    void Awake(){
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void TriggerDefeat(){
        Time.timeScale = 0;
        DefeatWindow.SetActive(true);
    }

    public void TriggerVictory(){
        VictoryWindow.SetActive(true);
    }
}
