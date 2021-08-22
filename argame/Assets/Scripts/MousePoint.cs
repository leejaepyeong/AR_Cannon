using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    GameObject ShootBallon;

    public Transform ShootPos;
    public Camera camera;

    public bool isShoot = false;
    public bool isCrash = false;

    public TargetSpawn targetSpawn;

    void Update()
    {
        if (GameManager.instance.isEnd) return;

        if (Input.GetMouseButton(0) && !isShoot)  // 마우스가 클릭 되면
        {
            isShoot = true;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        ReloadBall();

        Vector3 mos = Input.mousePosition;
        mos.z = camera.farClipPlane; // 카메라가 보는 방향과, 시야를 가져온다.

        Vector3 dir = camera.ScreenToWorldPoint(mos);
        // 월드의 좌표를 클릭했을 때 화면에 자신이 보고있는 화면에 맞춰 좌표를 바꿔준다.

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, mos.z))
        {
            if (hit.transform.tag == "Ball")
            {
                isCrash = false;

                ShootBallon.transform.position = ShootPos.position;


                ShootBallon.GetComponent<Rigidbody>().useGravity = false;

                while (!isCrash)
                {
                    yield return new WaitForSeconds(0.1f);
                    
                    ShootBallon.transform.position = Vector3.MoveTowards(ShootBallon.transform.position, hit.point, 7f * Time.deltaTime);
                }
            }
        }

        

        yield return new WaitForSeconds(0.2f);

        targetSpawn.SpawnTarget();

        isShoot = false;
    }

    public void ReloadBall()
    {
       
    }
}
