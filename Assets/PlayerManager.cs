using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float PlayerSpeed = 5f;
    //Due to lack of time, I am reusing uiInputModule
    public InputSystemUIInputModule Input;
    // Start is called before the first frame update
    void Start()
    {
        Input.cancel.action.performed += BackToMainMenu;
    }

    private void BackToMainMenu(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    private void MovePlayer()
    {
        transform.Translate(Input.move.action.ReadValue<Vector2>() * PlayerSpeed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
