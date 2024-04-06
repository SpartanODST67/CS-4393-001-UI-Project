using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSaver : MonoBehaviour
{
    private int doorNum;
    private string originScene;

    void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetDoorNum(int doorNum) 
    { 
        this.doorNum = doorNum;
    }

    public int GetDoorNum()
    {
        return doorNum;
    }

    public void SetOriginScene(string originScene)
    {
        this.originScene = originScene;
    }

    public string GetOriginScene()
    {
        return originScene;
    }
}
