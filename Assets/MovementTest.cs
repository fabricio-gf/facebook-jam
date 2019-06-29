using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour{
    [SerializeField]Transform target;
    GridManager grid;
    Rigidbody2D rigid;
    [SerializeField]float speed = 0.1f;

    bool isMoving;

    // Start is called before the first frame update
    void Start(){
        grid = FindObjectOfType<GridManager>();
        rigid = GetComponent<Rigidbody2D>();
        isMoving = true;   
    }
    
    // Update is called once per frame
    void Update(){

        if (isMoving) {
            if ( Vector2.Distance(transform.position, transform.parent.position) > 0.1f) {
                transform.position = Vector2.MoveTowards(transform.position, transform.parent.position, speed * Time.deltaTime);
                Debug.Log("Andando para " + transform.parent.name);
            } else {
                transform.localPosition = Vector3.zero;
                rigid.velocity = Vector3.zero;
                isMoving = false;
            }
        }
        MoveTo(target.position);

    }
    bool MoveTo(Vector3 destination) {
        if (!isMoving) {
            Transform newParent = grid.NextTile(transform.parent, target.parent);
            if (newParent != null && newParent.childCount == 0) {
                transform.SetParent(newParent);
                Debug.Log("Agora andando para o " + newParent.name);
                isMoving = true;
                return true;
            }
        }
        return false;
    }
}
