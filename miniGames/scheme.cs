using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scheme : MonoBehaviour
{
    [Header("Sprites/Obj")]
    [SerializeField] private Sprite[] _objectsSprite = new Sprite[0];
    private Dictionary<string, int> _objectDict;
    [SerializeField] private Sprite[] _bgSchemeSprite = new Sprite[0];
    [SerializeField] private GameObject _bgScheme;

    [SerializeField] private GameObject[] _vars = new GameObject[0];
    [SerializeField] private GameObject[] _buttonsInVars = new GameObject[5];


    [Header("Panels")]
    [SerializeField] private GameObject _panelChoicePlace;

    [Header("Other")]
    [SerializeField] private map _scriptMap;
    public string[] _playerAnswer = new string[4];
    public string[] _trueAnswers = new string[4];

    private int _totalPlace;

    private void Start()
    {
        _objectDict = new Dictionary<string, int>()
        {
            ["lampGreen"] = 0, ["lampBlue"] = 1, ["lampRed"] = 2,
            ["lampYellow"] = 3, ["key"] = 4, ["zvonok"] = 5
        };
        int randomScheme = Random.Range(0, 13);
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
        else if (randomScheme == 5)
            NewTrueAnswer(4, "zvonok", "key", "lampRed");  
        else if (randomScheme == 6)
            NewTrueAnswer(4, "zvonok", "key", "lampRed");  
        else if (randomScheme == 7)
            NewTrueAnswer(4, "zvonok", "key", "lampRed");  
        else if (randomScheme == 8)
            NewTrueAnswer(4, "zvonok", "key", "lampRed");  
        else if (randomScheme == 9)
            NewTrueAnswer(4, "zvonok", "key", "lampRed");  
        else if (randomScheme == 10)
            NewTrueAnswer(4, "zvonok", "key", "lampRed");  
        else if (randomScheme == 11)
            NewTrueAnswer(4, "zvonok", "key", "lampRed");  
    }

    private void NewTrueAnswer(int schemeBg, string obj = "", string obj1 = "", string obj2 = "", string obj3 = "", string obj4 = "")
    {
        _trueAnswers[0] = obj;
        _trueAnswers[1] = obj1;
        _trueAnswers[2] = obj2;
        _trueAnswers[3] = obj3;
        _bgScheme.GetComponent<Image>().sprite = _bgSchemeSprite[schemeBg];
        _vars[schemeBg].gameObject.SetActive(true);
        _vars[schemeBg].transform.name = "varTotal";
        for (int i = 1; i < _buttonsInVars.Length; i++)
            _buttonsInVars[i - 1] = GameObject.Find($"Canvas/menus/SchemeMenu/vars/varTotal/Button{i}");
        for (int i = 0; i < _vars.Length; i++)
            Destroy(GameObject.Find($"Canvas/menus/SchemeMenu/vars/var{i}"));
    }

    public void SetObj(string obj)
    {
        _playerAnswer[_totalPlace] = obj;
        _buttonsInVars[_totalPlace].GetComponent<Image>().sprite = _objectsSprite[_objectDict[obj]];
        _panelChoicePlace.gameObject.SetActive(false);
    }

    public void SetPlace(int place)
    {
        _panelChoicePlace.gameObject.SetActive(true);
        _totalPlace = place;
    }

    public void Check()
    {
        if (_trueAnswer[0] == _answerPlayer[0] || _trueAnswer[1] == _answerPlayer[1] || _trueAnswer[2] == _answerPlayer[2] || _trueAnswer[3] == _answerPlayer[3] || _trueAnswer[4] == _answerPlayer[4] || _trueAnswer[5] == _answerPlayer[5])
        {
            this.gameObject.SetActive(false);
            _scriptMap.GamesReadyUpdate();
        }
    } 
}
