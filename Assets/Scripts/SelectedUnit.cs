using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnit : MonoBehaviour
{
    public static SelectedUnit instance = null;

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
