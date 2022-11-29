using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public InputSystemUIInputModule UiInput;
    public void Start()
    {
        UiInput.cancel.action.performed += ReturnOnCancel;
    }

    private void ReturnOnCancel(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        ReturnToMainMenuPanel();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
