using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : SingletonComponent<PointManager>
{
    public GameObject spawnObjects;
    public GameObject safetyObjects;
    public GameObject hazardObjects;
    public GameObject alarmObjects;

    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> safetyPoints = new List<GameObject>();
    public List<GameObject> hazardPoints = new List<GameObject>();
    public List<GameObject> alarmPoints = new List<GameObject>();

}
