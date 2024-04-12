using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Image visualbar;
    [SerializeField] int maxValue = 1;
    [SerializeField] int currentValue = 1;
    private float progress;

    public void UpdateProgress(int maxValue, int currentValue)
    {
        this.maxValue = maxValue;
        if(currentValue > maxValue)
        {
            currentValue = maxValue;
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
        progress = (float) currentValue / maxValue;
        DisplayProgress();
    }

    private void DisplayProgress()
    {
        visualbar.transform.localScale = new Vector3(progress, visualbar.transform.localScale.y, visualbar.transform.localScale.z);
    }

}