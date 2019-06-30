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
    Animator countdownAnimator = null;

    public string[] countdownStrings = null;
    Queue<string> countdownQueue = new Queue<string>();

    public Button nextWaveButton = null;

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
        countdownAnimator = countdown.GetComponent<Animator>();

        //test
        //StartRoundCountdown();
    }
    public void StartRoundCountdown(){
        nextWaveButton.enabled= false;
        countdownQueue.Clear();
        for(int i = 0; i < countdownStrings.Length; i++){
            countdownQueue.Enqueue(countdownStrings[i]);
            print("entrou");
        }
        StartCoroutine(Step());
    }

    public IEnumerator Step(){
        countdownText.text = countdownQueue.Dequeue();
        currentStep++;
        countdownAnimator.SetTrigger("Swipe");
        while(currentTime < stepDuration){
            //print(currentTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
        currentTime = 0;
        if(currentStep == totalSteps){
            WaveSpawner.instance.StartWave();
            countdown.SetActive(false);
        }
        else{
            StartCoroutine(Step());
        }
    }
}
