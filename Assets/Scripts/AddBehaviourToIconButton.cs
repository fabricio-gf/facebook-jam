using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBehaviourToIconButton : MonoBehaviour
{
    UnitIcon icon = null;
    Button thisButton = null;
    void Awake(){
        icon = GetComponent<UnitIcon>();
        thisButton = GetComponent<Button>();
    }

    public void AddBehaviour(){
        thisButton.onClick.AddListener(() => StoreManager.instance.BuyUnit(icon.storeIndex));
    }
}
