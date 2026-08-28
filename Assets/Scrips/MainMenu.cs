using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
      public void StartGame()
    {
        SceneManager.LoadScene("Load");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}