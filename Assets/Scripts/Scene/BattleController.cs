using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public bool inbattle,battleEnd;
    public float battleMinDistance;
    [SerializeField] private GameController gameController;
    [SerializeField] private RoundController roundController;
    [SerializeField] private SoundController sounController;
    [SerializeField] private GameObject diceRollsTable;
    [SerializeField] private Text battleWinnerFeedback;
    private PlayerController  player1, player2;
    private GameObject[] reddices, bluedices;
    private List<int> player1Dices, player2Dices;
    private int currentBattleVictory;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player1Dices = new List<int>();
        player2Dices = new List<int>();
        inbattle = false;
        battleEnd = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        distance = (gameController.player1.transform.position - gameController.player2.transform.position).magnitude;
        if (distance <= battleMinDistance)
        {
            inbattle = true;
        }
        else
        {
            inbattle = false;
        }
    }

    public void Battle()
    {
        StartCoroutine(StartBattle());
  
    }
    IEnumerator StartBattle()
    {
        player1 = gameController.player1.GetComponent<PlayerController>();
        player2 = gameController.player2.GetComponent<PlayerController>();
        roundController.canIMove = false;
        battleEnd = false;
        GenerateAndCompareRolls();
        diceRollsTable.SetActive(true);
        reddices = GameObject.FindGameObjectsWithTag("reddice");
        bluedices = GameObject.FindGameObjectsWithTag("bluedice");
        RestetDicesView(reddices);
        RestetDicesView(bluedices);

        yield return StartCoroutine(RollDicesFeedback(bluedices, player1Dices));
        yield return StartCoroutine(RollDicesFeedback(reddices, player2Dices));

       if (currentBattleVictory == 1)
       {
           battleWinnerFeedback.color = Color.blue;
           battleWinnerFeedback.text = "Blue Wins";
           yield return new WaitForSeconds(2f);
           diceRollsTable.SetActive(false);
           battleWinnerFeedback.text = "";
           player2.getDamage(player1.atack);
       }
       else
       {
           battleWinnerFeedback.color = Color.red;
           battleWinnerFeedback.text = "Red Wins";
           yield return new WaitForSeconds(2f);
           diceRollsTable.SetActive(false);
           battleWinnerFeedback.text = "";
           player1.getDamage(player2.atack);
       }
    }

    IEnumerator RollDicesFeedback(GameObject[] diceVector, List<int> diceRolls)
    {
        for (int i = 0; i < diceVector.Length; i++)
        {
            Animator anim = diceVector[i].GetComponent<Animator>();
            AnimatorClipInfo[] clipInfo;
            float aninDuration;
            anim.SetTrigger("roll");
            sounController.playDiceSound();
            clipInfo = anim.GetCurrentAnimatorClipInfo(0);
            aninDuration = clipInfo[0].clip.length;
            yield return new WaitForSeconds(2 * aninDuration);
            anim.SetTrigger("roll");
            Text number = diceVector[i].GetComponentInChildren<Text>();
            number.text = diceRolls[i].ToString();
        }
    }
    private int CompareDices(List<int> player1Dices, List<int> player2Dices)
    {
        int player1VictoryCounter = 0; 
        int player2VictoryCounter = 0;
        int minDicesValue = Mathf.Min(player1Dices.Count,player2Dices.Count);
        
        for (int i = 0; i < 3; i++)
        {
            if (player1Dices[i] == player2Dices[i])
            {
                if (roundController.GetPlayerOnTurn() == 1)
                {
                    player1VictoryCounter++;
                }
                else
                {
                    player2VictoryCounter++;
                }
            }

            if (player1Dices[i] > player2Dices[i])
            {
                player1VictoryCounter++;
            }
            else
            {
                player2VictoryCounter++;
            }
        }

        if (player1VictoryCounter > player2VictoryCounter)
        {
            return 1;
        }
        else
        {
            return 2;
        }
        
    }
    private List<int> GeneratePlayerRolls(PlayerController player)
    {
        List<int> dicesRolls = new List<int>();
        for (int i = 0; i<player.dicesNumber;i++)
        {
            dicesRolls.Add(RollDice());
        }
        dicesRolls.Sort();
        dicesRolls.Reverse();
        return dicesRolls;
    }
    private int RollDice()
    {
        int dice_number = Random.Range(1,7);
        return dice_number;
    }
    private void RestetDicesView(GameObject[] diceRolls)
    {
        for (int i = 0; i < diceRolls.Length; i++)
        {
            Text number = diceRolls[i].GetComponentInChildren<Text>();
            number.text = "";
        }
    }
    private void GenerateAndCompareRolls()
    {
        player1Dices = GeneratePlayerRolls(player1);
        player2Dices = GeneratePlayerRolls(player2);
        currentBattleVictory = CompareDices(player1Dices, player2Dices);
    }
}
