using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    private Vector2 origin;

    [Header("Speed")]
    [SerializeField] private float xBobSpeed;
    [SerializeField] private float yBobSpeed;
    private float i_xBobSpeed;
    private float i_yBobSpeed;

    [Header("Intensity")]
    [SerializeField] private float xBobSize;
    [SerializeField] private float yBobSize;
    private float i_xBobSize;
    private float i_yBobSize;

    [Header("Variance")]
    [SerializeField] private float xVariance;
    [SerializeField] private float yVariance;

    [Header("Update")]
    [SerializeField] private bool update;


    private void Start()
    {
        origin = transform.localPosition;
        UpdateIs();
    }

    void Update()
    {
        Vector2 positionChange = new Vector2(Mathf.Sin(Time.time * i_xBobSpeed) * i_xBobSize, Mathf.Cos(Time.time * i_yBobSpeed) * i_yBobSize);
        Vector2 newPosition = origin + positionChange;
        transform.localPosition = newPosition;


        if(update)
        {
            update = false;
            UpdateIs();
        }
    }

    private void UpdateIs()
    {
        float curVar;

        curVar = xBobSpeed * xVariance;
        i_xBobSpeed = xBobSpeed + Random.Range(curVar * -1, curVar);

        curVar = xBobSize * xVariance;
        i_xBobSize = xBobSize + Random.Range(curVar * -1, curVar);

        curVar = yBobSpeed * yVariance;
        i_yBobSpeed = yBobSpeed + Random.Range(curVar * -1, curVar);

        curVar = yBobSize * yVariance;
        i_yBobSize = yBobSize + Random.Range(curVar * -1, curVar);
    }
}
