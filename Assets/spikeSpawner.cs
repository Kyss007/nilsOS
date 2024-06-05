using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeSpawner : MonoBehaviour
{
    public GameObject spikeOBJ;
    public float waitBetweenSpike = 1f;
    public float maxRandomBetweenSpike = 2f;


    private void Start()
    {
        StartCoroutine(spawnSpike());
    }

    public IEnumerator spawnSpike()
    {
        yield return new WaitForSeconds(waitBetweenSpike + Random.Range(0, maxRandomBetweenSpike));

        GameObject spike = Instantiate(spikeOBJ, this.transform);

        StartCoroutine(spawnSpike());
    }
}
