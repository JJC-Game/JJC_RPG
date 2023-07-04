using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Text bearNumText;
    public bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        bearNumText = GameObject.Find("BearNum").GetComponent<Text>();
        bearNumText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        bearNumText.text = GameObject.Find("DropManager").transform.childCount.ToString();
        if (!isGameClear && GameObject.Find("DropManager").transform.childCount == 0)
        {
            GameClear();
        }
    }

    public void GameClear()
    {
        GameObject.Find("GameManager").GetComponent<UIManager>().GameClear();
        isGameClear = true;
    }

    public bool IsGameClear()
    {
        return isGameClear;
    }
}
