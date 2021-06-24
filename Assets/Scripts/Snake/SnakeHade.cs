using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHade : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Snake _snake;
    public event Action CollisionBlock;
    public event Action<int> BonusTrigger;
    private Block _block;
    private void Start()
    {
        _snake = GetComponentInParent<Snake>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 newPosition)
    {
        _rigidbody2D.MovePosition(newPosition);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            if(_snake.Tail.Count > 0)
            {
                block.Fill();
                CollisionBlock?.Invoke();
            }
            else
            {
                Debug.Log("GameOwer");
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out SegmentBonus segmentBonus))
        {
            BonusTrigger?.Invoke(segmentBonus.Collect());
        }
    }
}
