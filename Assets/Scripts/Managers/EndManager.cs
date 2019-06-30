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
        DefeatWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void TriggerVictory(){
        VictoryWindow.SetActive(true);
    }
}
