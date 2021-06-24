using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Snake))]
public class SnakeSizeViver : MonoBehaviour
{
    [SerializeField] private TMP_Text _textViver;

    private Snake _snake;

    private void Awake()
    {
        _snake = GetComponent<Snake>();
    }

    private void OnEnable()
    {
        _snake.SizeUpdate += OnSnakeCount;
    }

    private void OnDisable()
    {
        _snake.SizeUpdate -= OnSnakeCount;
    }

    private void OnSnakeCount(int count)     
    {
        _textViver.text = count.ToString();
    }
}
