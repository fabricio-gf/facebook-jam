using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartScene : MonoBehaviour
{
    public float loadingDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        WaveSpawner.instance.SpawnWave();
        StartCoroutine(LoadingDelay());
    }

    IEnumerator LoadingDelay(){
        yield return new WaitForSeconds(loadingDelay);
        GUIManager.instance.ShowPanel();
    }
}
