using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBehaviourToIconButton : MonoBehaviour
{
    UnitIndexes icon = null;
    Button thisButton = null;
    void Awake(){
        icon = GetComponent<UnitIndexes>();
        thisButton = GetComponent<Button>();
    }

    public void AddBuyBehaviour(){
        thisButton.onClick.AddListener(() => StoreManager.instance.BuyUnit(icon.storeIndex));
    }

    public void RemoveBehaviours(){
        thisButton.onClick.RemoveAllListeners();
    }

    public void AddSelectBehaviour(){
        RemoveBehaviours();
        thisButton.onClick.AddListener(() => SelectedUnit.instance.SelectUnit(gameObject));
    }
}
