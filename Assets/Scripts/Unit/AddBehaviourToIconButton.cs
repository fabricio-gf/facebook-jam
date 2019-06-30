using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBehaviourToIconButton : MonoBehaviour
{
    public bool SelectParent;
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
        if(SelectParent){
            thisButton.onClick.AddListener(() => SelectedUnit.instance.SelectUnit(transform.parent.gameObject));
        }
        else{
            print("select behaviour");
            thisButton.onClick.AddListener(() => SelectedUnit.instance.SelectUnit(gameObject));
        }
    }
}
