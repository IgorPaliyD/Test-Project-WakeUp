using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Fruit : MonoBehaviour
{
    //��������, ����� �������� ��� � ������ ���� � ��������� �� ����, � �� �� ����
    public Action OnCollected;

    private void Awake()
    {
        OnCollected += () => Destroy(this.gameObject);    
    }
    
}
