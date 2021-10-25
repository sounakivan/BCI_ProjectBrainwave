using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    bool state = false;
    
    public void togglePanel()
    {
        if (Panel != null)
        {
            state = !state;
            Panel.SetActive(state);
        }
    }
}
