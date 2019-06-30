using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance = null;
    public int initialEnemyNumber = 2;
    public int currentWave = 0;

    public GameObject[] enemies;

    public Transform[] tiles;
    List<Transform> freeTiles = new List<Transform>();

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

    public void SpawnWave(){
        freeTiles.Clear();
        freeTiles.AddRange(tiles);
        int randomIndex = 0;
        GameObject obj = null;
        int numberOfEnemies = initialEnemyNumber + Mathf.FloorToInt(Mathf.Pow(currentWave, (1f/3f)));
        for(int i = 0; i < numberOfEnemies; i++){
            randomIndex = Random.Range(0, freeTiles.Count);
            obj = Instantiate(enemies[Random.Range(0, enemies.Length)], freeTiles[randomIndex]);
            freeTiles.RemoveAt(randomIndex);
        }
        UnitLimitManager.instance.SetNumberOfEnemies(numberOfEnemies);
    }

    public void StartWave(){
        Unidade[] units = FindObjectsOfType<Unidade>();
        for(int i = 0; i < units.Length; i++){
            units[i].StartFight();
        }
        currentWave++;
    }
}
