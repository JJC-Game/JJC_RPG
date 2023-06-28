using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobWorld : MonoBehaviour
{
    public int inputX = 0, inputZ = 0;
    GameManager gameManager = null;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * 
         * 移動処理を下の行に書いてみてね
         * 
         */

        if (Input.GetKey(KeyCode.W)) inputZ = 1;
        if (Input.GetKey(KeyCode.S)) inputZ = -1;
        if (Input.GetKey(KeyCode.A)) inputX = -1;
        if (Input.GetKey(KeyCode.D)) inputX = 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DropItem")
        {
            //gameManager.GatherBear();
            //Destroy(collision.gameObject);
            Destroy(collision.gameObject);
        }
        
    }
}
