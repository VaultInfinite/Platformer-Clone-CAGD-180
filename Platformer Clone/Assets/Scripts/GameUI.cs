/*
 * Salmoria, Wyatt & Kalkat, Karen
 * 11/7/23
 * Handles the UI of the game, primarily hp remaining.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    public PlayerController player;
    public TMP_Text healthDisplay;

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Current HP: " + player.health.ToString();
    }
}
