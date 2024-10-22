using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobWorld : JobWorld_Core
{
    // Update is called once per frame
    void Update()
    {
        /*
         * ↓↓↓↓↓↓↓↓↓↓↓↓↓
         * 移動処理を下の行に書いてね
         * ↓↓↓↓↓↓↓↓↓↓↓↓↓
         */

        if (Input.GetKey(KeyCode.W)) inputZ = 1;

        if (Input.GetKey(KeyCode.S)) inputZ = -1;
        
        if (Input.GetKey(KeyCode.D)) inputX = 1;
        
        if (Input.GetKey(KeyCode.A)) inputX = -1;
    }

    override protected void OnJobWorldCollisionEnter(Collision collision)
    {
        /*
         * ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
         * クマとぶつかったときの処理を下の行に書いてね
         * ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
         */

        Destroy(collision.gameObject);
    }
}
