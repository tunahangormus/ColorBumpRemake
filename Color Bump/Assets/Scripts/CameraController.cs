using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField ]
    private int cameraSpeed;
    private GameManager gameManager;

    void Start(){
        gameManager = GameManager.instance;
    }

    void Update()
    {
        if(gameManager.CurrentGameState == GameState.Started)
            MoveCamera();

    }


    void MoveCamera(){
        Vector3 cameraPos = transform.position;
        cameraPos.z += cameraSpeed * Time.deltaTime;
        transform.position = cameraPos;
    }


}
