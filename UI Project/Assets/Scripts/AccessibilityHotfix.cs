using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessibilityHotfix : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (UAP_AccessibilityManager.IsActive())
            {
                UAP_AccessibilityManager.PauseAccessibility(true);
            }
            else
            {
                UAP_AccessibilityManager.PauseAccessibility(false);
            }
        }
    }
}
