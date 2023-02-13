using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject pawn;
    [SerializeField] Transform spawnPoint;

    public int maxPawns;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawner()
    {
        while (maxPawns > 0)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(pawn, spawnPoint.position, Quaternion.identity);
            maxPawns--;
        }
     
    }
}
