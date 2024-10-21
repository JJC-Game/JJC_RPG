using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 20.0f;
    JobWorld jobworld;

    void Start()
    {
        jobworld = GameObject.Find("JobWorld").GetComponent<JobWorld>();
    }

    void Update()
    {
        UpdateJump();
    }

    void FixedUpdate()
    {
        UpdateMove();
    }

    void UpdateMove()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().IsGameClear())
        {
            return;
        }

        RefreshPlayerPos(jobworld.inputX, jobworld.inputZ);

        jobworld.inputX = 0;
        jobworld.inputZ = 0;
    }

    void UpdateJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpPower, ForceMode.Impulse);
        }
    }

    void RefreshPlayerPos(float inputX, float inputZ)
    {
        float PlayerSpeed = 5;          // 1秒間にPlayerが動く距離.
        float PlayerRotYSpeed = 90;     // 1秒間にPlayerが振り向く角度.

        Vector3 oldPosition = transform.position;
        Vector3 moveVector = transform.forward * Time.deltaTime * inputZ * PlayerSpeed;
        Vector3 newPosition = oldPosition + moveVector;
        transform.position = newPosition;

        Vector3 oldRot = transform.rotation.eulerAngles;
        Vector3 newRot = new Vector3(oldRot.x, oldRot.y + Time.deltaTime * inputX * PlayerRotYSpeed, oldRot.z);
        transform.rotation = Quaternion.Euler(newRot);
    }

    void OnCollisionEnter(Collision collision)
    {
        jobworld.OnCollisionEnter(collision);
    }
}
