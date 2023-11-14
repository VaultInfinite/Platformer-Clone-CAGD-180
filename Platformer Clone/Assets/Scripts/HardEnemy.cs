/*
 * Author: [Kalkat, Karen & Salmoria, Wyatt]
 * Last Updated: [11/12/2023]
 * [Contains the code for the Hard Enemy; specifically, makes the enemy move towards the player.]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    //Designation for the player
    public GameObject Player;

    //Designation for the left point, limiting enemy movement in that direction.
    public GameObject LeftEmpty;

    //Designation for the right point, limiting enemy movement in that direction.
    public GameObject RightEmpty;

    //Speed of the harder enemy
    public float speed;

    //Checks to see if facing right; needs to be designated when placed, should be permanently left to begin with.
    public bool goingLeft = false;

    //The health of the hard enemy.
    public int health = 10;

    //The left empty position.
    private Vector3 leftPos;
    //The Right empty position.
    private Vector3 rightPos;

    private void Start()
    {
        leftPos = LeftEmpty.transform.position;
        rightPos = RightEmpty.transform.position;
    }

    private void Update()
    {
        //If the player is to the right of the enemy, the enemy will move to the right.
        if (Player.transform.position.x > transform.position.x)
        {
            if (goingLeft == true)
            {
                transform.Rotate(Vector3.up * 180);
            }
            goingLeft = false;
            if (transform.position.x >= rightPos.x)
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
        //If the player is to the left of the enemy, it will move to the left.
        else
        {
            if (goingLeft == false)
            {
                transform.Rotate(Vector3.up * 180);
            }
            goingLeft = true;
            if (transform.position.x <= leftPos.x)
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
    }
    /// <summary>
    /// Section of the script that runs the collision, specifically makes the enemy stop moving if a wall is found.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "HeavyBullet")
        {
            other.gameObject.SetActive(false);
            health -= 3;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
