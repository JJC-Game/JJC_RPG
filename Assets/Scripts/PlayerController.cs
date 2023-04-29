using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = 0;
        float inputZ = 0;
        if (Input.GetKey(KeyCode.W))
        {
            inputZ = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputZ = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputX = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputX = 1;
        }
        RefreshPlayerPos(inputX, inputZ);
    }

    void RefreshPlayerPos(float inputX, float inputZ)
    {
        float PlayerSpeed = 5;          // 1ïbä‘Ç…PlayerÇ™ìÆÇ≠ãóó£.
        float PlayerRotYSpeed = 90;     // 1ïbä‘Ç…PlayerÇ™êUÇËå¸Ç≠äpìx.

        Vector3 oldPosition = transform.position;
        Vector3 moveVector = transform.forward * Time.deltaTime * inputZ * PlayerSpeed;
        Vector3 newPosition = oldPosition + moveVector;
        transform.position = newPosition;

        Vector3 oldRot = transform.rotation.eulerAngles;
        Vector3 newRot = new Vector3(oldRot.x, oldRot.y + Time.deltaTime * inputX * PlayerRotYSpeed, oldRot.z);
        transform.rotation = Quaternion.Euler(newRot);
    }
}
