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
        jumpFactorX = 0f;
        StartCoroutine(JumpPlayer());
    }

    IEnumerator JumpPlayer()
    {
        while (true)
        {
            transform.DOLocalJump(transform.localPosition + Vector3.left * jumpFactorX, jumpPower, 1, jumpDuration).SetEase(Ease.Linear);
            yield return new WaitForSeconds(jumpDuration);
        }
    }

}
