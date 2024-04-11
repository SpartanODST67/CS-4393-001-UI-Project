using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] List<GameObject> speechBubbles;
    private GameObject activeBubble;

    private void Start()
    {
        if (activeBubble == null)
        {
            activeBubble = speechBubbles[0];
        }
        activeBubble.SetActive(true);
    }

    public void SetActiveBubble(int index)
    {
        activeBubble.SetActive(false);
        activeBubble = speechBubbles[index];
        activeBubble.SetActive(true);
    }

    public void SetNeutral()
    {
        activeBubble.SetActive(false);
        activeBubble = speechBubbles[0];
        activeBubble.SetActive(true);
    }

    public void SetAlert()
    {
        activeBubble.SetActive(false);
        activeBubble = speechBubbles[1];
        activeBubble.SetActive(true);
    }

    public void SetDone()
    {
        activeBubble.SetActive(false);
        activeBubble = speechBubbles[2];
        activeBubble.SetActive(true);
    }

}
