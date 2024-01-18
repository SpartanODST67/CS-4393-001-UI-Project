using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum MovementState { Talking, Wandering, Fighting};
    private MovementState state;
    private static StateManager instance;

    void Start()
    {
        singleton();
        state = MovementState.Wandering;
    }

    private void singleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public MovementState getState()
    {
        return state;
    }

    public void setState(MovementState state)
    {
        this.state = state;
    }

    public void setWandering()
    {
        state = MovementState.Wandering;
    }

    public void setFighting()
    {
        state = MovementState.Fighting;
    }

    public void setTalking()
    {
        state = MovementState.Talking;
    }
}
