using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnNewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnContinue()
    {
        // Wire up save system here later
        Debug.Log("Continue pressed");
    }

    public void OnOptions()
    {
        Debug.Log("Options pressed");
    }

    public void OnCredits()
    {
        Debug.Log("Credits pressed");
    }

    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("Quit pressed"); // shows in editor since Quit doesn't work in editor
    }
}