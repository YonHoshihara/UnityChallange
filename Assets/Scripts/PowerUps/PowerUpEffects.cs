using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public bool life, move, dice;
    public int healthRecover;
    private GameObject gameController;
    private RoundController roundController;
    private PowerUpController poweUpController;
    private SoundController soundController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        poweUpController = gameController.GetComponent<PowerUpController>();
        roundController = gameController.GetComponent<RoundController>();
        soundController = gameController.GetComponent<SoundController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Contains("Player"))
        {

            soundController.playCollectSound();
            if (life)
            {
                other.gameObject.GetComponent<PlayerController>().AddHealth(healthRecover);
            }

            if (move)
            {
                roundController.RemoveMoveCount();
            }

            if (dice) {

                other.gameObject.GetComponent<PlayerController>().AddDice();
            
            }

            poweUpController.CheckpowerUpRespanwn();
            Destroy(gameObject);
        
        }
    }

}
