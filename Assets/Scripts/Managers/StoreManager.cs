using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance = null;

    public int UnitsInStore = 3;

    public GameObject SellButton = null;

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

    void Start(){
        ShowNewUnitsInStore();
    }

    public void EmptyStore(){
        for(int i = 0; i < transform.childCount; i++){
            Transform t = transform.GetChild(i);
            if(t.childCount > 0){
                Destroy(t.GetChild(0).gameObject);
            }
        }
    }

    public void ShowNewUnitsInStore(){
        EmptyStore();

        GameObject obj = null;
        for(int i = 0; i < transform.childCount; i++){
            Transform t = transform.GetChild(i);
            obj = Instantiate(UnitListManager.instance.iconsList[Random.Range(0, UnitListManager.instance.iconsList.Length)], t);
            obj.GetComponent<UnitIndexes>().storeIndex = i;
            obj.GetComponent<AddBehaviourToIconButton>().AddBuyBehaviour();
        }
    }
    public void BuyUnit(int index){
        Transform IconTransform = transform.GetChild(index).GetChild(0); 
        UnitIndexes icon = IconTransform.GetComponent<UnitIndexes>(); 
        BenchManager.instance.AddUnitToBench(IconTransform);

        MoneyManager.instance.UpdateMoney(-UnitListManager.instance.attributesList[icon.unitIndex].cost);
    
    }

    public void SellUnit(){
        GameObject obj = SelectedUnit.instance.selectedObject;
        UnitIndexes unit = obj.GetComponent<UnitIndexes>();
        BenchManager.instance.RemoveUnitFromBench(unit.benchIndex);

        MoneyManager.instance.UpdateMoney(UnitListManager.instance.attributesList[unit.unitIndex].cost);
        SelectedUnit.instance.DeselectUnit();
    }

    public void ToggleSellButtonShow(bool show){
        SellButton.SetActive(show);
    }
}
