using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Game Assets/Friut Basket")]
public class Basket : ScriptableObject
{
    private int _fruitsCollected=0;

    public Action OnFruitCollected;
    public Action<int> OnFruitAdded;

    public delegate void Reset();
    public Reset ResetBasket;
    
    public int Fruits { get => _fruitsCollected;}

    private void OnEnable()
    {
       OnFruitCollected += AddFruit;
       ResetBasket += ClearBasket;
    }
    private void AddFruit()
    {
        _fruitsCollected++;
        OnFruitAdded.Invoke(Fruits);
    }
    private void ClearBasket()
    {
        _fruitsCollected = 0;
    }
}
