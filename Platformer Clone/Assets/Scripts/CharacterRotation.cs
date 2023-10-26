using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{

    public bool facingRight;

    // Update is called once per frame
    void Update()
    {
        rotate();
    }

    /// <summary>
    /// Controls the rotation and orientation of the player model.
    /// </summary>
    public void rotate()
    {
        if (Input.GetKeyDown(KeyCode.A) && facingRight == true)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && facingRight == false)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = true;
        }
    }
}
