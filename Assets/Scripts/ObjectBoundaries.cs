using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBoundaries : MonoBehaviour
{
    [SerializeField]
    Mesh platformMesh;
    [SerializeField]
    Transform platform;
    public Vector3 PlatformBoundarySize => new Vector3(platformMesh.bounds.size.x * platform.localScale.x,
        platformMesh.bounds.size.y * platform.localScale.y,
        platformMesh.bounds.size.z * platform.localScale.z);// platformMesh.bounds.size * platform.localScale;

    [SerializeField]
    Mesh ballMesh;
    [SerializeField]
    Transform ball;
    public Vector3 BallBoundarySize => new Vector3(ballMesh.bounds.size.x * ball.localScale.x,
        ballMesh.bounds.size.y * ball.localScale.y,
        ballMesh.bounds.size.z * ball.localScale.z);
    [SerializeField]
    Mesh ringMesh;
    [SerializeField]
    Transform ring;
    public Vector3 RingBoundarySize => new Vector3(ringMesh.bounds.size.x * ring.localScale.x,
        ringMesh.bounds.size.y * ring.localScale.y,
        ringMesh.bounds.size.z * ring.localScale.z);


}
