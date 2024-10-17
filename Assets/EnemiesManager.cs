using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance;
    public List<Enemy> enemies;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            enemies = new List<Enemy>(); // ����Ʈ �ʱ�ȭ
            Debug.Log("EnemiesManager instance created.");
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ��� �ı�
            Debug.LogError("Duplicated EnemiesManager, ignoring this one", gameObject);
        }
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
