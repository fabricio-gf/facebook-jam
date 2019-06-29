using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitListManager : MonoBehaviour
{
    public static UnitListManager instance = null;

    public UnitAttributes[] attributesList = null;
    public GameObject[] iconsList = null;
    public GameObject[] unitsList = null;

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
    
}
