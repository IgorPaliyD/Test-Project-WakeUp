using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;
public class SimpleSceneLoader
{
    private int _sceneInex;
    public Action _loadAction;
    public SimpleSceneLoader(int sceneIndex,UnityEvent loadAction)
    {

        _sceneInex = sceneIndex;
        loadAction.AddListener(LoadScene);
      
        
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneInex);
    } 
}
