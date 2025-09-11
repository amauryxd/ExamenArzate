using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConecctions : MonoBehaviour
{
    public void ChangeToGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
