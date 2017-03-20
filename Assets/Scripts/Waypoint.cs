using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour{

    private List<Vector2> waypointList;

    public Waypoint()
    {
        waypointList = CreateWaypointList();
    }
    public List<Vector2> CreateWaypointList()
    {
        List<Vector2> wplist = new List<Vector2>();
        for (float i = -12f; i >= 12f; i+=2f)
        {
           for(float c = -6f; c >= 6f; c+=1f)
            {
                Vector2 temp;
                temp.x = i;
                temp.y = c;
                wplist.Add(temp);
            }
        }
        return waypointList;
    }
    public List<Vector2> getList()
    {
        return waypointList;
    }
}
