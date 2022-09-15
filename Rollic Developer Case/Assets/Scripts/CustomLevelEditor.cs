using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(LevelEditor))]
public class CustomLevelEditor : Editor
{
    LevelEditor levelEditor;


    private void OnEnable()
    {
        levelEditor = (LevelEditor)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Spawn Collectible"))
        {
            switch (levelEditor.spawnObject)
            {
                case LevelEditor.ObjectType.Cube: 
                    SpawnSelectedObjects(levelEditor.collectibleList[0], levelEditor.collectibleParent);
                    break;
                case LevelEditor.ObjectType.Ball:
                    SpawnSelectedObjects(levelEditor.collectibleList[1], levelEditor.collectibleParent);
                    break;
                case LevelEditor.ObjectType.Tri:
                    SpawnSelectedObjects(levelEditor.collectibleList[2], levelEditor.collectibleParent);
                    break;
                case LevelEditor.ObjectType.GroundSpikes:
                    SpawnSelectedObjects(levelEditor.collectibleList[3], levelEditor.collectibleParent);
                    break;
                case LevelEditor.ObjectType.SideSpikes:
                    SpawnSelectedObjects(levelEditor.collectibleList[6], levelEditor.collectibleParent);
                    break;
                case LevelEditor.ObjectType.SolidCube:
                    SpawnSelectedObjects(levelEditor.collectibleList[5], levelEditor.collectibleParent);
                    break;
                case LevelEditor.ObjectType.SwingHammer:
                    SpawnSelectedObjects(levelEditor.collectibleList[4], levelEditor.collectibleParent);
                    break;
                case LevelEditor.ObjectType.Counter:
                    SpawnSelectedObjects(levelEditor.collectibleList[7], levelEditor.collectibleParent);
                    break;
            }
           
        }

    }


    void SpawnSelectedObjects(GameObject gameObject, GameObject parent)
    {
        GameObject obj = Instantiate(gameObject, parent.transform);
    }
}
