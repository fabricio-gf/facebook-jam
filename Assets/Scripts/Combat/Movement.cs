using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Movement : MonoBehaviour{
    bool isMoving;
    Unidade Unidade;
    GridManager grid;
    // Start is called before the first frame update
    void Start() {
        Unidade = GetComponent<Unidade>();
        grid = FindObjectOfType<GridManager>();
    }

    // Update is called once per frame
    void Update() {

        if (isMoving) {
            if (Vector2.Distance(transform.position, transform.parent.position) > 0.1f) {
                transform.position = Vector2.MoveTowards(transform.position, transform.parent.position, Unidade.MovementSpeed * Time.deltaTime);
                //Debug.Log("Andando para " + transform.parent.name);
            } else {
                transform.localPosition = Vector3.zero;
                isMoving = false;
            }
        }

    }

    public bool MoveTowards(Transform target) {
        if (!isMoving) {
            Transform newParent = grid.NextTile(transform.parent, target.parent);
            if (newParent != null && newParent.childCount == 0) {
                transform.SetParent(newParent);
                //Debug.Log("Agora andando para o " + newParent.name);
                isMoving = true;
                return true;
            }
        }
        return false;
    }
}
