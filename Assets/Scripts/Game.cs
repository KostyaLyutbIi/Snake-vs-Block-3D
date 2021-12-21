using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public SnakeMovement Controls;

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
        Debug.Log("Game Over");
        ReloadLevel();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        Debug.Log("You Won");
        ReloadLevel();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}