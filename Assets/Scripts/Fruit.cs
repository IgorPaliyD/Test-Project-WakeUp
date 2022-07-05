using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Fruit : MonoBehaviour
{
    //Заглушка, чтобы приветси все к общему виду и проверять по типу, а не по тэгу
    public Action OnCollected;

    private void Awake()
    {
        OnCollected += () => Destroy(this.gameObject);    
    }
    
}
