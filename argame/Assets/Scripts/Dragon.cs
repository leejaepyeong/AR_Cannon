using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Transform Target;
    public GameObject bulletPrefab;
    

    bool isAttack = false;

    public int myNum;
    float delay = 3.5f;

    public AudioSource audio;
    public Animator anim;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Goal").transform;
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, Target.position) <= 18f)
        {

            if(!GameManager.instance.isEnd && !isAttack)
                StartCoroutine(TryAttack());
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, 1f * Time.deltaTime);
        }
            
    }

    IEnumerator TryAttack()
    {
        isAttack = true;
        
        yield return new WaitForSeconds(delay);
        audio.Play();

        anim.SetTrigger("Attack");


        yield return new WaitForSeconds(0.3f);

        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f,4.9f,-1.5f), Quaternion.identity);

        yield return new WaitForSeconds(0.5f);


        audio.Stop();

        isAttack = false;

    }

    public void Death()
    {
        anim.SetTrigger("Death");

        Destroy(gameObject, 1.2f);
    }



}
