using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RingSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ring;
    List<Transform> rings = new List<Transform>();
    [SerializeField]
    ObjectBoundaries objectBoundaries;
    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    float spawnRangeX = 10f;
    [SerializeField, Range(0, 1)]
    float spawnChance;

    private void Start()
    {
        foreach (Transform ring in transform)
        {
            rings.Add(ring);
        }
        transform.position = new Vector3(transform.position.x, playerMovement.jumpPower, transform.position.z);
    }
    private Vector3 RandomPosition()
    {
        Vector3 position;
        position = new Vector3(rings.Last().position.x - playerMovement.jumpFactorX,
            playerMovement.jumpPower,
            Random.Range(-objectBoundaries.PlatformBoundarySize.z / 2 + objectBoundaries.RingBoundarySize.z / 2, objectBoundaries.PlatformBoundarySize.z / 2 - objectBoundaries.RingBoundarySize.z / 2)
            );
        return position;
    }

    public void SpawnRing()
    {
        if (spawnChance > Random.value)
        {
            var newRing = Instantiate(ring, RandomPosition(), Quaternion.identity, transform);
            rings.Add(newRing.transform);
        }
    }

    public void DestroyRing(Transform ring2Destroy)
    {
        int indexOfRing = rings.FindIndex(ring => ring.position == ring2Destroy.position);
        Destroy(rings[indexOfRing].gameObject);
        rings.RemoveAt(indexOfRing);
    }
}
