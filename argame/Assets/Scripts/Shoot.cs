using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject cam;
    public GameObject FireEffect;
    public GameObject HitEffect;
    public GameObject BoomEffect;

    public TargetSpawn targetSpawn;
    public AudioSource audio;

    public bool isOn = true;
    int bombCount = 1;

    public void TryFire()
    {
        if (!isOn) return;

        isOn = false;

        StartCoroutine(Fire());

    }


    IEnumerator Fire()
    {
        RaycastHit hit;

        Debug.Log("ISHOOTING");

        GameObject fireEffect = Instantiate(FireEffect, targetSpawn.BombPos.position, Quaternion.identity);

        fireEffect.SetActive(false);

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            audio.Play();

            if (hit.transform.tag == "Dragon")
            {

                int hitNum = 0;

                Dragon dragon = hit.transform.GetComponent<Dragon>();

                fireEffect.SetActive(true);

                if(dragon.myNum == targetSpawn.nextBall.GetComponent<Ballon>().MyNum)
                {
                    hitNum = 1;

                    GameObject hitEffect = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    hitEffect.SetActive(true);

                    dragon.Death();

                    yield return new WaitForSeconds(0.25f);

                    Destroy(hitEffect);
                }

                GameManager.instance.HitOn(hitNum);

                targetSpawn.ShootBomb();
            }
            else
            {
                yield return new WaitForSeconds(0.25f);
            }

            audio.Stop();
        }

        yield return new WaitForSeconds(0.25f);

        Destroy(fireEffect);

        isOn = true;
    }


    public void TryBoom()
    {
        if (bombCount == 0) return;

        bombCount--;

        GameManager.instance.boomCount.text = 0.ToString();

        GameObject[] dragons = GameObject.FindGameObjectsWithTag("Dragon");

        foreach(GameObject dragon in dragons)
        {
            Destroy(dragon);
            GameObject boom = Instantiate(BoomEffect, dragon.transform.position + new Vector3(0f, 4.6f, 0f), Quaternion.identity);

            Destroy(boom, 0.7f);
        }

        audio.Play();

    }
}
