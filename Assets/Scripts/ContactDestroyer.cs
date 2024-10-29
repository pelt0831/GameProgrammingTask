using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    public string targetTag = "Enemy"; // �ı��Ϸ��� ������Ʈ�� �±�

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Ư�� �±׸� ���� ��쿡�� �ı�
        if (other.gameObject.CompareTag(targetTag))
        {
            Destroy(other.gameObject); // �浹�� ������Ʈ �ı�
        }

        // �ڽŵ� �ı� (�ʿ��� ���)
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
