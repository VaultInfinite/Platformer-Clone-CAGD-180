/*
 * Wyatt Salmoria & Karen Kalkat
 * 10/26/23
 * Handles the movement of Metroid Character (Probably Samus?) alongside other factors 
 * related to player control, such as lives.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //The amount of lives the player has/how many hits they can take.
    public int Health = 99;

    //The speed at which the player will move.
    public float speed = 5f;

    //The force of the players jump, how high they will go.
    public float jumpForce = 50f;

    //location where the player respawns to
    private Vector3 startPos;

    //Designation for Rigidbody for jumping.
    private Rigidbody rigidbody;

    //Bool to state whether or not Player is Invulnerable.
    private bool invuln = false;

    // Start is called before the first frame update
    void Start()
    {
        //set the reference to the player's attached rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Left and Right player movement
        if (Input.GetKey(KeyCode.A))
        {
            //translate the player left by speed using Time.deltaTime
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //translate the player right by speed using Time.deltaTime
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void Damage()
    {
        ///INSERT CODE HERE INSTRUCTING PLAYER TO FLASH FOR 5 SECONDS, AND INVULNERABILITY.
        InvulnTimer();
        if (Health == 0)
        {
            //SceneManager.LoadScene(#);
            //When utilized put the Game Over build scene number where the # is.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If we collide with a regular enemy, take regular damage.
        if (other.gameObject.tag == "Enemy" && invuln == false)
        {
            Health -= 15;
            Damage();
        }
        //If we collide with a Harder enemy, take higher damage.
        if (other.gameObject.tag == "HardEnemy" && invuln == false)
        {
            Health -= 35;
            Damage();
        }
    }

    IEnumerator InvulnTimer()
    {
        //Set a stunned bool to true
        invuln = true;
        yield return new WaitForSeconds(5f);
        //Set Stunned bool to false
        invuln = false;
    }
}
