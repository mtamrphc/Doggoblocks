﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    //cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        {
            breakableBlocks++;
        }
    }

    public void CountBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
