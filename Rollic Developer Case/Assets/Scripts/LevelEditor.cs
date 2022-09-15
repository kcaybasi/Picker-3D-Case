
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LevelEditor : EditorWindow
{
    GameObject levelTemplate;
    string userString;

    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow<LevelEditor>();
    }

    private void OnGUI()
    {
       // GUILayout.Label("This is a level editor", EditorStyles.boldLabel);

        userString = EditorGUILayout.TextField("Level Name", userString);

        if(GUILayout.Button("Generate Level"))
        {
            var newscene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            newscene.name = userString;

            levelTemplate = Resources.Load("LevelTemplate") as GameObject;
            Instantiate(levelTemplate);

            EditorSceneManager.SaveScene(newscene, userString+".unity");
            
        }
    }
}
