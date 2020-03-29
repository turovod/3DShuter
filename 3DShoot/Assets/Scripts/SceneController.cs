﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private GameObject _enemy;

    void Start()
    {
        
    }

    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab);

            _enemy.transform.position = new Vector3(0, 1, 0);

            float angle = Random.Range(0, 360);

            _enemy.transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}
