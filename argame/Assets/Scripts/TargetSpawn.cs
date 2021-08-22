using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public GameObject[] targetBallon;
    public Transform targetPos;
    public Transform BombPos;
    public GameObject nextBall;


    private void Start()
    {

        SpawnTarget();
    }


    public void SpawnTarget()
    {
        nextBall = Instantiate(targetBallon[Random.Range(0, 3)], targetPos.position, Quaternion.identity);
    }

    public void ShootBomb()
    {
        SpawnTarget();
    }
}
