using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
    [SerializeField] private PlayerMovment _playerMovment;

    private void OnEnable()
    {
        _playerMovment.LastWayPointTaken += RestartLevel;
    }

    private void OnDisable()
    {
        _playerMovment.LastWayPointTaken -= RestartLevel;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
