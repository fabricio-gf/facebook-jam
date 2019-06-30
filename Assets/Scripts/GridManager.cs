using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridManager : MonoBehaviour {
    GridLayoutGroup grid;
    [SerializeField] int rows = 8;
    [SerializeField] int columns = 5;

    // Start is called before the first frame update
    void Start() {
        grid = GetComponent<GridLayoutGroup>();
        columns = grid.constraintCount;
        rows = Mathf.FloorToInt(transform.childCount / columns);
        for (int i = 0; i < transform.childCount; i++) {
            //Debug.Log(transform.GetChild(i).name + " pos " + Vet2Grid(i));
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
        //Debug.LogError("ERRO!, tentando andar para posição row = " + row + " colum = " + colum + " Matriz: " + columns + "x" + rows);
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

    public int ManhattanDistance(Transform originTransform, Transform destinationTransform) {
       // Debug.Log(originTransform.name +" distancia " + ManhattanDistance(Vet2Grid(originTransform.GetSiblingIndex()), Vet2Grid(destinationTransform.GetSiblingIndex())) +"de " + destinationTransform.name);
        return ManhattanDistance(Vet2Grid(originTransform.GetSiblingIndex()), Vet2Grid(destinationTransform.GetSiblingIndex()));
    }

    public Vector2Int[] AStar(Vector2Int origin, Vector2Int destination) {
        Debug.Log("to be implemented");
        return null;
    }

    Transform GetTileByPosition(Vector2Int pos) {
        //Debug.Log("grid : " + pos + " sibling: " + Grid2Vet(pos));
        int childIndex = Grid2Vet(pos);
        if (childIndex >=0 && childIndex < transform.childCount) {
            return transform.GetChild(childIndex);
        }
        return null;
    }

    public Transform NextTile(Transform originTile, Vector2Int direction) {
        Vector2Int posGrid = Vet2Grid(originTile.GetSiblingIndex());
        Transform tile = GetTileByPosition(posGrid + direction);
        if (tile != null && tile.childCount == 0) {
            return tile;
        }
        return null;
    }

    public Transform NextTile(Transform originTile, Transform destinationTile) { 
        Vector2Int posGrid = Vet2Grid(originTile.GetSiblingIndex());

        Transform tile;

        Vector3 dirx = destinationTile.position - originTile.position;
        dirx.y = 0;
        dirx.Normalize();

        Vector3 diry = destinationTile.position - originTile.position;
        diry.x = 0;
        diry.Normalize();

        Vector2Int dirInt;

        if (Mathf.Abs(diry.y) > Mathf.Abs(dirx.x)) {
            dirInt = new Vector2Int(0, (int)diry.y);
            tile = GetTileByPosition(posGrid + dirInt);
            if (tile != null && tile.childCount == 0) {
                return tile;
            }
            dirInt = new Vector2Int((int)dirx.x, 0);
            tile = GetTileByPosition(posGrid + dirInt);
            if (tile != null && tile.childCount == 0) {
                return tile;
            }
        } else {
            dirInt = new Vector2Int((int)dirx.x, 0);
            tile = GetTileByPosition(posGrid + dirInt);
            if (tile != null && tile.childCount == 0) {
                return tile;
            }
            dirInt = new Vector2Int(0, (int)diry.y);
            tile = GetTileByPosition(posGrid + dirInt);
            if (tile != null && tile.childCount == 0) {
                return tile;
            }
        }   
       
       
        /*
        dirInt = new Vector2Int(0, (int)(-diry.y));
        tile = GetTileByPosition(posGrid + dirInt);
        if (tile.childCount == 0) {
            return tile;
        }

        dirx.Normalize();
        dirInt = new Vector2Int((int)(-dirx.x), 0);
        tile = GetTileByPosition(posGrid + dirInt);
        if (tile.childCount == 0) {
            return tile;
        }
        */
        return null;
    }
    
}
