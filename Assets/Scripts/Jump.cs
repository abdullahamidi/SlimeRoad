using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpPower = 1.0f;
    public float jumpFactorX = 3.0f;
    public float jumpDuration = 0.7f;
    float timer = 0f;
    private void Start()
    {
        JumpPlayer();
    }
    void Update()
    {
        if (timer >= jumpDuration)
        {
            JumpPlayer();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    void JumpPlayer()
    {
        //transform.DOJump(new Vector3(transform.parent.position.x, transform.position.y, transform.position.z), jumpPower, 1, jumpDuration).SetEase(Ease.Linear);
        transform.DOLocalJump(transform.localPosition + Vector3.left * jumpFactorX, jumpPower, 1, jumpDuration).SetEase(Ease.Linear);
    }

}
