using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPrompt : MonoBehaviour
{
    public GameObject sudoku;
    public BoolSO gamePaused;

    private void OnEnable()
    {
        gamePaused.value = true;
    }

    public void LaunchSudoku()
    {
        //Launch a sudoku
        GameObject mySudoku = Instantiate(sudoku, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), GameObject.Find("Canvas_UIoverlay").transform);
        mySudoku.transform.localPosition = new Vector3(0, 0, 0);
        Close();

    }

    public void ReturnToGame()
    {
        gamePaused.value = false;
        Close();
    }

    private void Close()
    {        
        Destroy(gameObject);
    }
}
