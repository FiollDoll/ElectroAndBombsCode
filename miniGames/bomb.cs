using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bomb : MonoBehaviour
{
    [Header("Cover")]
    [SerializeField] private GameObject[] _bolts = new GameObject[4];
    [SerializeField] private Sprite[] _boltsSprite = new Sprite[2];

    private int _boltsMode;
    private int _buttonsLive = 4;

    [Header("BlockMachine")]
    [SerializeField] private GameObject[] _wires = new GameObject[5];
    [SerializeField] private map _scriptMap;

    private void Start()
    {
        GameObject.Find("Canvas/menus/bombMenu/bgCover").GetComponent<Image>().color = _scriptMap.colorsBox[_scriptMap.colorTotal];
        _boltsMode = Random.Range(0, 2);
        for (int i = 0; i < 4; i++)
            _bolts[i].GetComponent<Image>().sprite = _boltsSprite[_boltsMode];
    }

    private void OnEnable()
    {
        if (_buttonsLive == 0)
        {
            GameObject.Find("Canvas/menus/bombMenu/bgCover").GetComponent<Animator>().SetBool("remove", true);
            for (int i = 0; i < 4; i++)
                _bolts[i].gameObject.SetActive(false);
        }
    }

    public void BoltRemove(Button bolt)
    {
        bolt.GetComponent<Animator>().SetBool("activate", true);
        _buttonsLive--;
        if (_buttonsLive == 0)
            GameObject.Find("Canvas/menus/bombMenu/bgCover").GetComponent<Animator>().SetBool("remove", true);
    }

    public void WiresManage(int wiresNumber)
    {
        _wires[wiresNumber].GetComponent<Image>().color = Color.blue;
        if (wiresNumber == 5)
            Debug.Log("true");
    }
}
