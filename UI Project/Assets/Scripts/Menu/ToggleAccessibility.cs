using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ToggleAccessibility : MonoBehaviour
{
    private void OnEnable()
    {
        UAP_AccessibilityManager.PauseAccessibility(true);
    }

    private void OnDisable()
    {
        UAP_AccessibilityManager.PauseAccessibility(false);
    }
}
