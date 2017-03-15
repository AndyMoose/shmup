using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotFire : MonoBehaviour
{

    public float fireRate;

    private float nextFire;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Fire();
            nextFire = Time.time + fireRate;
        }
    }

    void Fire()
    {
        GameObject obj = Pooler.current.GetPooledObject();

        if (obj == null)
            return;

        obj.transform.position = transform.position + new Vector3(1.0f, .25f, 0f);
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

    }
}