using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public const int MAX_SCENES = 50;

    // Data to be saved
    public int saveScene;

    public Vector3 savePosition;

    public float saveHealth;

    public int saveScore;

    public int saveWeaponId;
    
    public bool[][] saveGameSceneStatus;

    public void SaveGame ()
    {
        //===================
        // Coletar dados aqui
        //===================

        Save.Save(this);
    }

    public void LoadGame ()
    {
        GameData data = Save.LoadPlayer();
       
        if (data != null)
        {
            //===================
            // Setar dados aqui
            //===================
        }
    }
}
