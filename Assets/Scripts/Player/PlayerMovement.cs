using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class PlayerMovement
{
    private Camera _mainCamera;
    private Player _player;
    private Transform _playerTransform;
    private Vector2 _movementPosition;
    private float _moveSpeed;
   
    public PlayerMovement(Player player,float moveSpeed,Camera camera)
    {
        _player = player;
        _moveSpeed = moveSpeed;
        _mainCamera = camera;
        Initialize();
    }
    private void Initialize()
    {
        _player.OnUpdate += FindMovePosition;
        //_player.OnUpdate += RotateToMoveDirection;

        _player.OnFixedUpdate += HandleMovement;

        _playerTransform = _player.transform;

    }
    private void FindMovePosition()
    {
        
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                _movementPosition = _mainCamera.ScreenToWorldPoint(Input.touches[0].position);
            }
        }
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _movementPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        
    }
    private void HandleMovement()
    {
        MoveToPoint(_movementPosition);
    }
    private void MoveToPoint(Vector2 point)
    {
        _playerTransform.position = Vector2.MoveTowards(_playerTransform.position,_movementPosition,Time.deltaTime*_moveSpeed);   
    }
    //private void RotateToMoveDirection()
    //{
    //    Vector2 movementDirection = GetFaceDirection(_movementPosition);
    //    _playerTransform.up = new Vector3(movementDirection.x, movementDirection.y, _playerTransform.position.z);
    //}
    //private Vector2 GetFaceDirection(Vector2 point)
    //{
    //    Vector2 positionXY = new Vector2(_playerTransform.position.x, _playerTransform.position.y);
    //    return  point - positionXY;
    //}
    private void FixedUpdate()
    {
        HandleMovement();
    }

}
