using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainGUI : MonoBehaviour
{
    [SerializeField] Text BestScoreText;

    private void Start()
    {
        BestScoreText.text = $"Best Score: {PlayerData.Instance.bestPlayer}: {PlayerData.Instance.bestScore}";
    }

    public void SetPlayerName(string name)
    {
        PlayerData.Instance.PlayerName = name;
        Debug.Log($"Player name is {PlayerData.Instance.PlayerName}");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Load main scene");
    }
}
