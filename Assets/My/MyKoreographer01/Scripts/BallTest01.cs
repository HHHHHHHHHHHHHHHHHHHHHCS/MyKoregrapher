using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class BallTest01 : MonoBehaviour
{
    private Rigidbody rigi;
    public string eventID;
    public float jumpSpeed;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
        Koreographer.Instance.RegisterForEvents(eventID, BallJump);
    }

    private void BallJump(KoreographyEvent kevent)
    {
        Vector3 vel = rigi.velocity;
        vel.y = jumpSpeed;
        rigi.velocity = vel;
    }
}
