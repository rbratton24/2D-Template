using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float speed = 20f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Shoot();
        }
    }

    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
