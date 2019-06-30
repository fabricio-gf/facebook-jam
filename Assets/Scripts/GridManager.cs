using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridManager : MonoBehaviour {
    GridLayoutGroup grid;
    [SerializeField] int rows;
    [SerializeField] int columns;

    // Start is called before the first frame update
    void Start() {
        grid = GetComponent<GridLayoutGroup>();
        columns = grid.constraintCount;
        rows = Mathf.FloorToInt(transform.childCount / columns);
        for (int i = 0; i < transform.childCount; i++) {
            Debug.Log(transform.GetChild(i).name + " pos " + Vet2Grid(i));
        }
    }

    // Update is called once per frame
    void Update() {

    }

    int Grid2Vet(Vector2Int gridPosition) {
        return Grid2Vet(gridPosition.x, gridPosition.y);
    }


    int Grid2Vet(int colum, int row) {
        if (row >= 0 && row < rows && colum >= 0 && colum < columns) {
            return row * columns + colum;
        }
        Debug.LogError("ERRO!, tentando andar para posição row = " + row + " colum = " + colum + " Matriz: " + columns + "x" + rows);
        return -1;
    }

    Vector2Int Vet2Grid(int pos) {
        if (pos < rows * columns) {
            int row = Mathf.FloorToInt(pos / columns);
            int colum = Mathf.FloorToInt(pos % columns);
            return new Vector2Int(colum, row);
        }
        Debug.LogError("Erro, querendo acessar a pos " + pos + " rows = " + rows + " colums = " + columns);
        return new Vector2Int(-1, -1);
    }

    public static int ManhattanDistance(Vector2Int origin, Vector2Int destination) {
        return Mathf.Abs(destination.x - origin.x) + Mathf.Abs(destination.y - origin.y);
    }

    public Vector2Int[] AStar(Vector2Int origin, Vector2Int destination) {
        Debug.Log("to be implemented");
        return null;
    }

    Transform GetTileByPosition(Vector2Int pos) {
        return transform.GetChild(Grid2Vet(pos));
    }

    public Transform NextTile(Transform originTile, Transform destinationTile) {
        Vector3 dir = destinationTile.position - originTile.position;
        if (Mathf.Abs(dir.y) >  Mathf.Abs(dir.x)) {
            dir.x = 0f;
        } else {
            dir.y = 0f;
        }
        dir.Normalize();
        Vector2Int dirInt = new Vector2Int((int)dir.x, (int)dir.y);
        //Debug.Log("Proxima tile ta pra dir:" + dirInt);

        Vector2Int posGrid = Vet2Grid(originTile.GetSiblingIndex());
        //Debug.Log("tile atual: "+ originTile.name+" na pos " + posGrid + " nova tile: " + GetTileByPosition(posGrid + dirInt).name + " na pos " + posGrid + dirInt);
        return GetTileByPosition(posGrid + dirInt);
    }

}
