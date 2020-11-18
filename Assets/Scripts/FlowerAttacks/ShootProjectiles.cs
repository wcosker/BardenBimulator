using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        InvokeRepeating("LaunchProjectile", 5f, 7f);
    }

    void LaunchProjectile()
    {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        Vector3 dir = player.transform.position - bullet.transform.position;
        UnityEngine.Debug.Log(player.transform.position.y);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + Random.Range(-10f, 10f);
        if (angle >= 0)
        {
            angle += Random.Range(0f, 20f);
        }
        else
        {
            angle -= Random.Range(0f, 20f);
        }
        UnityEngine.Debug.Log(angle);

        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 30);
    }
}
