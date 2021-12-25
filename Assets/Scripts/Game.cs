using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public SnakeMovement Controls;
    int _points = 0;
    public GameObject PointsText;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get;  set; }
    public static object PhysicsSceneExtensions { get;  set; }

    public void OnPlayerDied()
    {
       if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        Restart(); 
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Finish();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 1);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    private void Restart()
    {
        SceneManager.LoadScene(2);
    }

    private void Finish()
    {
        SceneManager.LoadScene(3);
    }

    public void Count()
    {
        _points++;
        PointsText.GetComponent<Text>().text = _points.ToString();
    }
}