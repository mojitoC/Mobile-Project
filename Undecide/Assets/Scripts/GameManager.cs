using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject wait, game, gameover;
    private Touch tempTouch;
    public TextMeshProUGUI scoreText;
    private float score;


    
    public static bool isGameStart;
    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart && Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(0) == false)
        {

            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouch = Input.GetTouch(i);         
                if (tempTouch.phase == TouchPhase.Began)       //해당 터치가 시작됐다면.
                {
                    wait.SetActive(false);
                    game.SetActive(true);
                    isGameStart = true;
                    break;
                }

            }

        }
        if (isGameStart)
        {
            score += Time.deltaTime;
            scoreText.text = (int)score + " m";
        }
        if (PlayerController.isdie)
        {
            isGameStart = false;
            game.SetActive(false);
            gameover.SetActive(true);
        }

    }


}

