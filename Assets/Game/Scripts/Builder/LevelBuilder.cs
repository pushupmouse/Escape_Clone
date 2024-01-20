using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder Instance;
    
    [SerializeField] private Level _level;
    [SerializeField] private BoardBlock _boardBlock;
    [SerializeField] private WoodBlock _woodBlock;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _cameraOffset;
    [SerializeField] private float _cameraZoom;

    private List<WoodBlock> _woodBlocks;

    private void Awake()
    {
        Instance = this;
    }

    private void SetBoardBlocks()
    {
        for (int i = 0; i < _level.Rows; i++)
        {
            for (int j = 0; j < _level.Columns; j++)
            {
                BoardBlock spawnedBoardBlock = Instantiate(_boardBlock);
                Transform _transform = spawnedBoardBlock.transform;
                _transform.position = new Vector2(i, j);
            }
        }
    }

    private void SetWoodBlocks()
    {
        _woodBlocks = new List<WoodBlock>();

        for (int i = 0; i < _level.Pieces.Count; i++)
        {
            WoodBlock woodBlock = Instantiate(_woodBlock);
            Vector2 spawnPosition = new Vector2(_level.Pieces[i].Start.x, _level.Pieces[i].Start.y);
            woodBlock.transform.position = spawnPosition;
            woodBlock.OnInit(_level.Pieces[i]);
            woodBlock.OffsetPosition(_level.Pieces[i].Size);
            _woodBlocks.Add(woodBlock);
        }
    }

    private void SetCamera()
    {
        _camera.transform.position = new Vector3(((float)_level.Rows / 2) - _cameraOffset,
                                                ((float)_level.Columns / 2) - _cameraOffset, -10);
        _camera.orthographicSize = Mathf.Max(_level.Columns, _level.Rows) * _cameraZoom;
    }

    public void BuildLevel()
    {
        SetBoardBlocks();

        SetWoodBlocks();

        SetCamera();
    }
}
