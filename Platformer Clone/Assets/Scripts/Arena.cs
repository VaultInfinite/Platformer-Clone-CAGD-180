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
