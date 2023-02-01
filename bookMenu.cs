using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bookMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pageMain, _page;
    [SerializeField] private Sprite[] _pagesSprites = new Sprite[8];

    public void ActivatePage(int page)
    {
        _pageMain.gameObject.SetActive(false);
        _page.gameObject.SetActive(true);
        _page.gameObject.GetComponent<Image>().sprite = _pagesSprites[page];
    }

    public void MainPageRemove()
    {
        _pageMain.gameObject.SetActive(true);
        _page.gameObject.SetActive(false);
    }
}
