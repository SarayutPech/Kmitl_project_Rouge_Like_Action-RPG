using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenMenu : MonoBehaviour
{

    public Button start_Btn;
    public Button setting_Btn;
    public Button exit_Btn;

    private void Start()
    {
        start_Btn.onClick.AddListener(StartGame);
        exit_Btn.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SaveLoding_Screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
