using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    // private ConfigurableJoint joint; // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/HingeJoint.html
    private HingeJoint joint;
    // private Quaternion target_rot;
    // private Quaternion start_rot;

    // public float speed = 20f;
    // public float rotation_amt = 52;
    public bool isLeftPaddle = true;

    public int flipperVel;
    public int flipperForce;

    private bool flip = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // joint = GetComponent<ConfigurableJoint>();
        joint = GetComponent<HingeJoint>();

        // start_rot = rb.rotation;
        // rotation_amt = isLeftPaddle ? rotation_amt : -rotation_amt;

        flipperVel = isLeftPaddle ? flipperVel : -flipperVel;

        // target_rot = start_rot * Quaternion.AngleAxis(rotation_amt, Vector3.down);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (flip) {
            // rb.MoveRotation(Quaternion.Slerp(rb.rotation, target_rot, Time.fixedDeltaTime * speed));
            // joint.targetRotation = target_rot;
            joint.motor = RotateFlipper(flipperVel, flipperForce);

        }
        if(!flip) {
            // rb.MoveRotation(Quaternion.Slerp(rb.rotation, start_rot, Time.fixedDeltaTime * speed));
            // joint.targetRotation = start_rot;
            joint.motor = RotateFlipper(-flipperVel, flipperForce);
        }
    }

    public void OnLeftPaddle() {
        if (isLeftPaddle) {
            // Debug.Log("function left pressed");
            flip = !flip; // since this fires on press and release
        }
    }
    public void OnRightPaddle() {
        if (!isLeftPaddle) {
            // Debug.Log("function right pressed");
            flip = !flip;
        }
    }

    JointMotor RotateFlipper(float velocity, float force) {
        JointMotor jm = new JointMotor();
        jm.force = force;
        jm.targetVelocity = velocity;
        return jm;
    }
}
