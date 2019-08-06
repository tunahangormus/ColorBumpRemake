using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 lastMousePos;
    private Rigidbody rb;
    [SerializeField]
    private int speed;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.instance;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (gameManager.CurrentGameState != GameState.Started)
            return;

        if (Input.GetMouseButton(0))
            AddForceToPlayer();
        else
            lastMousePos = Vector2.zero;

        MovePlayer();
    }

    void AddForceToPlayer()
    {
        Vector2 mousePos = Input.mousePosition;

        if (lastMousePos == Vector2.zero)
            lastMousePos = mousePos;

        Vector2 diffPos = mousePos - lastMousePos;
        lastMousePos = mousePos;

        Vector3 force = new Vector3(diffPos.x, 0, diffPos.y) * speed;

        rb.AddForce(force);

    }

    void MovePlayer()
    {
        rb.MovePosition(transform.position + Vector3.forward * 3 * Time.deltaTime);
    }


    void OnCollisionEnter(Collision col)
    {
        if (gameManager.IsGameEnded)
            return;

        if (col.transform.tag.Equals("Enemy"))
        {
            gameManager.IsGameEnded = true;
        }
        else if (col.transform.tag.Equals("End"))
        {
            gameManager.Win = true;
            gameManager.IsGameEnded = true;
        }

    }
}
