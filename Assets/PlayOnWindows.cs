﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnWindows : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        #if UNITY_STANDALONE_WIN

        #endif
    }
}
