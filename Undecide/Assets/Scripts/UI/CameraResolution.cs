using UnityEngine;
using System.Collections.Generic;

/**
 * 날짜: 2022.05.24
 * 작성자: 박준우
 * 
 * 다양한 스마트픈의 화면비에 대응할 수 있도록 레더박스를 활용하여 화면비 계산
 */

public class CameraResolution : MonoBehaviour
{
    #region Pola
    private int ScreenSizeX = 0;
    private int ScreenSizeY = 0;
    #endregion

    #region metody

    #region rescale camera
    private void RescaleCamera()
    {

        if (Screen.width == ScreenSizeX && Screen.height == ScreenSizeY) return;

        float targetaspect = 9.0f / 16.0f; // (가로 9 / 세로 16 비율)
        float windowaspect = (float)Screen.width / (float)Screen.height;    //Screen의 가로 / Screen의 세로 비율
        float scaleheight = windowaspect / targetaspect; // Screen의 비율이 target 비율과 동일한지 비교
        Camera camera = GetComponent<Camera>();

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        ScreenSizeX = Screen.width;
        ScreenSizeY = Screen.height;
    }
    #endregion

    #endregion

    #region metody unity

    void OnPreCull()
    {
        if (Application.isEditor) return;
        Rect wp = Camera.main.rect;
        Rect nr = new Rect(0, 0, 1, 1);

        Camera.main.rect = nr;
        GL.Clear(true, true, Color.black);

        Camera.main.rect = wp;

    }

    // Use this for initialization
    void Start()
    {
        RescaleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        RescaleCamera();
    }
    #endregion
}
