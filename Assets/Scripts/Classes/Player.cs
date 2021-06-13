using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Data", menuName = "SriptableObjects/SpawnPlayerObject", order = 1)]
public class Player : ScriptableObject
{
    public int id;
    public string email;
    public int isTrainer; //int not bool because sqlite doesn't support bool
    public GameObject playerObject;
    public NavMeshAgent playerAgent;
    public Vector3 currentPosition;
    public int points;

    public void Spawn()
    {
        if (GameManager.instance.isRandomSim)
        {
            int index = Random.Range(0, PointManager.instance.spawnPoints.Count);
            currentPosition = PointManager.instance.spawnPoints[index].transform.position;
        }
        else
        {
            currentPosition = SimulationManager.instance.simulation.spawnPositionObject.transform.position;
        }
        Debug.Log("Current position: " + currentPosition);
        Instantiate(playerObject, currentPosition, playerObject.transform.rotation);
    }
}
