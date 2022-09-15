using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public enum ObjectType { Cube, Ball, Tri, GroundSpikes, SwingHammer, SolidCube, SideSpikes, Counter }
    public ObjectType spawnObject;

    public GameObject collectibleParent,obstacleParent,counterParent;
    public List<GameObject> collectibleList = new List<GameObject>();
    

 
}
