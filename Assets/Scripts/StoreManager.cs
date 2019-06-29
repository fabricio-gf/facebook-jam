using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance = null;

    public int UnitsInStore = 3;

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
            obj.GetComponent<UnitIcon>().storeIndex = i;
            obj.GetComponent<AddBehaviourToIconButton>().AddBehaviour();
        }
    }
    public void BuyUnit(int index){
        Transform IconTransform = transform.GetChild(index).GetChild(0); 
        UnitIcon icon = IconTransform.GetComponent<UnitIcon>(); 
        BenchManager.instance.AddUnitToBench(icon.unitIndex);

        MoneyManager.instance.UpdateMoney(-UnitListManager.instance.attributesList[icon.unitIndex].cost);
        
        Destroy(transform.GetChild(index).GetChild(0).gameObject);
    }

    public void SellUnit(int index){
        //BenchManager.instance.RemoveUnitFromBench(index);

        MoneyManager.instance.UpdateMoney(UnitListManager.instance.attributesList[index].cost);
    }
}
