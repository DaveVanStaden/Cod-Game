using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float PlayerHp;
    void Update()
    {
        if (PlayerHp <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
