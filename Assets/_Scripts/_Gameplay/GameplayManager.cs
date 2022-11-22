using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager gameplay;

    public GameObject winPanel;
    public GameObject deadPanel;

    public bool isWon = false;
    public bool isDead = false;

    void Awake()
    {
        if(!gameplay)
        {
            gameplay = this;
        }

        winPanel.SetActive(false);
        deadPanel.SetActive(false);

    }

    public void WinPanelToggle()
    {
        isWon = true;
        
        winPanel.SetActive(true);
    }

    public void DeadPanelToggle()
    {
        isDead = true;
        
        deadPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
