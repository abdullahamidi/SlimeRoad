using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformCreater : MonoBehaviour
{
    [SerializeField]
    Transform player;
    List<Transform> platforms = new List<Transform>();
    float distanceThreshold = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform platform in transform)
        {
            platforms.Add(platform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x < platforms[0].position.x - distanceThreshold)
        {
            MovePlatform2End();
        }
    }

    private void MovePlatform2End()
    {
        var targetPosX = platforms.Last().position.x - 1.5f;
        platforms.First().position = new Vector3(targetPosX, platforms.First().position.y);
        platforms.Add(platforms.First());
        platforms.RemoveAt(0);
    }
}
