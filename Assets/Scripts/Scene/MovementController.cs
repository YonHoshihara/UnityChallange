using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController gameController;
    [SerializeField] RoundController roundController;
    void Start()
    {
    }
    
    IEnumerator Move(GameObject player, Vector3 startPosition , Vector3 endPosition, float delay)
    {

        if (roundController.canIMove)
        {
            float time = 0;
            while (time < 1)
            {

                roundController.canIMove = false;
                time += Time.deltaTime / delay;
                if (time > 1)
                {
                    time = 1;
                }
                player.transform.position = Vector3.Lerp(startPosition, endPosition, time);
                yield return null;
            }
            roundController.AddMoveCount();
            roundController.canIMove = true;
        }
    }
    public void Move(Vector3 endPosition)
    {

        if (roundController.canIMove)
        {
            GameObject playerOnTurn, playerOnStand;
            if (roundController.GetPlayerOnTurn() == 1)
            {
                playerOnTurn = gameController.player1;
                playerOnStand = gameController.player2;
            }
            else
            {
                playerOnTurn = gameController.player2;
                playerOnStand = gameController.player1;
            }

            Vector3 startPosition = playerOnTurn.transform.position;
            endPosition = new Vector3(endPosition.x, startPosition.y, endPosition.z);
            Vector3 distance = endPosition - startPosition;

            if ((distance.magnitude <= 1.375f)&&(endPosition != playerOnStand.transform.position))
            {
                StartCoroutine(Move(playerOnTurn, startPosition, endPosition, 2));

            }
            else
            {
                Debug.Log("Can't move");
            }
        }
    }
}
