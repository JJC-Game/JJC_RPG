using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class UIManager : MonoBehaviour
{
    UIControl systemUI;
    UIControl gameClearUI;

    bool isGameClear = false;
    bool isGameClearComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        systemUI = new UIControl();
        systemUI.Initialize(GameObject.Find("SystemUI").transform as RectTransform, 400);
        systemUI.ChangeState(UIControl.ANIME.eSHOW);
        gameClearUI = new UIControl();
        gameClearUI.Initialize(GameObject.Find("GameClearUI").transform as RectTransform, 1920);
        gameClearUI.ChangeState(UIControl.ANIME.eHIDE);

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            systemUI.ChangeState(UIControl.ANIME.eFADEIN);
            gameClearUI.ChangeState(UIControl.ANIME.eFADEOUT);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            systemUI.ChangeState(UIControl.ANIME.eFADEOUT);
            gameClearUI.ChangeState(UIControl.ANIME.eFADEIN);
        }*/

        systemUI.Update();
        gameClearUI.Update();

        if (isGameClear && systemUI.state == UIControl.ANIME.eHIDE && gameClearUI.state == UIControl.ANIME.eHIDE)
        {
            gameClearUI.ChangeState(UIControl.ANIME.eFADEIN);
        }

        if (isGameClear && systemUI.state == UIControl.ANIME.eHIDE && gameClearUI.state == UIControl.ANIME.eSHOW)
        {
            isGameClearComplete = true;
        }

        if (isGameClearComplete && Input.GetMouseButtonDown(0))
        {
            EditorApplication.isPlaying = false;
        }
    }

    public void GameClear()
    {
        systemUI.ChangeState(UIControl.ANIME.eFADEOUT);
        isGameClear = true;
    }
}

public class UIControl
{
    RectTransform rectTrans;
    Vector2 defaultSize;
    float timer;
    float maxTime = 1.0f;
    float currentX;

    public enum ANIME
    {
        eFADEIN,
        eFADEOUT,
        eSHOW,
        eHIDE,
    }

    public ANIME state;

    public void Initialize(RectTransform input, float defaultX)
    {
        rectTrans = input;
        defaultSize = new Vector2(defaultX, rectTrans.sizeDelta.y);
        timer = 0.0f;
        state = ANIME.eHIDE;
    }

    public void Update()
    {
        float newX;
        switch (state)
        {
            case ANIME.eSHOW:
                rectTrans.sizeDelta = defaultSize;
                currentX = defaultSize.x;
                break;
            case ANIME.eHIDE:
                rectTrans.sizeDelta = new Vector2(0, defaultSize.y);
                currentX = 0;
                break;
            case ANIME.eFADEIN:
                currentX = Mathf.Lerp(currentX, defaultSize.x, 0.1f);
                rectTrans.sizeDelta = new Vector2(currentX, defaultSize.y);
                timer -= Time.deltaTime;
                if (timer < 0.0f)
                {
                    timer = 0.0f;
                    state = ANIME.eSHOW;
                }
                break;
            case ANIME.eFADEOUT:

                currentX = Mathf.Lerp(currentX, 0.0f, 0.1f);
                rectTrans.sizeDelta = new Vector2(currentX, defaultSize.y);
                timer -= Time.deltaTime;
                if (timer < 0.0f)
                {
                    timer = 0.0f;
                    state = ANIME.eHIDE;
                }
                break;
        }
    }

    public void ChangeState(ANIME newState)
    {
        state = newState;
        timer = maxTime;
    }
}