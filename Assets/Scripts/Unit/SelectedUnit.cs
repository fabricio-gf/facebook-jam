using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnit : MonoBehaviour
{
    public static SelectedUnit instance = null;

    public GameObject selectedObject = null;
    public Unit unit = null;

    private void Awake()
    {
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

    public void SelectUnit(GameObject obj){
        selectedObject = obj;
        unit = obj.GetComponent<Unit>();
        StoreManager.instance.ToggleSellButtonShow(true);
    }

    public void DeselectUnit(){
        selectedObject = null;
        unit = null;
        StoreManager.instance.ToggleSellButtonShow(false);
    }
}
