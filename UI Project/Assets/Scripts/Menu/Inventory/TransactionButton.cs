using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionButton : MonoBehaviour
{
    [SerializeField] int moneyAmount;

    public void SetMoneyAmount(int moneyAmount)
    {
        this.moneyAmount = moneyAmount;
    }

    public int GetMoneyAmount()
    {
        return moneyAmount;
    }
}
