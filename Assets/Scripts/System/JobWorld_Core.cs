using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobWorld_Core : MonoBehaviour
{
    public int inputX = 0, inputZ = 0;
    protected GameManager gameManager = null;
    public List<GameObject> bearList;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DropItem")
        {
            OnJobWorldCollisionEnter(collision);
        }
    }

    virtual protected void OnJobWorldCollisionEnter(Collision collision) { }
}
