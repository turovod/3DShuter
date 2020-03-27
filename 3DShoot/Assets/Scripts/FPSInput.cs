﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))] // Проверка наличия компонента CharacterController
[AddComponentMenu("Control Script/FPS Input")]  // Добавление в меню скрипта FPS Input

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, gravity, deltaZ);

        movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
        //movement.y = gravity;
        //movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _charController.Move(movement);
    }
}