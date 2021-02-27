using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tile;
    [SerializeField] private float cellSize;
    [SerializeField] private Vector2 gridSize;
    public float [][] gridCoordenates;



    void Start()
    {

        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Instantiate(tile, new Vector3( i*cellSize, 0, j*cellSize), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
