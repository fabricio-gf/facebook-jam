using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public static CountDown instance = null;
    public int totalSteps = 3;
    public int currentStep = 0;
    public float stepDuration = 0.5f;
    float currentTime = 0;

    public GameObject countdown = null;
    Text countdownText;

    public string[] countdownStrings = null;
    Queue<string> countdownQueue = new Queue<string>();

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

        countdownText = countdown.GetComponent<Text>();
    }
    public void StartRoundCountdown(){
        countdownQueue.Clear();
        for(int i = 0; i < countdownStrings.Length; i++){
            countdownQueue.Enqueue(countdownStrings[i]);
        }
        StartCoroutine(Step());
    }

    public IEnumerator Step(){
        while(currentTime < stepDuration){
            currentTime += Time.deltaTime;
            yield return null;
        }
        currentTime = 0;
        if(currentStep == totalSteps){
            countdown.SetActive(false);
        }
        else{
            countdownText.text = countdownQueue.Dequeue();
            currentStep++;
            StartCoroutine(Step());
        }
    }
}
