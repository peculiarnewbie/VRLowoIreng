using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HmdCalibrator : MonoBehaviour
{
    Vector3 offsetPos = new Vector3();
    Quaternion offsetRot = new Quaternion();
    Transform child;

    // Start is called before the first frame update
    void Start()
    {
        Calibrate();
    }

    public void Calibrate()
    {
        child = transform.GetChild(0).GetChild(1);

        offsetRot.Set(0, child.rotation.y, 0, 1);
        transform.rotation = offsetRot;

        offsetPos = child.position - transform.position;
        transform.position -= offsetPos;
    }
}
