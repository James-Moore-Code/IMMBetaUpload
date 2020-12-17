using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    private float distance;
    private float attackRadius = 7.5f;

    private float towardPlayerSpeed = 1.0f;

    private float changeTime;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void ChangeDirection()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    void MoveInPlayerDirection()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, towardPlayerSpeed * Time.deltaTime);
        transform.LookAt(player);
    }

    void EnemyMovement()
    {
        if (changeTime > 0)
        {
            transform.Translate(Vector3.forward * speed);
            changeTime -= Time.deltaTime;
        }
        else
        {
            ChangeDirection();
            changeTime = Random.Range(2.0f, 4.0f);
        }

        distance = Vector3.Distance(player.position, transform.position);

        if (distance <= attackRadius)
        {
            MoveInPlayerDirection();
        }
    }
}
