using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
  //              UPGRADABLE SKILLS
  //******************************************
    public float moveSpeed = 10f;//BASE SPEED
  //******************************************
  //The upgraded values of these skills are held in GameData.cs

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;


    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            float step = moveSpeed * Time.deltaTime;

            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);

            transform.position = Vector2.MoveTowards(transform.position, touchPosition, step);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
    }
}
