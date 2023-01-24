using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class code : MonoBehaviour
{
    [SerializeField] private Text[] _codeText = new Text[3];
    [SerializeField] private InputField[] _codeInput = new InputField[3];

    public string[] _trueAnswers = new string[3];
    
    private int _codeMode;

    private void Start()
    {
        _codeMode = Random.Range(0, 2);
        GenerateCode();
    }

    private void GenerateCode()
    {
        Dictionary<string, string> answers = new Dictionary<string, string>()
        {
            ["0"] = "q", ["1"] = "w", ["2"] = "e",
            ["3"] = "a", ["4"] = "s", ["5"] = "d",
            ["6"] = "f", ["7"] = "g", ["8"] = "h",
            ["9"] = "j"
        };

        if (_codeMode == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                int num = Random.Range(0, 10);
                _trueAnswers[i] = $"{num}";
                _codeText[i].text = answers[$"{num}"];    
            }
        }
        else
        {
            foreach (string key in answers.Keys)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (key == $"{Random.Range(0, 10)}")
                    {
                        _trueAnswers[i] = key;           
                        _codeText[i].text = answers[key];               
                    }    
                    else
                    {
                        string otherKey = $"{Random.Range(0, 10)}";
                        _trueAnswers[i] = answers[otherKey];           
                        _codeText[i].text = otherKey; 
                    } 
                }             
            }        
        }
    }

    public void CheckAnswer()
    {
        if (_codeInput[0].text == _trueAnswers[0] && _codeInput[1].text == _trueAnswers[1] && _codeInput[2].text == _trueAnswers[2])
        {
            this.gameObject.SetActive(false);
            // Добавить ещё учёт сделанных машин
            for (int i = 0; i < 3; i++)
                _codeInput[i].interactable = false;
            
        }  
    }

    public void ExitMenu()
    {
        this.gameObject.SetActive(false);
    }
}
