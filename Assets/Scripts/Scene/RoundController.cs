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
    private PlayerController playerController1, playerController2;
    [SerializeField] private GameController gameController;
    [SerializeField] private Text movementCounterText, playerOnTurnText, movementLeftText, atackText, dicesText;
    [SerializeField] private Image lifeBarbackground, lifebarHanddler;
    [SerializeField] private Slider lifeBar;
    [SerializeField] private BattleController battleController;
    public bool canIMove;
    
    void Start()
    {
        moveCount = 0;
        playerOnTurn = 1;
        canIMove = true;
        playerController1 = gameController.player1.GetComponent<PlayerController>();
        playerController2 = gameController.player2.GetComponent<PlayerController>();
       
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
                    playerController1.ResetDices();
                    playerController2.ResetDices();
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
            atackText.text = "Atack: " + playerController1.atack.ToString();
            dicesText.text = "Dices: " + playerController1.dicesNumber.ToString();
            lifeBar.value = playerController1.health;
            lifeBar.maxValue = playerController1.maxHealth;
            playerOnTurnText.color = Color.blue;
            movementCounterText.color = Color.blue;
            movementLeftText.color = Color.blue;
            lifeBarbackground.color = Color.blue;
            atackText.color = Color.blue;
            dicesText.color = Color.blue;
            lifebarHanddler.color = Color.blue;
        }
        
        else {
            
            text = "Red Turn";
            atackText.text = "Atack: " + playerController2.atack.ToString();
            dicesText.text = "Dices: " + playerController2.dicesNumber.ToString();
            lifeBar.value = playerController2.health;
            lifeBar.maxValue = playerController2.maxHealth;
            playerOnTurnText.color = Color.red;
            movementCounterText.color = Color.red;
            movementLeftText.color = Color.red;
            atackText.color = Color.red;
            dicesText.color = Color.red;
            atackText.color = Color.red;
            dicesText.color = Color.red;
            lifeBarbackground.color = Color.red;
            lifebarHanddler.color = Color.red;
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

    public void RemoveMoveCount()
    {
        moveCount--;
    }
    public int GetPlayerOnTurn()
    {
        return playerOnTurn;
    }
}
