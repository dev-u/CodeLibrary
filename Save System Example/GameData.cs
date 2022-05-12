using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    // N° da Cena
    public int scene;

    // Posição
    public float[] position;

    // Vida
    public float health;

    // Pontuação
    public float score;

    // ID da Arma equipada
    public int weaponId;

    // Estado das cenas
    public bool[][] gameSceneStatus;

    public GameData (SaveController data)
    {
        scene = data.saveScene;

        position = new float[3];
        position[0] = data.savePosition.x;
        position[1] = data.savePosition.y;
        position[2] = data.savePosition.z;

        health = data.saveHealth;

        weaponId = data.saveWeaponId;

        score = data.saveScore;

        eventStatus = data.saveGameSceneStatus;
    } 
}
