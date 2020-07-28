using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{

    [SerializeField] float timeShow = 5f;
    float timeCD;
    bool showingInfo = false;
    [SerializeField] List<GameObject> pointsUI = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (showingInfo)
        {
            if(timeCD <= 0f)
            {
                CloseInfo();
            }
            timeCD -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Poin"))
        {
            Debug.Log("Lol");
            OpenInfo(other.gameObject.name[0] - '0');
        }
    }

    void CloseInfo()
    {
        foreach(GameObject g in pointsUI)
        {
            g.SetActive(false);
        }
        showingInfo = true;
    }

    void OpenInfo(int index)
    {
        pointsUI[index].SetActive(true);
        timeCD = timeShow;
        showingInfo = true;
    }
}
