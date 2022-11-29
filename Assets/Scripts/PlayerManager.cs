using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float PlayerSpeed = 5f;
    public EnemyManager EnemyManager;
    //Due to lack of time, I am reusing uiInputModule
    public InputSystemUIInputModule Input;
    // Start is called before the first frame update
    void Start()
    {
        Input.cancel.action.performed += BackToMainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision.gameObject.name);
            EnemyManager.StopEnemy(collision.gameObject);
        }
    }

    private void BackToMainMenu(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    private void MovePlayer()
    {
        transform.Translate(Input.move.action.ReadValue<Vector2>() * PlayerSpeed * Time.deltaTime);
    }
}
