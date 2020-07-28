using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    float gas = 0f;
    float steer = 0f;

    Animator animator = null;

    Transform steeringWheel = null;
    [SerializeField] float maxSteerTurn = 90f;
    Vector3 steerRotation = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        //GetComponentInParent<PlayerController>().AssignCarMove(this);
        steeringWheel = transform.GetChild(1).GetChild(0).GetComponent<Transform>();
        animator = GetComponent<Animator>();
        animator.speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        gas = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", gas);

        steerRotation.Set(0, -steer * maxSteerTurn, 0);

        steeringWheel.localRotation = Quaternion.Euler(steerRotation);
    }

    public void Pause()
    {
        animator.SetFloat("Speed", 0);
    }
}
