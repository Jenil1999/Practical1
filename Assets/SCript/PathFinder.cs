using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Transform PathPrefebs;
    [SerializeField] int MoveSpeed = 5;
    List<Transform> WayPoints;
    int WayPointIndex = 0;
    void Start()
    {
        WayPoints = GetWayPoints();
        transform.position = WayPoints[WayPointIndex].position; //Start Position
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) //Detect Mouse Click
        {
            FollowPath();
        }
    }


    List<Transform> GetWayPoints()  //List Of WayPoints In Path
    {
        List<Transform> WayPoints = new List<Transform>();
        foreach (Transform child in PathPrefebs)
        {
            WayPoints.Add(child);
        }
        return WayPoints;
    }

    void FollowPath()   //Follow Path
    {
        Vector3 targetPosition = WayPoints[WayPointIndex].position;
        float delta = MoveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

        if (transform.position == targetPosition)
        {
            WayPointIndex++;
        }
        int list_lenght = WayPoints.Count;

        if (list_lenght == WayPointIndex)
        {
            WayPointIndex = 0;
        }
    }

}
