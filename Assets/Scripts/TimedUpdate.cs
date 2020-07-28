using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedUpdate : MonoBehaviour
{

    [SerializeField] private float duration;

    private float time;

    private void Update()
    {
        time -= Time.deltaTime;
        if(time < 0){
            time = duration;
            timedUpdate();
        }
    }

    protected abstract void timedUpdate();
}
