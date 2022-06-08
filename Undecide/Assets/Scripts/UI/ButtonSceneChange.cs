using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * 날짜: 2022.05.26
 * 작성자: 박준우 (Park JunWoo)
 * 
 * 버튼을 클릭 했을 때 해당 버튼의 Scene 화면으로 이동
 * 
 * 
 * 날짜: 2022.06.02
 * 작성자: 최정한
 * 
 * pause 버튼 클릭 했을 때 time.timescale 값 0으로 변경
 * pause 
 */

public class ButtonSceneChange : MonoBehaviour
{
    public GameObject gameOver, wait, play, pause;
    public void SceneChange()
    {
        switch(this.gameObject.name)
        {
            case "Animals Button":
                SceneManager.LoadScene("Character Select");
                break;
            case "Option Button":
                SceneManager.LoadScene("Option");
                break;
            case "Ranking Button":
                SceneManager.LoadScene("Ranking");
                break;
            case "Home Button":
                Time.timeScale = 1.0f;
                PlayerController.isdie = false;
                gameOver.SetActive(false);
                wait.SetActive(true);
                SceneManager.LoadScene("Home");
                break;
            case "Back Button":
                SceneManager.LoadScene("Home");
                break;
            case "Guest Login": //임시
                SceneManager.LoadScene("Home");
                break;
            case "Pause":
                Time.timeScale = 0f;
                play.SetActive(false);
                pause.SetActive(true);
                break;
            case "Restart":
                Time.timeScale = 1f;
                play.SetActive(true);
                pause.SetActive(false);
                break;
            case "Stop":
                Time.timeScale = 1f;
                pause.SetActive(false);
                SceneManager.LoadScene("Home");
                break;

        }
    }
}