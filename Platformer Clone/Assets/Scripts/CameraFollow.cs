/*
 *Wyatt Salmoria & Karen Kalkat
 * 10/31/23
 * If utilized in end product, will allow the camera to follow the player without the current setup
 * of the player and camera in the same empty.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //transform position of the camera - transform position of the player
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //as the target/player moves we add offset to this object
        transform.position = target.transform.position + offset;
    }
}
