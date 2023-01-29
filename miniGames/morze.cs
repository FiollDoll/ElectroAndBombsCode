using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class morze : MonoBehaviour
{
    [SerializeField] private Text[] _morzeText = new Text[3];
    [SerializeField] private InputField[] _morzeInput = new InputField[3];

    public string[] _trueAnswers = new string[3];
    
    public map _scriptMap;

    private void Start()
    {
        GenerateMorze();
    }

    private void GenerateMorze()
    {
        Dictionary<string, string> answers = new Dictionary<string, string>()
        {
            ["0"] = "-----", ["1"] = ".----", ["2"] = "..---",
            ["3"] = "...--", ["4"] = "....-", ["5"] = ".....",
            ["6"] = "-....", ["7"] = "--...", ["8"] = "---..",
            ["9"] = "----."
        };

        for (int i = 0; i < 3; i++)
        {
            int num = Random.Range(0, 10);
            _trueAnswers[i] = $"{num}";
            _morzeText[i].text = answers[$"{num}"];    
        }
    }

    public void CheckMozre()
    {
        if (_morzeInput[0].text == _trueAnswers[0] && _morzeInput[1].text == _trueAnswers[1] && _morzeInput[2].text == _trueAnswers[2])
        {
            this.gameObject.SetActive(false);
            _scriptMap.GamesReadyUpdate();
            for (int i = 0; i < 3; i++)
                _morzeInput[i].interactable = false;
        }
    }

    public void ExitMorze()
    {
        this.gameObject.SetActive(false);
    }
}
