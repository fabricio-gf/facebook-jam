using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed;

    private Vector2 startPosition;
    Camera mainCamera;
    float limit;

    void Awake(){
        mainCamera = Camera.main;
        limit = mainCamera.orthographicSize*2;
    }
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, limit);
        transform.position = startPosition + Vector2.up * newPos;
    }
}