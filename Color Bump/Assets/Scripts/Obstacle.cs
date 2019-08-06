using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private bool isEnemy;

    private ObstacleManager obstacleManager;
    void Start()
    {
        obstacleManager = ObstacleManager.instance;
        AddMaterial();
        ChangeTag();
    }


    void AddMaterial()
    {
        if (isEnemy)
            this.GetComponent<Renderer>().material = obstacleManager.EnemyMaterial;
        else
            this.GetComponent<Renderer>().material = obstacleManager.AllyMaterial;
    }

    void ChangeTag()
    {
        if (isEnemy)
            this.tag = "Enemy";
    }
}
