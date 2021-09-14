using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject inputText;
    public Text bestScoreText;

    private void Start()
    {
        GameManager.Instance.LoadHighScore();
        UpdateBestScoreText();
    }
    public void startGame()
    {
        SaveName();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    void SaveName()
    {
        GameManager.Instance.playerName = inputText.GetComponent<Text>().text;
    }

    void UpdateBestScoreText()
    {
        bestScoreText.text = "Best Score: " + GameManager.Instance.highScoreName +
            ": " + GameManager.Instance.highScore;
    }
}
