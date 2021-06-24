using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Место спауна")]
    [SerializeField] private Transform _conteiner;
    [Header("Спаун полных блоков")]
    [SerializeField] private int _ripeatCount;
    [Header("Дистанция спауна полных блоков")]
    [SerializeField] private int _distanceBeetwenFullLine;
    [Header("Дистанция спауна рандомных блоков")]
    [SerializeField] private int _distanceBeetweenRandomLine;
    [Header("Префаб блока")]
    [SerializeField] private Block _blockTemplate;
    [Header("Шанц спауна рандомных блоков")]
    [SerializeField] private int _blockSpawnCange;
    [Header("Префаб стены")]
    [SerializeField] private Wall _wallTemplate;
    [Header("Расстояние между стенами")]
    [SerializeField] private int _wallSpawnChang;
    private WallSpawnPoint[] _wallSpawnPoints;
    private BlockSpawnPoint[] _spawnPoint;
    [SerializeField] private SegmentBonus _bonusTemplate;
    private BonusSpawnPoint[] _spawnBonus;
    [SerializeField] private int _bonusSpawnChange;
    private void Awake()
    {
        _spawnBonus = GetComponentsInChildren<BonusSpawnPoint>();
        _spawnPoint = GetComponentsInChildren<BlockSpawnPoint>();
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        for (int i = 0; i < _ripeatCount; i++)
        {
            MoveSpawner(_distanceBeetwenFullLine);        
            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _wallSpawnChang, _distanceBeetwenFullLine, _distanceBeetwenFullLine / 2f);
            GenerateFullLine(_spawnPoint,_blockTemplate.gameObject);
            MoveSpawner(_distanceBeetweenRandomLine);
            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _wallSpawnChang, _distanceBeetweenRandomLine, _distanceBeetweenRandomLine / 2f);
            GenerateRandomLine(_spawnPoint, _blockTemplate.gameObject, _blockSpawnCange);
            GenerateRandomLine(_spawnBonus, _bonusTemplate.gameObject, _bonusSpawnChange,2);
        }
    }

    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generateElement)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateElement(spawnPoints[i].transform.position, generateElement);
        }
    }

    private void GenerateRandomLine(SpawnPoint[] spawnPoints, GameObject generateElement, int spawnChange, int scaleY = 1, float offsetY = 0)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if(Random.Range(0,100)< spawnChange)
            {
                GameObject element = GenerateElement(spawnPoints[i].transform.position, generateElement, offsetY);
                element.transform.localScale = new Vector3(element.transform.localScale.x, scaleY, element.transform.localScale.z);
            }
        }
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject generateElement, float offsetY = 0)
    {
        spawnPoint.y -= offsetY;
        return Instantiate(generateElement, spawnPoint,Quaternion.identity,_conteiner);
    }

    private void MoveSpawner(int distanceY)
    {
        transform.position = new Vector3(transform.position.x,transform.position.y + distanceY ,transform.position.z);
    }
}
