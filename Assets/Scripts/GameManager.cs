using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    CollisionDetection collisionDetection;
    [SerializeField]
    RingSpawner ringSpawner;
    [SerializeField]
    RectTransform restartPanel;
    [SerializeField]
    Text inGameScoreText;
    [SerializeField]
    Text restartPanelScoreText;

    int collectedDiamond = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        CollisionDetection.OnDiamondCollide += CollectDiamond;
        CollisionDetection.OnRingCollide += ShowRestartMenu;
    }

    private void CollectDiamond(Transform ring2Destroy)
    {
        collectedDiamond++;
        inGameScoreText.text = collectedDiamond.ToString();
        ringSpawner.DestroyRing(ring2Destroy);
        ringSpawner.SpawnRing();
    }

    private void ShowRestartMenu()
    {
        Time.timeScale = 0f;
        restartPanelScoreText.text = collectedDiamond.ToString();
        restartPanel.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        restartPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
