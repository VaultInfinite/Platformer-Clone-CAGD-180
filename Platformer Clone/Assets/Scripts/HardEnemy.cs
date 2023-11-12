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
    public GameObject player;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {

        //assigns a target to the player so the enemy knows what to follow
        target = player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //the speed in which the enemy is traveling towards the player
        var step = speed * Time.deltaTime;

        //helps with moving the enemy towards the position of the player
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }

}
