﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The player to follow.")]
    private Transform m_PlayerTransform;

    [SerializeField]
    [Tooltip("The offset from the player's origin to camera.")]
    private Vector3 m_Offset;

    [SerializeField]
    [Tooltip("How quickly the player can rotate camera to left and right.")]
    private float m_RoatationSpeed = 10;
    #endregion

    #region Main Updates
    private void LateUpdate()
    {
        Vector3 newPos = m_PlayerTransform.position + m_Offset;

        transform.position = Vector3.Slerp(transform.position, newPos, 1);

        float rotationAmount = m_RoatationSpeed * Input.GetAxis("Mouse X");
        transform.RotateAround(m_PlayerTransform.position, Vector3.up, rotationAmount);

        m_Offset = transform.position - m_PlayerTransform.position;
    }
    #endregion
}
