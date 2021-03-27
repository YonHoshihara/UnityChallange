using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public bool life, move, dice;
    public int healthRecover;
    private RoundController roundController;
    private PowerUpController poweUpController;

    void Start()
    {
        poweUpController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PowerUpController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Contains("Player"))
        {
            if (life)
            {
                other.gameObject.GetComponent<PlayerController>().AddHealth(healthRecover);
            }

            if (move)
            {
                roundController = GameObject.FindGameObjectWithTag("GameController").GetComponent<RoundController>();
                roundController.RemoveMoveCount();
            }

            if (dice) {

                other.gameObject.GetComponent<PlayerController>().dicesNumber ++;
            
            }

            poweUpController.CheckpowerUpRespanwn();
            Destroy(gameObject);
        
        }
    }

}
