using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SegmentBonus : MonoBehaviour
{
    [SerializeField] private TMP_Text _textViver;
    [SerializeField] private Vector2Int _textCount;
    private int _bonusSize;
    private void Awake()
    {
        _bonusSize = Random.Range(_textCount.x, _textCount.y);
        _textViver.text = _bonusSize.ToString();
    }

    public int Collect()
    {
        Destroy(gameObject);
        return _bonusSize;
    }
}
