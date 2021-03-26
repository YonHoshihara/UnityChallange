using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchdetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gameController;
    [SerializeField] private MovementController movementController;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        movementController = gameController.GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        movementController.Move(gameObject.transform.position);
    }
}
