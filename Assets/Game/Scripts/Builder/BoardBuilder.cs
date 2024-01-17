using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBuilder : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private BoardBlock _boardBlock;
    [SerializeField] private BoardBuilder _builder;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _cameraOffset;
    
    private void Start()
    {
        BuildBoard();
    }

    private void BuildBoard()
    {  
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                BoardBlock spawnedBoardBlock = Instantiate(_boardBlock);
                Transform _transform = spawnedBoardBlock.transform;
                _transform.position = new Vector3(i * BoardBlock.SIZE, j * BoardBlock.SIZE);
                _transform.SetParent(_builder.transform, true);
            }
        }

        SetCamera();
    }

    private void SetCamera()
    {
        _camera.transform.position = new Vector3(((float)_width / 2) * BoardBlock.SIZE - _cameraOffset, ((float)_height / 2) * BoardBlock.SIZE - _cameraOffset, -10);
    }
}
