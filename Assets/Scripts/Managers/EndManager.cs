using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    
    public GameObject DefeatWindow = null;
    public GameObject VictoryWindow = null;

    public void TriggerDefeat(){
        DefeatWindow.SetActive(true);
    }

    public void TriggerVictory(){
        VictoryWindow.SetActive(true);
    }
}
