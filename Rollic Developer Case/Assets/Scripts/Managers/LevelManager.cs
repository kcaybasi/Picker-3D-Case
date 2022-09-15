using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _levelList = new List<GameObject>();


    private void Start()
    {
        var newScene = EditorSceneManager.CreateScene("Level 1");
        newScene.isSubScene = true;
        EditorSceneManager.OpenScene(newScene.path);

        
    }
}
