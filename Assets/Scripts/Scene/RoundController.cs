using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1,2)]
    public int playerOnTurn;
    [Range(0,3)]
    private int moveCount;
    [SerializeField] private GameController gameController;
    public bool canIMove;
    
    void Start()
    {
        moveCount = 0;
        playerOnTurn = 1;
        canIMove = true;
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameController.gameOver)
        {
            canIMove = false;
        }
    }

    void FixedUpdate()
    {
        CheckCurrentPlayer();
    }

    private void CheckCurrentPlayer()
    {
        if (canIMove)
        {
            if (moveCount == 3)
            {
                if (playerOnTurn == 1)
                {
                    playerOnTurn = 2;
                    moveCount = 0;

                }
                else
                    playerOnTurn = 1;
                    moveCount = 0;
            }
        }
    }
    
    public void AddMoveCount()
    {
        moveCount++;
    }
    public int GetPlayerOnTurn()
    {
        return playerOnTurn;
    }
}
