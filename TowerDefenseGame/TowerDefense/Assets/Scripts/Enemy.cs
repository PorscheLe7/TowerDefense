
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    // Enemy speed
    public float speed = 10f;

    // Current Waypoint target
    private Transform target;
    

    private int wavepointIndex = 0;

    // Initializing the target to the first Waypoint
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Every time the frame that is called, move towards the target.
    // First step is to find a vector ( direction ) towards the target ( Destination subtracted by current position )
    // Move the object based on the translation given by the vector ( dir )
    // time.deltaTime is used to fix FPS issues on different computers so that speed is constant regardless of high or low fps
    // Space.World is the space moved relative to the world in the space
    // If object is within 0.4 frames, get the next waypoint
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if ( wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
