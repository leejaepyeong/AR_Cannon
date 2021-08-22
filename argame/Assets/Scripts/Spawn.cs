using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Transform[] pos;
    public GameObject[] dragons;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawn());
    }


    IEnumerator StartSpawn()
    {
        if (!GameManager.instance.isEnd)
        {
            yield return new WaitForSeconds(4f);

            for (int i = 0; i < 5; i++)
            {
                if(GameManager.instance.GameLevel <= 1)
                {
                    if (Random.Range(0, 2) == 0)
                        break;
                }
                else
                {
                    if (Random.Range(0, 3) == 0)
                        break;
                }

                
                Instantiate(dragons[Random.Range(0, 3)], pos[i].position, Quaternion.LookRotation(pos[i].forward * -1));

            }

            if(!GameManager.instance.isEnd)
            StartCoroutine(StartSpawn());
        }

       
    }
}
