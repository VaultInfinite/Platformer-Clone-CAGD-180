using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        HardEnemyMovement();
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
