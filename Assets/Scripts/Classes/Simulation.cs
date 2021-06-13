using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation
{
    public string simulationName;
    public string spawnPosition;
    public GameObject spawnPositionObject;
    public string alarmLocation;
    public string hazardLocation;
    public int windDirection;

    public string GetInfo()
    {
        return simulationName + " " + spawnPosition + " " + spawnPositionObject.ToString() + " " + alarmLocation + " " + hazardLocation + " " + windDirection.ToString();
    }

}

