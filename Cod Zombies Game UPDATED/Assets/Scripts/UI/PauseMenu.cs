using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField]private GameObject MenuHolder;
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MenuHolder.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void unPause()
    {
        MenuHolder.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
