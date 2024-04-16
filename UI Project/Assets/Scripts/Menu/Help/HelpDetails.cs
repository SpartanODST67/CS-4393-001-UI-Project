using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HelpOptions : MonoBehaviour
{
    [Header("Help Menu Elements")]
    [SerializeField] TextMeshProUGUI movement;
    [SerializeField] TextMeshProUGUI giftGiving;
    [SerializeField] TextMeshProUGUI inventory;
    [SerializeField] TextMeshProUGUI relationships;
    [SerializeField] TextMeshProUGUI settings;
    [SerializeField] TextMeshProUGUI help;
    [SerializeField] TextMeshProUGUI saveGame;
    [SerializeField] TextMeshProUGUI loadGame;
    [SerializeField] TextMeshProUGUI mainMenu;
    [SerializeField] TextMeshProUGUI quitGame;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}