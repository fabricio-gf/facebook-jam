using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int initialEnemyNumber = 2;
    public int currentWave = 0;

    public GameObject[] enemies;

    public Transform[] tiles;
    List<Transform> freeTiles = new List<Transform>();

    void Start(){
        SpawnWave();
        
    }

    public void SpawnWave(){
        freeTiles.Clear();
        freeTiles.AddRange(tiles);
        int randomIndex = 0;
        GameObject obj = null;
        for(int i = 0; i < initialEnemyNumber + Mathf.FloorToInt(Mathf.Pow(currentWave, (1f/3f))); i++){
            randomIndex = Random.Range(0, freeTiles.Count);
            obj = Instantiate(enemies[Random.Range(0, enemies.Length)], freeTiles[randomIndex]);
            freeTiles.RemoveAt(randomIndex);
        }

    }

    public void StartWave(){
        CountDown.instance.StartRoundCountdown();
        //start unit behaviours
        currentWave++;
    }
}
