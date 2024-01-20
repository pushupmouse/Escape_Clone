using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock: MonoBehaviour
{
    [SerializeField] private SpriteRenderer _blockRenderer;
    [SerializeField] private BoxCollider2D _blockCollider;

    private int _size;
    private Vector2 _start;
    private bool _isHorizontal;
    private Vector2 _position;

    public bool IsHorizontal => _isHorizontal;
    public int Size => _size;
    public Vector2 Start => _start;
    public Vector2 Position => _position;

    public void OnInit(Piece piece)
    {
        _isHorizontal = piece.isHorizontal;
        _size = piece.Size;
        _start = piece.Start;
        _position = new Vector2(_start.x, _start.y);

        if(_isHorizontal) 
        {
            _blockRenderer.transform.localScale = new Vector2(_size, 1);
            _blockCollider.size = new Vector2(_size, 1);
        }
        else
        {
            _blockRenderer.transform.localScale = new Vector2(1, _size);
            _blockCollider.size = new Vector2(1, _size);
        }

    }

    public void OffsetPosition(float size)
    {
        _position += (_isHorizontal ? Vector2.right : Vector2.up) * size * 0.5f;
        transform.position = _position - (_isHorizontal ? new Vector2(0.5f, 0) : new Vector2 (0, 0.5f));
    }
}
