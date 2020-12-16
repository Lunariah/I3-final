using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    void Start()
    {
        GameManager game = GameObject.FindObjectOfType<GameManager>();
        if (game == null) {
            Debug.LogError("Can’t find Game Manager");
        }
        else {
            GetComponent<TextMeshProUGUI>().text = "" + game.score;
        }
    }
}