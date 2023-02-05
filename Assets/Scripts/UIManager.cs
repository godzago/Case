using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseGame;
    [SerializeField] GameObject resumeGame;
    [SerializeField] GameObject resume_imge;
    [SerializeField] GameObject Timmer;
    [SerializeField] GameObject ScoreArea;

    [SerializeField] GameObject FinishArea_;
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseGame.SetActive(false);
        resumeGame.SetActive(true);
        resume_imge.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseGame.SetActive(true);
        resumeGame.SetActive(false);
        resume_imge.SetActive(false);
    }

    public void FinishArea()
    {
        FinishArea_.SetActive(true);
        Timmer.SetActive(false);
        ScoreArea.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
