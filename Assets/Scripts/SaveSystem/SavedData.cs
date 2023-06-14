using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public string level;
    public float health;
    public float[] position;

    public SavedData(HealthPlayer player){
        health = player.health;
        level = HealthPlayer.level;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}
