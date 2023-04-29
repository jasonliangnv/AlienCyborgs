using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class EnemyAiController : MonoBehaviour
{

    // Player game obj ref
    public GameObject player;

    // Bool check if enemy is first boss
    public bool firstBoss = false;

    // Enemy speed
    public float speed;

    // Varibles for repelling player
    public float pushForce;
    public float pushDistance;
    public float stopDistance;
    // Way point Distance for A*
    // Note: this should in general be <= the node size set under A*Grid gameobject
    public float wayPointDistance;

    private Transform playerPos;
    private Path curPath;
    private int curWayPoint = 0;

    private bool reachedEndOfPath = false;
    public bool stopMove = false;
    private Seeker seeker;

    private void Awake()
    {
        if(firstBoss == true)
        {
            speed = 0.15f;
            pushForce = 1f;
            pushDistance = 0.05f;
            stopDistance = 2f;
            wayPointDistance = 0.28f;
            curWayPoint = 0;
        }
        else
        {
            speed = 0.45f;
            pushForce = 0.4f;
            pushDistance = 0.02f;
            stopDistance = 2f;
            wayPointDistance = 0.28f;
            curWayPoint = 0;
        }

        // Find player
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform;

    }
    // Start is called before the first frame update
    void Start()
    {
        // Get A* seeker component
        seeker = GetComponent<Seeker>();


        // Update path every .3 sec
        InvokeRepeating("UpdatePath", 0f, .3f);
        
    }
    void UpdatePath()
    {

        if (seeker.IsDone())
        {
            // Start new path
            seeker.StartPath(transform.position, playerPos.position, OnPathComplete);
        }
        else
        {
            
        }

    }
    void OnPathComplete(Path path)
    {
        if (!path.error)
        {
            curPath = path;
            curWayPoint = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {


        // Constantly find all other enemies in scene and calc push force
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy != gameObject && Vector3.Distance(transform.position, enemy.transform.position) < pushDistance)
            {
                Vector3 pushDirection = (transform.position - enemy.transform.position).normalized;
                transform.position += pushDirection * pushForce * Time.deltaTime;
            }
        }

        // If too close to player move out the way
        // NOTE: this can cause weird behaviour such as being pushed inside walls
        /*
        if (Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            Vector3 pushDirection = (transform.position - player.transform.position).normalized;
            transform.position += pushDirection * pushForce * Time.deltaTime;
        }
        */


        // A* waypoint code
        // If path is null i.e. at the player then constantly face them
        if (curPath == null)
        {
            Vector2 direction = playerPos.position - transform.position;
            direction.Normalize();
            float inangle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            //transform.rotation = Quaternion.Euler(Vector3.forward * inangle);
            return;
        }


        // Below serves no real purpose 
        if (curWayPoint >= curPath.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {

            reachedEndOfPath = false;
        }

        //have we reached end?
        float distance = Vector3.Distance(transform.position, curPath.vectorPath[curWayPoint]);
        
        if (distance < wayPointDistance)
        {
            // Update way point
            curWayPoint++;
          
        }

        // Get next way point // Get current transform // Calcualte direction to face along path // rotate ai smoothly to always face along path
        Vector2 nextWayPoint = (Vector2)curPath.vectorPath[curWayPoint];
        Vector2 playerVec = (Vector2)playerPos.position;
        Vector2 currPos = transform.position;
        Vector2 newDirection = (playerVec - currPos).normalized;
        float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion newRot = Quaternion.Euler(0, 0, angle);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 3 * Time.deltaTime);


        //move toward player based on a user set distance. Ai will stop moving toward player at set distance
        if (Vector2.Distance(transform.position, playerPos.position) > stopDistance)
        {
            // If the distance from cur pos to player is >  way point dist // move toward player
            transform.position = Vector2.MoveTowards(transform.position, curPath.vectorPath[curWayPoint], speed * Time.deltaTime);
        }
        else
        {
            curPath = null;
            return;
        }

       
    }

    //Draw push sphere of influence
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, pushDistance);
    }
}
