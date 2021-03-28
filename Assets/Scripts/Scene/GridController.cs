using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject tileBase;
    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject startPointTile;
    [SerializeField] private GameObject endPointTile;
    [SerializeField] private float cellSize;
    [Range(8, 100)]
    [SerializeField] private int max_size;
    private Vector2 startPosition, endPosition;
    private Vector3[,] grid;

    private void Awake()
    {
        GenerateGrid();
        GenerateStartAndEndPoint();
    }
    void Start()
    {
        //use this line to generate grid on random size
        //max_size = Random.Range(8, max_size);
        InstantiateGrid();
    }
    void GenerateStartAndEndPoint()
    {
        float percent = Random.Range(0, 100);
        if (percent <=50)
        {
            //cria baseado em x
            int positionYStart = Random.Range(0, max_size-1);
            int positionYEnd = Random.Range(0, max_size - 1);
            startPosition = new Vector2(max_size -1 , positionYStart);
            endPosition = new Vector2(0, positionYEnd);
        }
        else
        {
            int positionXStart = Random.Range(0, max_size - 1);
            int positionXEnd = Random.Range(0, max_size - 1);
            startPosition = new Vector2(positionXStart, max_size - 1);
            endPosition = new Vector2(positionXEnd, 0);
        }
    }
    public Vector3[,] GenerateGrid()
    {

        grid = new Vector3[max_size, max_size];
        for (int i = 0; i < max_size; i++)
        {
            for (int j = 0; j < max_size; j++)
            {
                Vector3 coordinate = new Vector3(i * cellSize, 0, j * cellSize);
                grid[i, j] = coordinate;
            }
        }
        return grid;
    }

    public void InstantiateGrid()
    {
        for (int i = 0; i < max_size; i++)
        {
            for (int j = 0; j < max_size; j++)
            {
                Vector3 coordinate = new Vector3(i * cellSize, 0, j * cellSize);
                grid[i, j] = coordinate;
                if (i == startPosition.x && j == startPosition.y)
                {
                    GameObject tileaux;
                    tileaux = Instantiate(startPointTile, coordinate, Quaternion.identity);
                    tileaux.transform.parent = tileBase.transform;
                }else if (i == endPosition.x && j == endPosition.y)
                {
                    GameObject tileaux;
                    tileaux = Instantiate(endPointTile, coordinate, Quaternion.identity);
                    tileaux.transform.parent = tileBase.transform;
                }
                else
                {
                    GameObject tileaux;
                    tileaux = Instantiate(tile, coordinate, Quaternion.identity);
                    tileaux.transform.parent = tileBase.transform;
                }
            }
        }
    }
    public Vector3[,] GetGrid()
    {
        return grid;
    }

    public Vector2 GetStartPosition()
    {
        return startPosition;
    }

    public Vector2 GetEndPosition()
    {
        return endPosition;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public int GetGridSize()
    {
        return max_size;
    }
}
