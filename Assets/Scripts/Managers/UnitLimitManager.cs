using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitLimitManager : MonoBehaviour
{
    public static UnitLimitManager instance = null;

    public int Limit = 0;
    public int CurrentUnits = 0;
    public Text UnitLimitText = null;

    private void Awake()
    {
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

    public void UpdateLimit(int change)
    {
        if(CurrentUnits + change > Limit){
            //too many units
        }
        else{
            CurrentUnits += change;
            UnitLimitText.text = CurrentUnits.ToString();
        }
    }
}
