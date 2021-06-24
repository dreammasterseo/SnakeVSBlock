using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(TileGenerator),typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _tileSize;
    [SerializeField] private float _tilePringells;
    [SerializeField] private SnakeHade _head;
    private SnakeInput _snakeInput;
    private List<Segment> _tail;
    public List<Segment> Tail => _tail;
    private TileGenerator _tileGenerate;

    public event Action<int> SizeUpdate;

    private void Start()
    {
        _snakeInput = GetComponent<SnakeInput>();
        _tileGenerate = GetComponent<TileGenerator>();
        _tail = _tileGenerate.Generation(_tileSize);
        SizeUpdate?.Invoke(_tail.Count);
    }

    private void OnEnable()
    {
        _head.CollisionBlock += OnBlockCollided;
        _head.BonusTrigger += OnBonusCollected;
    }

    private void OnDisable()
    {
        _head.CollisionBlock -= OnBlockCollided;
        _head.BonusTrigger -= OnBonusCollected;
    }

    private void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.up * _speed * Time.fixedDeltaTime);
        _head.transform.up = _snakeInput.GetDirectionToClick(_head.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previosPosition = _head.transform.position;
        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previosPosition,_tilePringells * Time.deltaTime);
            previosPosition = tempPosition;
        }
        _head.Move(nextPosition);
    }

    private void OnBlockCollided()
    {
            Segment deliteSegment = _tail[_tail.Count - 1];
            _tail.Remove(deliteSegment);
            Destroy(deliteSegment.gameObject);
            SizeUpdate?.Invoke(_tail.Count);
    }

    private void OnBonusCollected(int bonusSize)
    {
       _tail.AddRange(_tileGenerate.Generation(bonusSize));
        SizeUpdate?.Invoke(_tail.Count);
    }
}
