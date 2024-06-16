using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private UnityEvent onTick;
    private float currentTime;

    private void Start()
    {
        currentTime = maxTime;
    }

    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime <= 0f)
        {
            onTick.Invoke();
            currentTime = maxTime;
        }
    }
}
