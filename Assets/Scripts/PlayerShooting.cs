using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(prefab1, firePoint.position, firePoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(prefab2, firePoint.position, firePoint.rotation);
        }
    }
}
