using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    [SerializeField]
    private int wallDistance;

    [SerializeField]
    private int closeDistance;

    [SerializeField]
    private int furtherDistance;

    void Update()
    {
        CheckCollider();
    }

    void CheckCollider()
    {
        Vector3 pos = transform.position;

        if (pos.x > wallDistance)
            pos.x = wallDistance;
        else if (pos.x < -wallDistance)
            pos.x = -wallDistance;

        if (pos.z < Camera.main.transform.position.z + closeDistance)
            pos.z = Camera.main.transform.position.z + closeDistance;
        else if (pos.z > Camera.main.transform.position.z + furtherDistance)
            pos.z = Camera.main.transform.position.z + furtherDistance;



        transform.position = pos;

    }

}

