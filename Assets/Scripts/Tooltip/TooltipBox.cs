using UnityEngine;
using UnityEngine.UI;

public class TooltipBox : MonoBehaviour
{
    public static TooltipBox instance = null; 
    Camera mainCamera;
    Image thisImage;
    Text thisText;

    void Awake(){
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        
        mainCamera = Camera.main;
        thisImage = GetComponent<Image>();
    }
    void Update(){
#if UNITY_WINDOWS
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
#endif
    }

    public void EnableTooltip(Vector3 pos, string content){
#if UNITY_ANDROID
        transform.position = pos;
#endif
        thisText.text = content;
        thisImage.enabled = true;
        thisText.enabled = true;
    }
    
    public void DisableTooltip(){
        thisText.enabled = false;
        thisImage.enabled = false;
    }
}
