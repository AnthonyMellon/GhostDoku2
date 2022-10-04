using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GridLock : MonoBehaviour
{
    [SerializeField] private GridSettingsSO gridSettings;
   

    // Update is called once per frame
    void Update()
    {
        if(transform.hasChanged) UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (!gridSettings) return;

        Vector2 newPos = transform.position;

        newPos.x = Mathf.Round(newPos.x / gridSettings.stepSize.x) * gridSettings.stepSize.x;
        newPos.y = Mathf.Round(newPos.y / gridSettings.stepSize.y) * gridSettings.stepSize.y;

        newPos.x += gridSettings.offset.x;
        newPos.y += gridSettings.offset.y;

        transform.position = newPos;
    }
}
