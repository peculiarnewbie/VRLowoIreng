using UnityEngine;
using System.Collections;

public class DirectionSignal : TimedUpdate
{

    [SerializeField]
    private GameObject[] objs;

    protected override void timedUpdate()
    {
        foreach(var obj in objs)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
    }
}
