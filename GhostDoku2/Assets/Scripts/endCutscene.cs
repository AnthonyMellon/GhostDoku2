using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCutscene : MonoBehaviour
{
    public Camera cam;
    public int finalCameraSize;
    public Vector3 worldCenter;
    public BoolSO gamePaused;
    public IntGameEvent mainMenu;

    public List<GameObject> graves;

    public void Run()
    {
        gamePaused.value = true;
        StartCoroutine(CamPan());
    }

    public IEnumerator CamPan()
    {
        while(Vector2.Distance(cam.transform.position, worldCenter) > 1)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, worldCenter, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(CamZoomOut());
    }

    public IEnumerator CamZoomOut()
    {

        while (cam.orthographicSize < finalCameraSize)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, finalCameraSize + 1, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(FadeGhosts());
    }

    public IEnumerator FadeGhosts()
    {
        foreach(GameObject grave in graves)
        {
            grave.transform.Find("Ghost(Clone)").GetComponent<GhostlyTrailManager>().enabled = false;
            grave.transform.Find("Ghost(Clone)").GetComponent<Ghost>().disableGhostInteraction.Raise(0);
            grave.transform.Find("Ghost(Clone)").GetComponent<Ghost>().interactableAlert.SetActive(false);
        }

        float alpha = 0.6f;
        while (alpha > 0)
        {
            alpha = Mathf.Lerp(alpha, 0 - .1f, Time.deltaTime);
            Debug.Log(alpha);
            foreach (GameObject grave in graves)
            {
                Transform ghost = grave.transform.Find("Ghost(Clone)");
                Color col = ghost.GetComponent<SpriteRenderer>().color;
                ghost.GetComponent<SpriteRenderer>().color = new Color(col.r, col.g, col.b, alpha);
                ghost.transform.localPosition = new Vector3(ghost.transform.localPosition.x, ghost.transform.localPosition.y + 0.02f, ghost.transform.localPosition.z);
            }           
            yield return new WaitForEndOfFrame();
        }

        mainMenu.Raise(0);
    }
   
}
