using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public float _timerLamp;
    public bool lampEnable;

    [SerializeField] private Transform[] _spawners = new Transform[12];
    [SerializeField] private GameObject[] _objects = new GameObject[0];

    private int[] _objectsInScene = new int[6];
    private int[] _spawnersActive = new int[14];

    public enableLight _scriptEL;
    
    private void Start()
    {
        CreateRoom();
    }

    private void CreateRoom()
    {
        for (int i = 0; i < 5; i++) 
        {
            int _objectNum = Random.Range(0, _objects.Length);
            int _spawnerNum = Random.Range(0, _spawners.Length);
            for (int a = 0; a < _objectsInScene.Length; a++)
            {
                if (_objectsInScene[_objectNum] == 1)
                    _objectNum = Random.Range(0, _objects.Length);
            }
            for (int e = 0; e < _spawnersActive.Length; e++)
            {
                if (_spawnersActive[_spawnerNum] == 1)
                    _spawnerNum = Random.Range(0, _spawners.Length);
            }

            Instantiate(_objects[_objectNum], _spawners[_spawnerNum].position, Quaternion.identity);

            _objectsInScene[_objectNum] = 1;
            _spawnersActive[_spawnerNum] = 1;
        }        
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
