using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailButton : MonoBehaviour
{
    [Header("Information to be shown")]
    [SerializeField] string detail;
    [Multiline(10)]
    [SerializeField] string detailInformation;

    [Header("Button Information")]
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] Button myButton;

    [Header("Elements to be changed")]
    [SerializeField] GameObject detailsPage;
    [SerializeField] TextMeshProUGUI detailTitle;
    [SerializeField] TextMeshProUGUI detailInformationDisplay;

    private void Start()
    {
        myText.text = detail;
        myButton.onClick.AddListener(() =>
        {
            detailsPage.SetActive(true);
            detailTitle.text = detail;
            detailInformationDisplay.text = detailInformation;
        });
    }
}
