using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Kalkat, Karen & Salmoria, Wyatt]
 * Last Updated: [11/13/2023]
 * [Contains the code for the Enemy]
 */

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public int speed;
    public bool goingLeft;

    private int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    /// <summary>
    /// allows the enemy to recieve damage from the bullet and take away its health
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
            NoHealth();
        }
        if (other.gameObject.tag == "HeavyBullet")
        {
            other.gameObject.SetActive(false);
            NoHealth();
        }
    }

    /// <summary>
    /// enemy loses its health and disappears
    /// </summary>
    private void NoHealth()
    {
        health--;
        enemy.SetActive(false);
    }

    /// <summary>
    /// allows the enemy to move from left to right in a constant speed
    /// </summary>
    private void EnemyMovement()
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
