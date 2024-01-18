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

    public void setDoorNum(int doorNum) 
    { 
        this.doorNum = doorNum;
    }

    public int getDoorNum()
    {
        return doorNum;
    }

    public void setOriginScene(string originScene)
    {
        this.originScene = originScene;
    }

    public string GetOriginScene()
    {
        return originScene;
    }
}
