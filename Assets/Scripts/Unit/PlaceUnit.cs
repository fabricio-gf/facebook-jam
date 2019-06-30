using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceUnit : MonoBehaviour
{
    public bool isMap = false;
    public bool isBench = false;

    GameObject newObj;
    public void Interact(){
        GameObject obj = SelectedUnit.instance.selectedObject;
        Unit unit = SelectedUnit.instance.unit;
        if(unit == null){
            return;
        }
        if(isBench){
            if(unit.inBench){
                if(obj != null){
                    obj.transform.SetParent(transform);
                    obj.transform.position = transform.position;
                    SelectedUnit.instance.DeselectUnit();
                }
            }
            else{
                int index = unit.GetComponent<UnitIndexes>().unitIndex;
                newObj = Instantiate(UnitListManager.instance.iconsList[index], transform);
                BenchManager.instance.AddUnitToBench(newObj.transform, transform.GetSiblingIndex());
                UnitLimitManager.instance.RemoveUnit(obj, obj.transform);
                Destroy(obj);
                SelectedUnit.instance.DeselectUnit();
            }
        }
        else if(isMap){
            if(!unit.inBench){
                obj.transform.SetParent(transform);
                obj.transform.position = transform.position;
                SelectedUnit.instance.DeselectUnit();
            }
            else{
                if(UnitLimitManager.instance.IsLessThanLimit()){
                    int index = unit.GetComponent<UnitIndexes>().unitIndex;
                    newObj = Instantiate(UnitListManager.instance.unitsList[index], transform);
                    newObj.transform.GetChild(1).GetComponent<AddBehaviourToIconButton>().AddSelectBehaviour();
                    UnitLimitManager.instance.AddUnit(newObj, transform);
                    Destroy(unit.gameObject);
                    SelectedUnit.instance.DeselectUnit();
                }
            }
        }
    }
}
