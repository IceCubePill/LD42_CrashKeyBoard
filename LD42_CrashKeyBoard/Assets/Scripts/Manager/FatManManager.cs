using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatManManager : SingleType<AnimateManager>
{
    public enum FatManState
    {
        PlayingGame,
        Eating,
        LookAround,
        /// <summary>
        /// 结束游戏的状态
        /// </summary>
        Angry,
        Blind,
    }
    public FatManState currentState;
    [HideInInspector]
    public const int maxVigilance = 100;
    [HideInInspector]
    public int currentVigilance = 0;
    public float PlayingGameTime = 1f;
    public float EatingTime = 5f;
    public float LookAroundTIme = 3f;
    public float BlindTime = 10f;

    private float m_lastTime;

    private float m_hasEatingTime = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case FatManState.PlayingGame:
                if (Time.time - m_lastTime > PlayingGameTime)
                {
                    ChangeState(FatManState.PlayingGame);
                }
                break;
            case FatManState.Eating:
                if (Time.time - m_lastTime > EatingTime - m_hasEatingTime)
                {
                    ChangeState(FatManState.PlayingGame);
                    m_hasEatingTime = 0;
                }
                break;
            case FatManState.LookAround:
                if (Time.time - m_lastTime > LookAroundTIme)
                {
                    ChangeState(m_hasEatingTime != 0 ? FatManState.Eating : FatManState.PlayingGame);
                }
                break;
            case FatManState.Angry:
                break;
            case FatManState.Blind:
                if (Time.time - m_lastTime > BlindTime)
                {
                    ChangeState(FatManState.Blind);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ChangeState(FatManState fms, params object[] arcs)
    {
        switch (fms)
        {
            case FatManState.PlayingGame:
                m_lastTime = Time.time;

                //if (AnimateManager.instant.HasFood() == null)
                //{
                //    currentState = FatManState.PlayingGame;

              
                //}
                //做判断
                break;
            case FatManState.Eating:
                m_lastTime = Time.time;
                currentState = FatManState.Eating;
                break;
            case FatManState.LookAround:

                if (currentState == FatManState.Eating)
                    m_hasEatingTime = Time.time - m_lastTime;
                m_lastTime = Time.time;
                currentState = FatManState.LookAround;

                break;
            case FatManState.Angry:
                break;
            case FatManState.Blind:
                m_lastTime = Time.time;
                currentState = FatManState.Blind;
                break;
            default:
                throw new ArgumentOutOfRangeException("fms", fms, null);
        }
    }

}
