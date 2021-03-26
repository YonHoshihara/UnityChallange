using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController gameController;
    [SerializeField] private bool die;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (die)
        {
            if (gameObject.tag == "Player")
            {
                gameController.SetGameOver(2);
            }
            else
            {
                gameController.SetGameOver(1);
            }
           
        }
    }
}
