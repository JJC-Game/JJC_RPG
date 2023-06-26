using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int gatherBearNum = 0;
    Text gatherBearNumText;
    // Start is called before the first frame update
    void Start()
    {
        gatherBearNumText = GameObject.Find("GatherBearNum").GetComponent<Text>();
        gatherBearNumText.text = "0";
        gatherBearNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GatherBear()
    {
        gatherBearNum++;
        gatherBearNumText.text = gatherBearNum.ToString();
    }
}
