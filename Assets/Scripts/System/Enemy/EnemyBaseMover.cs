using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseMover : MonoBehaviour
{

    GameObject moveTargetObj;
    Vector3 moveTargetPos;

    public enum E_STATE
    {
        IDLE,
        MOVE_TO_OBJECT,
        MOVE_TO_POSITION
    }

    public E_STATE state;

    private void Awake()
    {
        state = E_STATE.IDLE;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        switch (state)
        {
            case E_STATE.IDLE:
                break;
            case E_STATE.MOVE_TO_OBJECT:
                break;
            case E_STATE.MOVE_TO_POSITION:
                break;
        }
    }
}
