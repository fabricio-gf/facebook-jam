using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    private CurrentScene CurrentSceneScript;

    public Animator LoadingAnimator = null;
    public Animator LoadingAnimator2 = null;

    bool firstTime = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //DontDestroyOnLoad(LoadingAnimator.transform.parent.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            //Destroy(LoadingAnimator?.transform.parent.gameObject);
        }

        CurrentSceneScript = GetComponent<CurrentScene>();
        SceneManager.sceneLoaded += EndLoad; 
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadDelay(sceneName));
    }

    public void RestartCurrentScene()
    {
        StartCoroutine(RestartDelay());
    }

    IEnumerator LoadDelay(string sceneName){
        Time.timeScale = 1;
        LoadingAnimator.SetTrigger("StartLoad");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator RestartDelay(){
        Time.timeScale = 1;
        LoadingAnimator.SetTrigger("StartLoad");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(CurrentSceneScript.GetCurrentSceneIndex());
    }

    public void EndLoad(Scene scene, LoadSceneMode mode){
        LoadingAnimator = GameObject.Find("LoadingScreen1").GetComponent<Animator>();
        if(firstTime){
            firstTime = false;
        }
        else{
            LoadingAnimator2 = GameObject.Find("LoadingScreen2").GetComponent<Animator>();
            LoadingAnimator2.SetTrigger("EndLoad");
        }
    }
}
