using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Image visualBar;
    [SerializeField] int maxValue = 1;
    [SerializeField] int minValue = 0;
    [SerializeField] int currentValue = 1;
    private float progress;

    public void UpdateProgress(int maxValue, int minValue, int currentValue)
    {
        this.maxValue = maxValue;
        this.minValue = minValue;
        if(currentValue > maxValue)
        {
            currentValue = maxValue;
        }
        if(currentValue < minValue)
        {
            currentValue = minValue;
        }
        this.currentValue = currentValue;
        SetProgress();
    }

    public void SetMaxValue(int value)
    {
        maxValue = value;
        SetProgress();
    }

    public void SetCurrentValue(int value)
    {
        currentValue = value;
        if (currentValue > maxValue)
        {
            currentValue = maxValue;
        }
        SetProgress();
    }

    private void SetProgress()
    {
        progress = (float) (currentValue - minValue) / (maxValue - minValue);
        DisplayProgress();
    }

    private void DisplayProgress()
    {
        visualBar.transform.localScale = new Vector3(progress, visualBar.transform.localScale.y, visualBar.transform.localScale.z);
    }

}