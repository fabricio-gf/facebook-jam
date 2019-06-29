using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceUnit : MonoBehaviour
{
    public bool isMap = false;
    public bool isBench = false;

    public void Interact(){
        GameObject obj = SelectedUnit.instance.selectedObject;
        Unit unit = SelectedUnit.instance.unit;
        if(isBench){
            if(unit.inBench){
                if(obj != null){
                    obj.transform.SetParent(transform);
                    obj.transform.position = transform.position;
                }
            }
            else{
                // delete object
                //create icon
                UnitLimitManager.instance.RemoveUnit();
            }
        }
        else if(isMap){
            if(!unit.inBench){
                //set position
            }
            else{
                if(UnitLimitManager.instance.IsLessThanLimit()){
                    //delete icon
                    //create object
                    UnitLimitManager.instance.AddUnit();
                }
            }
        }
    }
}
