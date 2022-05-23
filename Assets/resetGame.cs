using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class resetGame : MonoBehaviour
{
    public void HardResetGame()
    {
        File.Delete (Application.dataPath + "/player.ezeSave");
        //UnityEditor.AssetDatabase.Refresh();
        SceneManager.LoadScene ("SampleScene");
    }
}
