using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Игра закрылась");
    }
}
