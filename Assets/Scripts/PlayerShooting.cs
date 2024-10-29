using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab1;  // 왼쪽 클릭 발사체
    public GameObject prefab2;  // 오른쪽 클릭 발사체
    public Transform firePoint; // 발사 위치

    public ParticleSystem muzzleFlash; // 총 발사 시 나타날 불꽃 이펙트
    public float muzzleFlashDuration = 0.1f; // 불꽃 이펙트 재생 시간

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(prefab1);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shoot(prefab2);
        }
    }

    // 발사 함수
    void Shoot(GameObject projectile)
    {
        // 발사체 생성
        Instantiate(projectile, firePoint.position, firePoint.rotation);

        // 불꽃 이펙트 재생
        if (muzzleFlash != null)
        {
            StartCoroutine(PlayMuzzleFlash());
        }
    }

    // 불꽃 이펙트를 잠깐 재생한 후 멈추는 Coroutine
    IEnumerator PlayMuzzleFlash()
    {
        muzzleFlash.Play(); // 불꽃 이펙트 재생
        yield return new WaitForSeconds(muzzleFlashDuration); // 이펙트 지속 시간만큼 대기
        muzzleFlash.Stop(); // 이펙트 멈춤
    }
}
