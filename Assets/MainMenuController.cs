using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;

    public void StartGame()
    {

    }
    public void ExitGame()
    {

    }

    public void OpenSettings()
    {
        MainMenuPanel.active = false;
        SettingsPanel.active = true;
    }

    public void ReturnToMainMenuPanel()
    {
        MainMenuPanel.active = true;
        SettingsPanel.active = false;
    }
}
