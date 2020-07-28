using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelect : MonoBehaviour
{
    int screenIndex = 0;
    GameObject[] cars = new GameObject[3];
    MenuButtonManager menuButtonManager;
    bool hasMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        menuButtonManager = GetComponent<MenuButtonManager>();
        for (int i = 0; i < 3; i++)
        {
            cars[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") >= 0.75f && !hasMoved)
        {
            Right();
            hasMoved = true;
        }
        else if(Input.GetAxis("Horizontal") <= -0.75f && !hasMoved)
        {
            Left();
            hasMoved = true;
        }

        if (hasMoved)
        {
            if(Input.GetAxis("Horizontal") < 0.3f && Input.GetAxis("Horizontal") > -0.3f)
            {
                hasMoved = false;
            }
        }

        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            Select();
        }
        else if (Input.GetAxis("Vertical") <= -0.5f)
        {
            Back();
        }
    }

    void Left()
    {
        if(screenIndex > 0)
        {
            cars[screenIndex].SetActive(false);
            screenIndex -= 1;
            cars[screenIndex].SetActive(true);
        }
    }

    void Right()
    {
        if(screenIndex < 2)
        {
            cars[screenIndex].SetActive(false);
            screenIndex += 1;
            cars[screenIndex].SetActive(true);
        }
    }

    void Select()
    {
        if(screenIndex == 0)
        {
            menuButtonManager.NextScene();
        }
    }

    void Back()
    {
        menuButtonManager.PreviousScene();
    }
}
