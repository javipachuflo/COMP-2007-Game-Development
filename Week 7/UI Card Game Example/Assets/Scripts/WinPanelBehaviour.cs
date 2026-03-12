using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinPanelBehaviour : MonoBehaviour 
{
    private Image m_image;

	// Use this for initialization
	void OnEnable () 
    {
        m_image = GetComponent<Image>();
        m_image.enabled = false;
        MessageSystem.onWinScenario += WinScenario;
	}

    void OnDisable()
    {
        MessageSystem.onWinScenario -= WinScenario;
    }

    private void WinScenario()
    {
        m_image.enabled = true;
    }
}
