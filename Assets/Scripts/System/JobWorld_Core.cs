using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JobWorld_Core : MonoBehaviour
{
    public int inputX = 0, inputZ = 0;
    protected GameManager gameManager = null;
    public List<GameObject> bearList;

    UnityAction<Collision> _hitFunc;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _hitFunc = null;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DropItem")
        {
            OnJobWorldCollisionEnter(collision);

            if (_hitFunc != null)
            {
                _hitFunc(collision);
            }
        }
    }

    virtual protected void OnJobWorldCollisionEnter(Collision collision) { }

    public void SetHitFunc(UnityAction<Collision> hitFunc)
    {
        _hitFunc = hitFunc;
    }
}
