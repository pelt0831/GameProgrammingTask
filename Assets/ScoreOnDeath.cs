using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;

    void OnDestroy()
    {
        Debug.Log("Enemy destroyed, adding score: " + amount);
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.amount += amount;
            Debug.Log("Score updated: " + ScoreManager.instance.amount);
        }
        else
        {
            Debug.LogError("ScoreManager instance is null!");
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
