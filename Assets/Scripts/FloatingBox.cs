using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBox : MonoBehaviour
{
    Vector3 rotation = new Vector3();
    Vector3 position = new Vector3();

    Vector3 originalPos = new Vector3();
    [SerializeField] float rotateRate = 1f;
    [SerializeField] float moveRate = 1f;
    [SerializeField] float yPos = 1f;
    [SerializeField] float yRange = 1f;
    float ySin = 0f;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        //position.Set(0, rotateRate, 0);
        yPos += 0.01f;
        ySin = Mathf.Sin(yPos * moveRate)/(yRange*3);
        position.Set(0, ySin, 0);
        transform.Translate(position);
        /*if (transform.position.y >= originalPos.y + 10)
        {
            moveRate *= -1;
        }
        else if(transform.position.y <= originalPos.y - 10)
        {
            moveRate *= -1;
        }*/
    }

    void Rotate()
    {
        rotation.Set(0, rotation.y + rotateRate, 0);
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
