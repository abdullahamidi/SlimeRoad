using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float jumpPower = 1.0f;
    public float jumpFactorX = 3.0f;
    public float jumpDuration = 0.7f;

    private void Start()
    {
        //leftPlatformBound = -platform.bounds.size.z / 2 + transform.localScale.z / 2;
        //rightPlatformBound = platform.bounds.size.z / 2 - transform.localScale.z / 2;
        jumpFactorX = 0f;
        StartCoroutine(JumpPlayer());
        //enabled = false;
    }
    //void Update()
    //{
    //    var direction = joystick.Horizontal;
    //    var horizontal = direction * horSpeed * Time.deltaTime * Vector3.forward;
    //    if (transform.position.z + horizontal.z < rightPlatformBound && transform.position.z + horizontal.z > leftPlatformBound)
    //    {
    //        transform.position += horizontal;
    //    }
    //}

    IEnumerator JumpPlayer()
    {
        while (true)
        {
            transform.DOLocalJump(transform.localPosition + Vector3.left * jumpFactorX, jumpPower, 1, jumpDuration).SetEase(Ease.Linear);
            yield return new WaitForSeconds(jumpDuration);
        }
    }

}
