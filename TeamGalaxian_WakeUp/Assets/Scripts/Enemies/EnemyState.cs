using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum State
    {
        Idle,
        Patrol,
        Chase
    }
    public State state = State.Idle;
}
