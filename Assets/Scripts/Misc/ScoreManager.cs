﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;

    #region Private Variables
    private int m_CurrScore;
    #endregion

    #region Initialization
    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        } else if (singleton != this)
        {
            Destroy(gameObject);
        }
        m_CurrScore = 0;
    }
    #endregion

    #region Score Methods
    public void IncreaseScore(int amount)
    {
        m_CurrScore += amount;
    }

    private void UpdateHighScore()
    {
        if(!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", m_CurrScore);
        }
    }
    #endregion

    #region Destruction
    private void OnDisable()
    {
        UpdateHighScore();
    }
    #endregion
}
