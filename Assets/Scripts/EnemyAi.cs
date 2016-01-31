using UnityEngine;
using Pathfinding;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class EnemyAi : MonoBehaviour {
    public Transform target;
    public Transform firstPlayer;
    public Transform secondPlayer;

    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 1f;
    public ForceMode2D fMode;

    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;
    float rotationResetSpeed = 1.0f;
    public Quaternion originalRotationValue; // declare this as a Quaternion

    public Rigidbody2D bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireDelay = 0.5f;
    public float bulletSpeed= 4f;
    float cooldown;

    private float roundTimeLeft;
    private float startTime;


    void Start()
    {
        var distanceFirstPlayer = Vector3.Distance(firstPlayer.transform.position, transform.position);
        var distanceSecondPlayer = Vector3.Distance(secondPlayer.transform.position, transform.position);

        if (distanceFirstPlayer > distanceSecondPlayer)
        {
            target = secondPlayer;
        }
        else
        {
            target = firstPlayer;
        }

        startTime = Time.time; 
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.Log("pesho");
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());

    }

    IEnumerator UpdatePath()
    {
        var distanceFirstPlayer = Vector3.Distance(firstPlayer.transform.position, transform.position);
        var distanceSecondPlayer = Vector3.Distance(secondPlayer.transform.position, transform.position);

        if (distanceFirstPlayer > distanceSecondPlayer)
        {
            target = secondPlayer;
        }
        else
        {
            target = firstPlayer;
        }

        if (target != null) 
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);
            yield return new WaitForSeconds(1f / updateRate);
        }

        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;    
        }
        else
        {
            Debug.Log("Error "+ p.error);
        }
    }

    void FixedUpdate()
    {
        roundTimeLeft = Time.time - startTime;
        //if (transform.rotation.eulerAngles.z > 25f)
        //{
        //    rb.angularVelocity = 0;
        //    transform.rotation = Quaternion.Lerp(transform.rotation, originalRotationValue, Time.time * 1000);

        //}
        // transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, rotationResetSpeed);

        if (target == null) 
        {
            return;
        }

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return; 
            }

            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;
        if (Vector3.Distance(target.transform.position,transform.position)> 8f)
        {
            rb.AddForce(dir, fMode);
        }
        else
        {
            if (roundTimeLeft >= 2)
            {
                startTime = Time.time;
                roundTimeLeft = 0;
                Rigidbody2D bulletInstance;
                var heading = transform.position - target.position;
                var distance = heading.magnitude;
                var direction = heading / distance;

                bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody2D;
                bulletInstance.AddForce((target.transform.position - transform.position).normalized * bulletSpeed);


                //bulletInstance.AddForce(bulletSpawnPoint.right * bulletSpeed);
            }
        }
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;

        }
    }
}
