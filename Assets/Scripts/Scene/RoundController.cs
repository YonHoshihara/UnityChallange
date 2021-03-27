using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1,2)]
    public int playerOnTurn;
    [Range(0,3)]
    private int moveCount;
    [SerializeField] private GameController gameController;
    [SerializeField] private Text movementCounterText, playerOnTurnText, movementLeftText;
    [SerializeField] private BattleController battleController;
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
        ShowCurrentPlayerOnTurn();
        ShowMovementLeft();
    }

    void FixedUpdate()
    {
        CheckCurrentPlayer();
    }
    private void CheckCurrentPlayer()
    {
        if (canIMove)
        {
            if ((moveCount == 3)&&(battleController.battleEnd))
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
    private void ShowCurrentPlayerOnTurn()
    {
        string text;
        if (playerOnTurn == 1) {
                
            text = "Blue Turn";
            playerOnTurnText.color = Color.blue;
            movementCounterText.color = Color.blue;
            movementLeftText.color = Color.blue;
        }
        
        else {
            text = "Red Turn";
            playerOnTurnText.color = Color.red;
            movementCounterText.color = Color.red;
            movementLeftText.color = Color.red;
        }
            
        playerOnTurnText.text = text;
    }
    private void ShowMovementLeft()
    {
        string text = (3 - moveCount).ToString();
        movementCounterText.text = text;
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
