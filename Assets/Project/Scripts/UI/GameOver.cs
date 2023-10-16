using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverScreen;

    void OnEnable()
    {
        StaticEvents.Combat.OnPlayerDeath += Show;
    }
    void OnDisable()
    {
        StaticEvents.Combat.OnPlayerDeath -= Show;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Show()
    {
        gameOverScreen.SetActive(true);
    }
    public void Hide()
    {
        gameOverScreen.SetActive(false);
    }
}
