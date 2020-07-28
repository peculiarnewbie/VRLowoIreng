using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    CarEngine carMove;

    [SerializeField] GameObject pauseObj = null;
    Button firstSelect;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        firstSelect = pauseObj.transform.GetChild(1).GetComponent<Button>();
        carMove = GetComponent<CarEngine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //pause
            if (isPaused)
            {
                Unpause();
                isPaused = false;
            }
            else
            {
                Pause();
                isPaused = true;
            }
        }
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    void Pause()
    {
        pauseObj.SetActive(true);
        firstSelect.Select();
        carMove.Pause();
        carMove.enabled = false;
    }

    public void Unpause()
    {
        pauseObj.SetActive(false);
        carMove.enabled = true;
    }
}
