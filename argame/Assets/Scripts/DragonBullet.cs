using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBullet : MonoBehaviour
{
    public Transform Target;
    float damage = 10f;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Goal").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, 12f * Time.deltaTime);
    }

    IEnumerator BulletHit()
    {
        yield return new WaitForSeconds(0.8f);

        GameManager.instance.Damage(damage);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Life")
        {
            Debug.Log("Hit");

            StartCoroutine(BulletHit());
        }
    }
}
