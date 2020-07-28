using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button[] buttons;
    bool selected = false;

    public void Selected()
    {
        print("Selected");
        selected = true;
    }

    public void Deselected()
    {
        selected = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            if(selected)
                Select();
        }
        else if (Input.GetAxis("Vertical") <= -0.5f)
        {
            Exit();
        }
    }

    void Select()
    {
        ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
    }

    void Exit()
    {
        Application.Quit();
    }
}
