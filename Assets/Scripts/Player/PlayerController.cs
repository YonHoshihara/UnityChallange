using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject controller;
    private GameController gameController;
    private RoundController roundControler;
    private BattleController battleController;
    public int health, maxHealth;
    public int atack;
    public int dicesNumber;
    [SerializeField] private bool die;
    [SerializeField] private Animator anim;
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        gameController = controller.GetComponent<GameController>();
        roundControler = controller.GetComponent<RoundController>();
        battleController = controller.GetComponent<BattleController>();
        health = maxHealth;
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
    public void getDamage(int damage)
    {
        StartCoroutine(Damage(damage));
    }

    IEnumerator Damage(int damage)
    {

        roundControler.canIMove = false;
        battleController.battleEnd = false;
        AnimatorClipInfo[] clipInfo;
        float aninDuration;
        health -= damage;
        anim.SetTrigger("damage");
        clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        aninDuration = clipInfo[0].clip.length;
        yield return new WaitForSeconds(2*aninDuration);
        anim.SetTrigger("damage");
        if (health <=0)
        {
            die = true;
        }
        roundControler.canIMove = true;
        battleController.battleEnd = true;
        
    }

    public void AddHealth(int healthToAdd)
    {
        if ((health + healthToAdd)>= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healthToAdd;
        }
    }
    
    public void ResetDices()
    {
        dicesNumber = 3;
    }
}
