using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _sceneIndex;
    private SimpleSceneLoader _sceneLoader;

    public UnityEvent OnButtonPressed;
    private void Awake()
    {
        _sceneLoader = new SimpleSceneLoader(_sceneIndex, OnButtonPressed);
        _button.onClick.AddListener(OnButtonPressed.Invoke);
    }
}
