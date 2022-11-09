using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GridLock : MonoBehaviour
{
    [SerializeField] private GridSettingsSO gridSettings;
    [SerializeField] private Vector2Int localOffset;

    // Update is called once per frame
    void Update()
    {
        if(transform.hasChanged) UpdatePosition();
        //if (Input.GetKeyDown(KeyCode.U)) UpdatePosition();
    }    

    private void UpdatePosition()
    {
        if (!gridSettings) return;

        Vector2 newPos = transform.position;

        newPos.x = Mathf.Round(newPos.x / gridSettings.stepSize.x) * gridSettings.stepSize.x;
        newPos.y = Mathf.Round(newPos.y / gridSettings.stepSize.y) * gridSettings.stepSize.y;

        newPos.x += gridSettings.offset.x + localOffset.x;
        newPos.y += gridSettings.offset.y + localOffset.y;

        transform.position = newPos;
    }
}
