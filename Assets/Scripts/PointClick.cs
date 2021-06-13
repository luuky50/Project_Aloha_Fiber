using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PointClick : MonoBehaviour
{

    public enum Type
    {
        SafetyPoint,
        SpawnPoint,
        AlarmPoint,
        HazardPoint,
    }
    public Type type;

    [SerializeField]
    private PlayerRouter playerRouter;

    [SerializeField]
    private GameObject endPoint;

    private void Awake()
    {
        if(type.ToString() == "SpawnPoint" && GameManager.instance.player.isTrainer == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        string selectedPoint = type.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            switch (selectedPoint)
            {
                case "SafetyPoint":
                    playerRouter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRouter>();
                    GetComponent<AudioSource>().Play();
                    playerRouter.ClickedDestination(endPoint.transform);
                    break;

                case "SpawnPoint":
                    GetComponent<AudioSource>().Play();
                    SimulationManager.instance.simulation.spawnPosition = transform.parent.gameObject.name;
                    SimulationManager.instance.simulation.spawnPositionObject = transform.parent.gameObject;
                    Debug.Log("Selected spawnposition:" + SimulationManager.instance.simulation.spawnPosition);
                    UIManager.instance.infoText.text = "Kies een locatie waar het alarm afgaat.";
                    PointManager.instance.spawnObjects.SetActive(false);
                    PointManager.instance.alarmObjects.SetActive(true);
                    break;
                case "AlarmPoint":
                    GetComponent<AudioSource>().Play();
                    SimulationManager.instance.simulation.alarmLocation = transform.parent.gameObject.name;
                    PointManager.instance.alarmObjects.SetActive(false);
                    UIManager.instance.infoText.text = "Kies een locatie waar het ongeval gebeurd.";
                    PointManager.instance.hazardObjects.SetActive(true);
                    break;
                case "HazardPoint":
                    GetComponent<AudioSource>().Play();
                    SimulationManager.instance.simulation.hazardLocation = transform.parent.gameObject.name;
                    PointManager.instance.hazardObjects.SetActive(false);
                    UIManager.instance.infoText.text = "Kies de windrichting";
                    UIManager.instance.windScreen.gameObject.SetActive(true);
                    //Choosing wind direction
                    break;

            }
        }
    }
    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
