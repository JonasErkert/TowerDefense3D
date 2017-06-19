using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int waypointIndex = 0;
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();  
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        // Da Unity die "Update" Funktionen hierarchisch aufruft,
        // wird der Gegner wieder schneller wenn er nicht vom Laser getroffen wird.
        // (Die eine Update- Funktion überschreibt die speed- Variable der anderen)
        enemy.speed = enemy.startSpeed;
    }
    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            PathEnds();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void PathEnds()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
