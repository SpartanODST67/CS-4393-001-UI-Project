using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickupNotification : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI message;
    [SerializeField] int lifeSpan;

    public void SetItem(string itemName)
    {
        this.message.text = itemName + " Collected";
    }

    public void SetMessage(string message)
    {
        this.message.text = message;
    }

    private void OnEnable()
    {
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown()
    {
        while(lifeSpan > 0)
        {
            yield return new WaitForSeconds(1);
            lifeSpan--;
        }
        Destroy(gameObject);
    }
}
