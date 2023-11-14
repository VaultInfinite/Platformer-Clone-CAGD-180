/*
 * Salmoria, Wyatt & Kalkat, Karen
 * 11/7/23
 * The code for the bullet and heavy bullet, dictates the speed, despawn time, and movement direction.
 */using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float despawnTime = 3f;
    public bool moveLeft;

    // Start is called before the first frame update
    void Start()
    {
        //When the bullet spawns in, begin the despawn coroutine
        StartCoroutine(DespawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Waits for a period of time then destroys itself
    /// </summary>
    /// <returns></returns>
    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(this.gameObject);
    }
}
