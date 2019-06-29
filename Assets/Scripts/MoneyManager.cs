using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance = null;

    public int CurrentMoney = 0;
    public Text MoneyText = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMoney(int change)
    {
        CurrentMoney += change;
        MoneyText.text = CurrentMoney.ToString();
    }
}
