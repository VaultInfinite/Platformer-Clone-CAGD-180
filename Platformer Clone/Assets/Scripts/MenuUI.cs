/*
 * Wyatt Salmoria & Karen Kalkat
 * 10/27/23
 * Handles the MenuUI of the Main Menu of the game, and likely the Game Over screen
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quit the Game");
        Application.Quit();
    }

    /// <summary>
    /// Move back to the desired scene, likely the first scene.
    /// </summary>
    /// <param name="sceneIndex">The scene that the player will switch to after clicking the button</param>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(1);
    }
}
