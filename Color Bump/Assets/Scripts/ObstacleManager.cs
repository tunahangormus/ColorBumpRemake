using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private Material enemyMaterial;
    [SerializeField]
    private Material allyMaterial;

    public static ObstacleManager instance;

    public Material EnemyMaterial { get => enemyMaterial;}
    public Material AllyMaterial { get => allyMaterial;}

    void Awake()
    {
        instance = this;
    }

}
