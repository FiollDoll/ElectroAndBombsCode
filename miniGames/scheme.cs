using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scheme : MonoBehaviour
{
    [Header("Sprites/Obj")]
    [SerializeField] private Sprite[] _objectsSprite = new Sprite[0];

    [SerializeField] private Sprite[] _bgSchemeSprite = new Sprite[0];
    [SerializeField] private GameObject _bgScheme;

    [SerializeField] private GameObject[] _objectsPlace = new GameObject[0];

    [Header("Panels")]
    [SerializeField] private GameObject _panelChoicePlace;

    private string[] _playerAnswer = new string[4];
    private string[] _trueAnswers = new string[4];

    private string totalObj;

    private void Start()
    {
        int randomScheme = Random.Range(0, 5);
        if (randomScheme == 0)
            NewTrueAnswer(0, "key", "lampRed", "lampBlue");
        else if (randomScheme == 1)
            NewTrueAnswer(1, "lampGreen", "key", "lampBlue", "lampGreen");
        else if (randomScheme == 2)
            NewTrueAnswer(2, "key", "Green");
        else if (randomScheme == 3)
            NewTrueAnswer(3, "lampGreen", "lampRed", "lampBlue");
        else if (randomScheme == 4)
            NewTrueAnswer(4, "zvonok", "key", "lampRed");    
    }

    private void NewTrueAnswer(int schemeBg, string obj = "", string obj1 = "", string obj2 = "", string obj3 = "")
    {
        _trueAnswers[0] = obj;
        _trueAnswers[1] = obj1;
        _trueAnswers[2] = obj2;
        _trueAnswers[3] = obj3;
        _bgScheme.GetComponent<SpriteRenderer>().sprite = _bgSchemeSprite[schemeBg];
    }

    public void ActivateSchemeConstruct(string obj)
    {
        totalObj = obj;
        _panelChoicePlace.gameObject.SetActive(true);
    }

    public void SetPlace(int place)
    {
        _panelChoicePlace.gameObject.SetActive(false);
        _trueAnswers[place] = totalObj;
        totalObj = "";
    }

    public void ExitScheme()
    {
        this.gameObject.SetActive(false);
    }
}
