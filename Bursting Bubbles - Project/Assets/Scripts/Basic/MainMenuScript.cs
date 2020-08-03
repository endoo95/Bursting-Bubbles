using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Goodbye");
        Application.Quit();
    }
}
