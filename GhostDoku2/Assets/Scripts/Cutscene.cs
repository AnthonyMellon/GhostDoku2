using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cutscene : MonoBehaviour
{
    public BoolSO paused;
    private Vector3 mPos;
    public Player player;
    public IntGameEvent updateFog;
    public IntGameEvent EnableGhost;

    public void OnCutscene(Vector2 nPos)
    {
        mPos = new Vector3(nPos.x, nPos.y, -10);
        StartCoroutine(RunCutscene());
    }

    private IEnumerator RunCutscene()
    {
        paused.value = true;

        //Move to grave
        while(Vector2.Distance(transform.position, mPos) > 1)
        {
            Vector2.Distance(transform.position, mPos);
            transform.position = Vector3.Lerp(transform.position, mPos, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        //Remove fog
        updateFog.Raise(0);
        yield return new WaitForSeconds(1);

        //Spawn ghost
        EnableGhost.Raise(0);
        yield return new WaitForSeconds(1.5f);

        //Move to player
        Vector3 target = new Vector3(0, 0, -10);

        while (Vector2.Distance(transform.localPosition, target) > 1)
        {
            Vector2.Distance(transform.localPosition, target);
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        paused.value = false;;
    }
}
