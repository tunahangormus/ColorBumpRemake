using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject endLine;

    private float maxDistance;
    private float distanceNow;

    private UIController uIController;
    void Start()
    {
        uIController = UIController.instance;
        maxDistance = Vector3.Distance(player.transform.position, endLine.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CurrentGameState == GameState.Started)
            CalculateDistance();

    }


    void CalculateDistance()
    {
        distanceNow = Vector3.Distance(player.transform.position, endLine.transform.position);
        uIController.fillImage(1 - (distanceNow / maxDistance));
    }
}
