﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
}
