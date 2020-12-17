using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "" + GameManager.instance.score;
    }
}