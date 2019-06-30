using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchManager : MonoBehaviour
{
    public static BenchManager instance = null;

    public int benchCount = 0;
    public void Awake(){
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

    public void EmptyBench(){
        for(int i = 0; i < transform.childCount; i++){
            Transform t = transform.GetChild(i);
            if(t.childCount > 0){
                Destroy(t.GetChild(0).gameObject);
            }
        }
        benchCount = 0;
    }

    public void AddUnitToBench(Transform icon, int index = -1){
        if(benchCount == transform.childCount){
            //bench full

        }
        
        else{
            if(index > -1) {
                Transform t = transform.GetChild(index);
                icon.SetParent(t);
                icon.position = t.position;
                icon.GetComponent<AddBehaviourToIconButton>().AddSelectBehaviour();
                icon.GetComponent<UnitIndexes>().benchIndex = index;
                icon.GetComponent<Unit>().inBench = true;
                print(icon.GetComponent<Unit>().inBench);
                benchCount++;
                return;
            }
            else{
                for(int i = 0; i < transform.childCount; i++){
                    Transform t = transform.GetChild(i);
                    if(t.childCount == 0){
                        icon.SetParent(t);
                        icon.position = t.position;
                        icon.GetComponent<AddBehaviourToIconButton>().AddSelectBehaviour();
                        icon.GetComponent<UnitIndexes>().benchIndex = i;
                        icon.GetComponent<Unit>().inBench = true;
                        benchCount++;
                        return;
                    }
                }
            }
        }

    }

    public void RemoveUnitFromBench(int index){
        Destroy(transform.GetChild(index)?.GetChild(0).gameObject);
        benchCount --;
    }
}
