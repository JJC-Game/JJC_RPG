using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SlimeMover : EnemyBaseMover
{
    float slimeJumpCooldown = 2.0f;
    float jumpPower = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        SlimeJump();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SlimeJump()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * jumpPower, ForceMode.Impulse);
        Invoke("SlimeJump", slimeJumpCooldown);
    }
}
