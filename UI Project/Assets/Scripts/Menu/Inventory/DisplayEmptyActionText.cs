using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEmptyActionText : MonoBehaviour
{
    [SerializeField] GameObject emptyNotification;

    public void CheckForEmptyActions()
    {
        emptyNotification.SetActive(false);
        StartCoroutine("CheckChildren");
    }

    IEnumerator CheckChildren()
    {
        bool activeChildren = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.activeInHierarchy)
            {
                activeChildren = true;
                break;
            }
            yield return null;
        }

        if(!activeChildren)
        {
            emptyNotification.SetActive(true);
        }
    }
}
