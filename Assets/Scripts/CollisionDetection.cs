using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDetection : MonoBehaviour
{
    public static Action OnRingCollide;
    public static Action<Transform> OnDiamondCollide;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Ring"))
        {
            if (OnRingCollide != null)
            {
                OnRingCollide();
            }
        }
        if (collider.transform.CompareTag("Diamond"))
        {
            if (OnDiamondCollide != null)
            {
                OnDiamondCollide(collider.transform);
            }
        }
    }

}
