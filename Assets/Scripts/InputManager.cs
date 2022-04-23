using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    PlayerHorizontalMovement playerHorizontalMovement;
    [SerializeField]
    DynamicJoystick joystick;
    [SerializeField]
    Text tapToPlayText;
    bool isGameStarted = false;
    bool isTapped = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (isGameStarted == true)
            return;
        isTapped = true;
        StartCoroutine(WaitUntilBallGrounded());

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isGameStarted == false)
            return;
    }

    private void Update()
    {
        if (isTapped == true && playerMovement.transform.position.y <= 0.65f)
        {
            isGameStarted = true;
            joystick.enabled = true;
            tapToPlayText.enabled = false;
        }
    }

    IEnumerator WaitUntilBallGrounded()
    {
        yield return new WaitUntil(() => isGameStarted);
        playerHorizontalMovement.enabled = true;
        playerMovement.jumpFactorX = 3.0f;
    }
}
