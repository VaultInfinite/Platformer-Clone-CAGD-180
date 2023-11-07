using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Kalkat, Karen & Salmoria, Wyatt]
 * Last Updated: [11/07/2023]
 * [Contains the code for the Hard Enemy]
 */

public class HardEnemy : MonoBehaviour
{
    public int speed;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public GameObject leftPoint;
    public GameObject rightPoint;
    public bool goingLeft;
    public GameObject player;
    private Vector3 offset;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;


        target = player.transform;

    }

    // Update is called once per frame
    void Update()
    {

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            target.position *= -1.0f;
        }

    }

    private void HardEnemyMovement()
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }

}
