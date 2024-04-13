using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    [SerializeField] bool autoDisable = true;
    [SerializeField] int lifeSpan = 5;

    private void OnEnable()
    {
        if(autoDisable)
        {
            StartCoroutine("CountDown");
        }
    }

    IEnumerator CountDown()
    {
        for(int i = lifeSpan; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }
        gameObject.SetActive(false);
    }
}
