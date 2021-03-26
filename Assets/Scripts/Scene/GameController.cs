using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject player1, player2;
    public bool gameOver;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text victoryText;
    [SerializeField] private GridController gridController;
    [SerializeField] private RoundController roundController;
    [SerializeField] private Camera mainCamera;
    private Vector3[,] grid;
    // Start is called before the first frame update
    
    void Start()
    {
        gameOver = false;
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
        Vector2 endPosition = gridController.GetEndPosition();
        Vector3 position = grid[(int)startPosition.x, (int)startPosition.y];
        Vector3 positionP2 = grid[(int)endPosition.x, (int)endPosition.y];
        position = new Vector3(position.x, position.y + gridController.GetCellSize(), position.z);
        positionP2 = new Vector3(positionP2.x, positionP2.y + gridController.GetCellSize(), positionP2.z);
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
    
    public void SetGameOver(int victoryPlayer)
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
        string vtext = "Player " + victoryPlayer.ToString();
        victoryText.text = vtext;
    }

    
    void Update()
    {
 
    }
}
