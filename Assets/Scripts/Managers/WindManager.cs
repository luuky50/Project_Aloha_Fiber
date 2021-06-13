using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum Direction
{
    Noord,
    Oost,
    Zuid,
    West

}
public class WindManager : MonoBehaviour
{

    private Direction currentDirection;
    [SerializeField]
    private GameObject arrowRotationPoint;

    [SerializeField]
    private GameObject smoke;

    [SerializeField]
    private TextMeshProUGUI windText;


    void Start()
    {
        arrowRotationPoint.SetActive(true);
        if (GameManager.instance.player.isTrainer == 1)
        {
            arrowRotationPoint.SetActive(false);
        }
        SetEmployeeWind();
    }

    void SetEmployeeWind()
    {
        if (GameManager.instance.isRandomSim)
        {
            currentDirection = (Direction)Random.Range(0, 4);
        }
        else
        {
            //North = 0, East = 1, South = 2, West = 3
            currentDirection = (Direction)SimulationManager.instance.simulation.windDirection;
        }
        string dir = currentDirection.ToString();
        windText.text = "Wind directie: " + dir;
        Debug.Log("Wind directie: " + dir);
        switch (dir)
        {
            case "Noord":
                arrowRotationPoint.transform.Rotate(0, 0, 0);
                smoke.transform.Rotate(0, 0, 0);
                break;
            case "Oost":
                arrowRotationPoint.transform.Rotate(0, 90, 0);
                smoke.transform.Rotate(0, 90, 0);
                break;
            case "Zuid":
                arrowRotationPoint.transform.Rotate(0, 180, 0);
                smoke.transform.Rotate(0, 180, 0);
                break;
            case "West":
                arrowRotationPoint.transform.Rotate(0, 270, 0);
                smoke.transform.Rotate(0, 270, 0);
                break;

            default:
                Debug.LogError("No wind direction given");
                break;
        }
    }

    public void SetTrainerWind(string dir)
    {
        switch (dir)
        {
            case "Noord":
                SimulationManager.instance.simulation.windDirection = 0;
                break;
            case "Oost":
                SimulationManager.instance.simulation.windDirection = 1;
                break;
            case "Zuid":
                SimulationManager.instance.simulation.windDirection = 2;
                break;
            case "West":
                SimulationManager.instance.simulation.windDirection = 3;
                break;
            default:
                Debug.LogError("No wind direction given");
                break;
        }
        SimulationManager.instance.CompleteSimulation();
    }
}
