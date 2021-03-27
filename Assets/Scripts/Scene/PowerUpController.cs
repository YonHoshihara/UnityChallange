using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject [] powerUpTipes;
    [SerializeField] private GridController gridController;
    private Vector2 startPosition, endPosition;
    private int gridSize;
    private Vector3[,] grid;
    private GameObject[,] instantiatedPowerUps;
    void Start()
    {
        startPosition = gridController.GetStartPosition();
        endPosition = gridController.GetEndPosition();
        grid = gridController.GetGrid();
        gridSize = gridController.GetGridSize();
        instantiatedPowerUps = new GameObject[gridSize, gridSize];
        InstantiatePowerUps();
    }
    void InstantiatePowerUps()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector2 curentPosition = new Vector2(i, j);
                if ((curentPosition!= startPosition) && (curentPosition!= endPosition))
                {
                    if (instantiatedPowerUps[i, j] != null)
                    {
                        Destroy(instantiatedPowerUps[i,j]);
                    }
                    
                    Vector3 position = grid[i , j];
                    position = new Vector3(position.x, position.y + gridController.GetCellSize()/2, position.z);
                    int powerUpTipe = Random.Range(0, powerUpTipes.Length);
                    instantiatedPowerUps[i,j] = Instantiate(powerUpTipes[powerUpTipe], position, Quaternion.identity);

                }
            }
        }
    }

    public void CheckpowerUpRespanwn()
    {
        GameObject[] currentPowerUps = GameObject.FindGameObjectsWithTag("PowerUp");
        int powerUpNumbers = currentPowerUps.Length;
        int minNumberPowerUp = (gridSize * gridSize - 2) *10/100;
        if (powerUpNumbers <= minNumberPowerUp)
        {
            InstantiatePowerUps();
        }
    }
}
