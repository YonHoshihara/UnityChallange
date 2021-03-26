using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1,2)]
    public int playerOnTurn;
    [SerializeField] public GameController gameController;
    
    void Start()
    {
        playerOnTurn = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public int GetPlayerOnTurn()
    {
        return playerOnTurn;
    }
}
