using UnityEngine;
using System.Collections;

public class ShootProjectiles : MonoBehaviour
{
    public GameObject projectile;
    public Sprite activatedBullet;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        InvokeRepeating("LaunchProjectile", 5f, 7f);
    }

    void LaunchProjectile()//tbh i barely know how this works LOL wtf is this shit
    {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        Vector3 dir = player.transform.position - bullet.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + Random.Range(-10f, 10f);

        if (angle >= 0)
        {
            angle += Random.Range(0f, 20f);
        }
        else
        {
            angle -= Random.Range(0f, 20f);
        }

        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 30 + new Vector3(10f,0f,0f));//TODO: this line lmao
        StartCoroutine(activateBullet(bullet));
    }

    IEnumerator activateBullet(GameObject bull)
    {
        yield return new WaitForSeconds(3.5f);
        bull.GetComponent<SpriteRenderer>().sprite = activatedBullet;
    }
}
