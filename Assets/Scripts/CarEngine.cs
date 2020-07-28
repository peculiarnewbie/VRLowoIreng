using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    WheelCollider fl, fr, rl, rr;

    float gas;
    float steer;
    [SerializeField] Transform steerObj = null;
    Vector3 steerRotation = new Vector3();
    [SerializeField] float maxSteerTurn = 90f;

    [SerializeField] float turnRate = 0;
    [SerializeField] float engineAccel = 450;
    [SerializeField] float brakeRate = 0;
    [SerializeField] float maxRPM = 500f;
    [SerializeField] float minRPM = -200f;
    [SerializeField] float kmph = 0f;

    float engineTorque = 0;

    int gearIndex = 1;

    public float Kmph { get => kmph; set => kmph = value; }

    // Start is called before the first frame update
    void Start()
    {
        engineTorque = engineAccel;

        fl = transform.GetChild(1).GetComponent<WheelCollider>();
        fr = transform.GetChild(2).GetComponent<WheelCollider>();
        rl = transform.GetChild(3).GetComponent<WheelCollider>();
        rr = transform.GetChild(4).GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        gas = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");
        Kmph = Mathf.Abs(fl.rpm / 3);

        steerRotation.Set(0, -steer * maxSteerTurn, 0);
        steerObj.localRotation = Quaternion.Euler(steerRotation);

        if (Input.GetButtonDown("RB") || Input.GetKeyDown(KeyCode.Q))
        {
            Shift("Up");
        }
        else if (Input.GetButtonDown("LB") || Input.GetKeyDown(KeyCode.E))
        {
            Shift("Down");
        }

        if(fl.rpm > maxRPM || fl.rpm < minRPM)
        {
            engineTorque = 10f;
        }
        else
        {
            engineTorque = engineAccel;
        }


        Turn();

        if(gas > 0)
        {
            Gas();
        }
        else if(gas <= 0)
        {
            Brake();
        }

        RotateWheel(fl);
        RotateWheel(fr);
        RotateWheel(rl);
        RotateWheel(rr);
    }

    public void Pause()
    {

        fl.motorTorque = 0;
        fr.motorTorque = 0;
        rr.motorTorque = 0;
        rl.motorTorque = 0;

        Brake();
    }

    void Gas()
    {
        fl.brakeTorque = 0;
        fr.brakeTorque = 0;
        rl.brakeTorque = 0;
        rr.brakeTorque = 0;

        fl.motorTorque = engineTorque * gas * gearIndex;
        fr.motorTorque = engineTorque * gas * gearIndex;
        rr.motorTorque = engineTorque * gas * gearIndex;
        rl.motorTorque = engineTorque * gas * gearIndex;
    }

    void Brake()
    {
        fl.brakeTorque = brakeRate + (brakeRate * (gas * -1));
        fr.brakeTorque = brakeRate + (brakeRate * (gas * -1));
        rl.brakeTorque = brakeRate + (brakeRate * (gas * -1));
        rr.brakeTorque = brakeRate + (brakeRate * (gas * -1));
    }

    void Turn()
    {
        fl.steerAngle = turnRate * steer;
        fr.steerAngle = turnRate * steer;
    }

    void RotateWheel(WheelCollider wheel)
    {
        Quaternion q;
        Vector3 p;
        wheel.GetWorldPose(out p, out q);

        // assume that the only child of the wheelcollider is the wheel shape
        Transform shapeTransform = wheel.transform.GetChild(0);
        shapeTransform.position = p;
        shapeTransform.rotation = q;
    }

    void Shift(string state)
    {
        if(state == "Up")
        {
            gearIndex = 1;
        }
        else if(state == "Down")
        {
            gearIndex = -1;
        }
    }
}
