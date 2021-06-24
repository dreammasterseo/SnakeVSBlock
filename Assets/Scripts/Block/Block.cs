using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroiPriceRange;
    [SerializeField] private Color[] _colors;
    public event Action<int> FillingUpdate;
    public event Action DestroiAudio;
    private SpriteRenderer _spriteRenderer;
    private int _destroiPrice;
    private int _filling;
    
    public int LeftToFill => _destroiPrice - _filling;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor();
        _destroiPrice = UnityEngine.Random.Range(_destroiPriceRange.x, _destroiPriceRange.y);
        FillingUpdate?.Invoke(LeftToFill);
    }

    public void Fill()
    {
        _filling++;
        FillingUpdate?.Invoke(LeftToFill);
        if (_filling == _destroiPrice)
        {
            Destroy(gameObject);
            DestroiAudio?.Invoke();
        }
    }

    private void SetColor()
    {
        var color = UnityEngine.Random.Range(0, _colors.Length);
        _spriteRenderer.color = _colors[color];
    }
}
