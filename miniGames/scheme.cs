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
    [SerializeField] private Text _textError;
    [SerializeField] private map _scriptMap;
    [SerializeField] private menusOptions _scriptMenus;
    [SerializeField] private string[] _playerAnswer = new string[5];
    [SerializeField] private string[] _trueAnswers = new string[5];

    private int _totalPlace;

    private void Start()
    {
        _objectDict = new Dictionary<string, int>()
        {
            ["lampGreen"] = 0, ["lampBlue"] = 1, ["lampRed"] = 2,
            ["lampYellow"] = 3, ["key"] = 4, ["zvonok"] = 5
        };
        int randomScheme = Random.Range(0, 11);
        if (randomScheme == 0)
            NewTrueAnswer(0, "key", "lampGreen", "lampGreen", "lampRed", "zvonok");
        else if (randomScheme == 1)
            NewTrueAnswer(1, "zvonok", "lampRed", "key");
        else if (randomScheme == 2)
            NewTrueAnswer(2, "key", "zvonok", "lampRed", "lampYellow", "lampGreen");
        else if (randomScheme == 3)
            NewTrueAnswer(3, "key", "zvonok");
        else if (randomScheme == 4)
            NewTrueAnswer(4, "key", "zvonok", "zvonok");    
        else if (randomScheme == 5)
            NewTrueAnswer(5, "key", "lampBlue");  
        else if (randomScheme == 6)
            NewTrueAnswer(6, "key", "lampGreen", "lampBlue", "zvonok", "lampRed");  
        else if (randomScheme == 7)
            NewTrueAnswer(7, "lampBlue", "key", "lampGreen", "zvonok", "lampRed");  
        else if (randomScheme == 8)
            NewTrueAnswer(8, "lampGreen", "lampBlue", "key", "lampRed", "zvonok");  
        else if (randomScheme == 9)
            NewTrueAnswer(9, "lampGreen", "lampBlue", "key", "lampRed", "zvonok");  
        else if (randomScheme == 10)
            NewTrueAnswer(10, "key", "lampGreen", "lampBlue", "zvonok", "lampRed");   
    }

    private void NewTrueAnswer(int schemeBg, string obj = "", string obj1 = "", string obj2 = "", string obj3 = "", string obj4 = "")
    {
        _trueAnswers[0] = obj;
        _trueAnswers[1] = obj1;
        _trueAnswers[2] = obj2;
        _trueAnswers[3] = obj3;
        _trueAnswers[4] = obj4;
        _bgScheme.GetComponent<Image>().sprite = _bgSchemeSprite[schemeBg];
        _vars[schemeBg].gameObject.SetActive(true);
        _vars[schemeBg].transform.name = "varTotal";
        for (int i = 1; i < _buttonsInVars.Length + 1; i++)
            _buttonsInVars[i - 1] = GameObject.Find($"Canvas/menus/SchemeMenu/vars/varTotal/Button{i}");
        for (int i = 0; i < _vars.Length + 1; i++)
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

    public void CheckScheme()
    {
        if (_trueAnswers[0] == _playerAnswer[0] && _trueAnswers[1] == _playerAnswer[1] && _trueAnswers[2] == _playerAnswer[2] && _trueAnswers[3] == _playerAnswer[3] && _trueAnswers[4] == _playerAnswer[4])
        {
            this.gameObject.SetActive(false);
            _scriptMap.GamesReadyUpdate();
        }
        else
            _scriptMenus.ViewError(_textError);
    } 
}
