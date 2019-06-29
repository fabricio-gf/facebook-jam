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
    
    public void AddUnit(){
        if(IsLessThanLimit()){
            CurrentUnits ++;
            UnitLimitText.text = CurrentUnits.ToString();
        }
        else{
            //full
        }
    }

    public void RemoveUnit(){
        if(CurrentUnits > 0){
            CurrentUnits --;
            UnitLimitText.text = CurrentUnits.ToString();
        }
        else{
            //empty
        }
    }

    public bool IsLessThanLimit(){
        if(CurrentUnits < Limit){
            return true;
        }
        else return false;
    }
}
