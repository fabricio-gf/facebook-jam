using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int initialEnemyNumber = 2;
    public int currentWave = 0;

    public Transform[] tiles;
    List<Transform> freeTiles = new List<Transform>();

    public void SpawnWave(){
        freeTiles.Clear();
        freeTiles.AddRange(tiles);
        int randomIndex = 0;
        for(int i = 0; i < initialEnemyNumber + Mathf.FloorToInt(Mathf.Pow(currentWave, (1f/3f))); i++){
            randomIndex = Random.Range(0, freeTiles.Count);
            //spawn at index;
            freeTiles.RemoveAt(randomIndex);
        }
    }
}
