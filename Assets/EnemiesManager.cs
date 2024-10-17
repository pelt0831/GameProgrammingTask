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
            enemies = new List<Enemy>(); // 리스트 초기화
            Debug.Log("EnemiesManager instance created.");
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스는 파괴
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
