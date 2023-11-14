/*
 * Salmoria, Wyatt & Kalkat, Karen
 * 11/13/23
 * Creates an array to put enemies under, and when all enemies in array are defeated, ends the level and sends the player to the victory screen.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arena : MonoBehaviour
{
    //The array that allows us to designate what enemies need to be defeated.
    public GameObject[] enemiesToDefeat;

    // Update is called once per frame
    void Update()
    {
        bool allDefeated = true;
        for (int i = 0; i < enemiesToDefeat.Length; i++)
        {
            GameObject enemy = enemiesToDefeat[i];
            if (enemy.activeInHierarchy)
            {
                allDefeated = false;
            }
        }

        if (allDefeated)
        {
            SceneManager.LoadScene(3);
        }
    }
}
