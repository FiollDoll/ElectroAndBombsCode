using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    [Header("Stats")]
    public int readyGames;
    public float _timerLamp;
    public bool lampEnable;

    [Header("ObjectsInMap")]
    [SerializeField] private Transform[] _spawners = new Transform[12];
    [SerializeField] private GameObject[] _objects = new GameObject[0];

    private int[] _objectsInScene = new int[6];
    private int[] _spawnersActive = new int[14];

    [Header("Bomb")]
    public Color[] colorsBox = new Color[3];
    public int colorTotal;

    [SerializeField] private enableLight _scriptEL;
    [SerializeField] private bomb _scriptBomb;
    
    private void Start()
    {
        CreateRoom();
    }

    private void CreateRoom()
    {
        colorTotal = Random.Range(0, 3);
        GameObject.Find("map/bomb").GetComponent<SpriteRenderer>().color = colorsBox[colorTotal];
        for (int i = 0; i < 5; i++) 
        {
            int objectNum = Random.Range(0, _objects.Length);
            int spawnerNum = Random.Range(0, _spawners.Length);
            for (int a = 0; a < _objectsInScene.Length; a++)
            {
                if (_objectsInScene[objectNum] == 1)
                    objectNum = Random.Range(0, _objects.Length);
            }
            for (int e = 0; e < _spawnersActive.Length; e++)
            {
                if (_spawnersActive[spawnerNum] == 1)
                    spawnerNum = Random.Range(0, _spawners.Length);
            }

            Instantiate(_objects[objectNum], _spawners[spawnerNum].position, Quaternion.identity);
            
            _objectsInScene[objectNum] = 1;
            _spawnersActive[spawnerNum] = 1;
        }        
    }

    public void GamesReadyUpdate()
    {
        _scriptBomb.WiresManage(readyGames);
        readyGames++;
    }

    private void Update()
    {
        if (lampEnable)
        {
            _timerLamp += Time.deltaTime;
            if (_timerLamp >= 80)
            {
                _timerLamp = 0;
                _scriptEL.lamp.gameObject.SetActive(false);
                lampEnable = false;
            }
        }
    }
}
