using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    public string targetTag = "Enemy"; // 파괴하려는 오브젝트의 태그

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 특정 태그를 가진 경우에만 파괴
        if (other.gameObject.CompareTag(targetTag))
        {
            Destroy(other.gameObject); // 충돌한 오브젝트 파괴
        }

        // 자신도 파괴 (필요할 경우)
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
