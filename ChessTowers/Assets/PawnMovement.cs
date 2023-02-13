using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PawnMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;

    Transform target;
    int wavepointIndex;

    // Start is called before the first frame update
    void Start()
    {
        target = PathGenerator.points[0];
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= PathGenerator.points.Length)
        {
            Destroy(gameObject);
        }
        else
        {
            wavepointIndex++;
            target = PathGenerator.points[wavepointIndex];
        }
      
    }
}
