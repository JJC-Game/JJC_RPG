using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobWorld_Demo : MonoBehaviour
{
    JobWorld jobWorld;
    void Start()
    {
        jobWorld = GameObject.Find("JobWorld").GetComponent<JobWorld>();
        jobWorld.SetHitFunc(OnHit);
    }
    // Update is called once per frame
    void Update()
    {
        // ↓↓↓移動処理を下の行に書いてね↓↓↓

        if (Input.GetKey(KeyCode.W)) jobWorld.inputZ = 1;

        if (Input.GetKey(KeyCode.S)) jobWorld.inputZ = -1;
        
        if (Input.GetKey(KeyCode.D)) jobWorld.inputX = 1;
        
        if (Input.GetKey(KeyCode.A)) jobWorld.inputX = -1;
    }

    public void OnHit(Collision collision)
    {
        // ぶつかったときの処理を下の行に書いてね

        Destroy(collision.gameObject);
    }
}
