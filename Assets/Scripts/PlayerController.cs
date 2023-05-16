using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 20.0f;

    float attackAnimationSecond = 0.5f;
    float weaponSwingAngleSpeedPerSecond = 180.0f;

    float attackAnimeTimer;
    // Start is called before the first frame update
    void Start()
    {
        attackAnimeTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        UpdateJump();
        UpdateAttack();

    }

    void UpdateMove()
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

    void UpdateJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpPower, ForceMode.Impulse);
        }
    }

    void UpdateAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            float animationRate = attackAnimeTimer / attackAnimationSecond;
            float degreeAngle = animationRate * weaponSwingAngleSpeedPerSecond;
        }

        attackAnimeTimer += Time.deltaTime;
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
}
