using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject player1, player2;
    [SerializeField] private GridController gridController;
    [SerializeField] private RoundController roundController;
    [SerializeField] private Camera mainCamera;
    private Vector3[,] grid;
    // Start is called before the first frame update
    
    void Start()
    {
        grid = gridController.GetGrid();
        InstantiatePlayer();
        SetMaincameraFollow();
    }

    private void FixedUpdate()
    {
        SetMaincameraFollow();
    }

    private void InstantiatePlayer()
    {
        Vector2 startPosition = gridController.GetStartPosition();
        Vector3 position = grid[(int)startPosition.x, (int)startPosition.y];
        Vector3 positionP2 = grid[(int)startPosition.x, (int)startPosition.y];
        position = new Vector3(position.x - gridController.GetCellSize() / 4, position.y + gridController.GetCellSize(), position.z);
        positionP2 = new Vector3(positionP2.x + gridController.GetCellSize()/4, positionP2.y + gridController.GetCellSize(), positionP2.z);
        player1 = Instantiate(player1, position, Quaternion.identity);
        player2 = Instantiate(player2, positionP2, Quaternion.identity);
    }
    // Update is called once per frame
    
    private void SetMaincameraFollow()
    {

        GameObject player;
        if (roundController.GetPlayerOnTurn() == 1)
        {
            player = player1;
        }
        else
        {
            player = player2;
        }

        mainCamera.transform.position = new Vector3(player.transform.position.x,mainCamera.transform.position.y, player.transform.position.z);
    }
    
    void Update()
    {
        
    }
}
