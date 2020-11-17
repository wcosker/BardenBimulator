using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject projectile;
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2f, 3f);
    }

    void LaunchProjectile()
    {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
    }
}
