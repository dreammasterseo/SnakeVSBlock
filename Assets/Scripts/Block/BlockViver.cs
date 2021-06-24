using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Block))]
public class BlockViver : MonoBehaviour
{
    [SerializeField] private TMP_Text _textViver;
    private Block _block;

    private void Awake()
    {
        _block = GetComponent<Block>();
    }
    private void OnEnable()
    {
        _block.FillingUpdate += OnBlockCount;
    }

    private void OnDisable()
    {
        _block.FillingUpdate -= OnBlockCount;
    }

    private void OnBlockCount( int count)
    {
        _textViver.text = count.ToString();
    }
}
