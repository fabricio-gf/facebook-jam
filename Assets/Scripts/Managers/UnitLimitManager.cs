using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitLimitManager : MonoBehaviour
{
    public static UnitLimitManager instance = null;

    public int Limit = 0;
    public int CurrentUnits = 0;
    public Text UnitLimitText = null;

    public Button nextWaveButton = null;

    public List<int> unitsIndexes = new List<int>();
    public List<GameObject> playerUnitsList = new List<GameObject>();
    public List<Transform> playerUnitsTileList = new List<Transform>();
    int numberOfPlayerUnits;
    int numberOfEnemies;

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
    
    public void AddUnit(GameObject unit, Transform tile){
        if(IsLessThanLimit()){
            if(CurrentUnits==0) nextWaveButton.interactable = true;
            CurrentUnits ++;
            numberOfPlayerUnits = CurrentUnits;
            UnitLimitText.text = CurrentUnits.ToString() + "/" + Limit.ToString();

            unitsIndexes.Add(unit.GetComponent<UnitIndexes>().unitIndex);
            playerUnitsList.Add(unit);
            playerUnitsTileList.Add(tile);
            print("number of players " + numberOfPlayerUnits);
        }
        else{
            //full
        }
    }

    public void RemoveUnit(GameObject unit, Transform tile){
        if(CurrentUnits > 0){
            if(CurrentUnits == 1) nextWaveButton.interactable = false;
            CurrentUnits --;
            numberOfPlayerUnits = CurrentUnits;
            UnitLimitText.text = CurrentUnits.ToString() + "/" + Limit.ToString();

            unitsIndexes.Remove(unit.GetComponent<UnitIndexes>().unitIndex);
            playerUnitsList.Remove(unit);
            playerUnitsTileList.Remove(tile);
            print("number of players " + numberOfPlayerUnits);
        }
        else{
            //empty
        }
    }

    public bool IsLessThanLimit(){
        if(CurrentUnits < Limit){
            return true;
        }
        else return false;
    }

    public void PlayerUnitDeath(){
        numberOfPlayerUnits--;
        if(numberOfPlayerUnits <= 0){
            print("defeat");
            EndManager.instance.TriggerDefeat();
        }
    }

    public void EnemyUnitDeath(){
        print("enemy death");
        numberOfEnemies--;
        if(numberOfEnemies <= 0){
            ResetPlayerUnits();
            WaveSpawner.instance.SpawnWave();
            GUIManager.instance.ShowPanel();
            nextWaveButton.enabled = true;
        }
    }

    public void ResetPlayerUnits(){
        GameObject newObj;
        GameObject[] prefabList = UnitListManager.instance.unitsList;
        for(int i = 0; i < playerUnitsList.Count; i++){
            newObj = Instantiate(prefabList[unitsIndexes[i]], playerUnitsTileList[i]);
            Destroy(playerUnitsList[i]);
            playerUnitsList[i] = newObj;
        }
    }

    public void SetNumberOfEnemies(int enemies){
        numberOfEnemies = enemies;
        print("number of enemies " + numberOfEnemies);
    }
}
