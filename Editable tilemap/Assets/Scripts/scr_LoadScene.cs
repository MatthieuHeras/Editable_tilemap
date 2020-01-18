using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_LoadScene : MonoBehaviour
{
    public void load_scene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void quit_game()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
