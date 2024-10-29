using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab1;  // ���� Ŭ�� �߻�ü
    public GameObject prefab2;  // ������ Ŭ�� �߻�ü
    public Transform firePoint; // �߻� ��ġ

    public ParticleSystem muzzleFlash; // �� �߻� �� ��Ÿ�� �Ҳ� ����Ʈ
    public float muzzleFlashDuration = 0.1f; // �Ҳ� ����Ʈ ��� �ð�

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

    // �߻� �Լ�
    void Shoot(GameObject projectile)
    {
        // �߻�ü ����
        Instantiate(projectile, firePoint.position, firePoint.rotation);

        // �Ҳ� ����Ʈ ���
        if (muzzleFlash != null)
        {
            StartCoroutine(PlayMuzzleFlash());
        }
    }

    // �Ҳ� ����Ʈ�� ��� ����� �� ���ߴ� Coroutine
    IEnumerator PlayMuzzleFlash()
    {
        muzzleFlash.Play(); // �Ҳ� ����Ʈ ���
        yield return new WaitForSeconds(muzzleFlashDuration); // ����Ʈ ���� �ð���ŭ ���
        muzzleFlash.Stop(); // ����Ʈ ����
    }
}
