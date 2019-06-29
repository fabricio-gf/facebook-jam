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

    public void AddUnitToBench(int index){
        if(benchCount == transform.childCount){
            //bench full

        }
        
        else{ 
            for(int i = 0; i < transform.childCount; i++){
                Transform t = transform.GetChild(i);
                if(t.childCount == 0){
                    GameObject obj = Instantiate(UnitListManager.instance.iconsList[index], t);
                    benchCount++;
                    return;
                }
            }
        }

    }

    public void RemoveUnitFromBench(int index){
        Destroy(transform.GetChild(index)?.GetChild(0));
        benchCount --;
    }
}
