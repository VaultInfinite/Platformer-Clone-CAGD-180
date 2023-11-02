/*
 * Salmoria, Wyatt & Kalkat, Karen
 * 10/31/23
 * Handles the movement of Metroid Character (Probably Samus?) alongside other factors 
 * related to player control, such as lives.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public HealthPackValue healthPack;

    //The amount of Health Points the player has, deciding how many hits they can take.
    public int health = 99;

    //The speed at which the player will move.
    public float speed = 5f;

    //The amount of HP the player can have at one point. will be increased via the max health increase item.
    public int healthLimit = 99;

    //The force of the players jump, how high they will go.
    public float jumpForce = 6f;

    //location where the player respawns to
    private Vector3 startPos;

    //Designation for Rigidbody for jumping.
    private Rigidbody rigidbody;

    //Bool to state whether or not Player is Invulnerable.
    private bool invuln = false;

    // Start is called before the first frame update
    void Start()
    {
        //set the startPos
        startPos = transform.position;
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

        HandleJumping();
    }

    /// <summary>
    /// Checks to see if the play is on the ground, and if so, will make the player jump upon hitting space.
    /// </summary>
    private void HandleJumping()
    {
        //When player touches the spacebar the player will jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            //if the raycast returns true then an object has been hit and the player is touching the floor
            //For Raycast(startPosition, RayDirection, output the object hit, maximumDistanceForTheRaycastToFire)
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Touching the ground");
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

        }
    }

    private void Damage()
    {
        ///INSERT CODE HERE INSTRUCTING PLAYER TO FLASH FOR 5 SECONDS
        InvulnTimer();
        if (health == 0)
        {
            //SceneManager.LoadScene(2);
            //When utilized put the Game Over build scene number where the # is.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If we collide with a regular enemy, take regular damage.
        if (other.gameObject.tag == "Enemy" && invuln == false)
        {
            health -= 15;
            Damage();
        }
        //If we collide with a Harder enemy, take higher damage.
        if (other.gameObject.tag == "HardEnemy" && invuln == false)
        {
            health -= 35;
            Damage();
        }
        //If we collide with a healing item, heal HP for designated amount.
        if (other.gameObject.tag == "Heal")
        {
            health += healthPack.HPValue;
            other.gameObject.SetActive(false);
            if (health > healthLimit)
            {
                health = 99;
            }
        }
        //If we collide with the portal, teleport the player to the portal's teleport point. Setting startposition is not needed due to functionality of the game.
        if (other.gameObject.tag == "Portal")
        {
            transform.position = other.GetComponent<Portal>().spawnPoint.transform.position;
        }
    }

    IEnumerator InvulnTimer()
    {
        //Set a invuln bool to true
        invuln = true;
        yield return new WaitForSeconds(5f);
        //Set invulnerability bool to false
        invuln = false;
    }
}
