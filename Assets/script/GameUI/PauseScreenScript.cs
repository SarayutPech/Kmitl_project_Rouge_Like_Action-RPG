using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour
{
    [SerializeField]
    GameObject pauseScreen;
    [SerializeField]
    Button resume_Btn, retrun_Btn, exit_Btn;
    [SerializeField]
    TextMeshProUGUI return_Text;

    private Scene scene;

    void Start()
    {
        resume_Btn.onClick.AddListener(ResumeGame);
        retrun_Btn.onClick.AddListener(ReturnBtn);
        exit_Btn.onClick.AddListener(ExitGame);

        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            Debug.Log("pause");
            pauseScreen.SetActive(!pauseScreen.activeSelf);

            UpdateReturnText();      
        }

        if (pauseScreen.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void UpdateReturnText()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Lobby_Town")
        {
            return_Text.text = "Title Screen";
        }
        else
        {
            return_Text.text = "Lobby Town";
        }
    }

    private void ResumeGame()
    {
        pauseScreen.SetActive(false);
    }

    private void ReturnBtn()
    {
        scene = SceneManager.GetActiveScene();
        
        //Destroy Player Object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject gameSystem = GameObject.FindGameObjectWithTag("GameSystem");        
        
        

        if (scene.name == "Lobby_Town")
        {

            GameObject saveData = GameObject.FindGameObjectWithTag("SaveData");
            
            SceneManager.LoadScene("Title_Screen");

            Destroy(saveData);

        }
        else
        {
            SceneManager.LoadScene("Lobby_Town");       
        }

        Destroy(player);
        Destroy(gameSystem);
    }

    private void ExitGame()
    {
        Application.Quit();
    }



}
