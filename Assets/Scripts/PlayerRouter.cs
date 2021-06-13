using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRouter : MonoBehaviour
{

    [SerializeField]
    private Player player;

    public GameObject nearestSafeZone;

    public GameObject chosenSafeZone;


    private NavMeshPath newPath;

    [SerializeField]
    private LineRenderer lineRenderer;


    private void Start()
    {
        lineRenderer.GetComponent<LineRenderer>();
        GetNearestDestination();
    }
    public void GetNearestDestination()
    {
        float minimalDistance = Mathf.Infinity;
        foreach (var item in PointManager.instance.safetyPoints)
        {
            Vector3 directionTarget = item.transform.position - player.currentPosition;
            float sqrToTarget = directionTarget.sqrMagnitude;
            if (sqrToTarget < minimalDistance)
            {
                minimalDistance = sqrToTarget;
                nearestSafeZone = item;
                FeedBackManager.instance.nearestSafeZn = nearestSafeZone;
            }


        }

    }

    public void ClickedDestination(Transform newPos)
    {
        chosenSafeZone = newPos.gameObject;
        CalculatePath();
    }

    void CalculatePath()
    {
        newPath = new NavMeshPath();
        NavMesh.CalculatePath(player.currentPosition, chosenSafeZone.transform.position, NavMesh.AllAreas, newPath);
        Vector3[] corners = newPath.corners;
        lineRenderer.positionCount = newPath.corners.Length;
        lineRenderer.SetPositions(corners);
        FeedBackManager.instance.chosenSafeZn = chosenSafeZone;
        Debug.Log("Making Path");
    }
}
