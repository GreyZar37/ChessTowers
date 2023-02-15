using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public GameObject bullet;

    public Transform shootingPos;
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public float turnSpeed;


    public float cooldownTimer;
    float currentime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
     


        if (target == null)
        {
            currentime = cooldownTimer;
            return;
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            if (currentime <= 0)
            {
                shooting();
                currentime = cooldownTimer;
            }
            else
            {
                currentime -= Time.deltaTime;
            }
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;

        GameObject nerestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nerestEnemy = enemy;
            }
        }

        if (nerestEnemy != null && shortestDistance <= range)
        {
            target = nerestEnemy.transform;

        }
        else
        {
            target = null;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void shooting()
    {
        Instantiate(bullet, shootingPos.position, transform.rotation);
    }
}
