using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveLoad : MonoBehaviour
{
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.playerPos[0];
        position.y = data.playerPos[1];
        position.z = data.playerPos[2];
        transform.position = position;
    }
}
