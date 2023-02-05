using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class algebra : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private float[] _trueAnswers = new float[3];
    [SerializeField] private Text[] _textsQuestion = new Text[3];
    [SerializeField] private InputField[] _inputPlayer = new InputField[3];

    [Header("Other")]
    [SerializeField] private Text _textError;
    [SerializeField] private map _scriptMap;
    [SerializeField] private menusOptions _scriptMenus;
    private int _algebraMode;
    
    private void Start()
    {
        _algebraMode = Random.Range(0, 3);
        if (_algebraMode == 0)
            GenerateUmnozh();
        else if (_algebraMode == 1)
            GenerateDrobi();
        else if ((_algebraMode == 2))
            GenerateUravnenia(Random.Range(0, 2));
    }

    private void GenerateUmnozh()
    {
        for (int i = 0; i < 3; i++)
        {
            int num = Random.Range(0, 101), umnozh = Random.Range(1, 11);
            _textsQuestion[i].text = $"{num.ToString()} * {umnozh.ToString()} = ";
            _trueAnswers[i] = num * umnozh;
            Debug.Log(_trueAnswers[i]);
        }
    }


    private void GenerateDrobi()
    {
        for (int i = 0; i < 3; i++)
        {
            int num = Random.Range(0, 101), delenie = Random.Range(1, 11);
            _textsQuestion[i].text = $"{num.ToString()} / {delenie.ToString()} = ";
            _trueAnswers[i] = num / delenie;
            _trueAnswers[i] = Mathf.Round(_trueAnswers[i]);
            Debug.Log(_trueAnswers[i]);
        }
    }

    private void GenerateUravnenia(int mode)
    {
        void SetUravnenie(int i, string textMath, int answer)
        {
            _textsQuestion[i].text = textMath;
            _trueAnswers[i] = answer;
            Debug.Log(_trueAnswers[i]);
        }
        if (mode == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                int num = Random.Range(0, 20), num1 = Random.Range(0, 11), num2 = Random.Range(0, 20);
                int uravnenieMode = Random.Range(0, 6);
                if (uravnenieMode == 0)
                    SetUravnenie(i, $"x + {num} = {num1} + {num2}", num1 + num2 - num);
                else if (uravnenieMode == 1)
                    SetUravnenie(i, $"x - {num} + {num1} = {num2}", num2 + num - num1);
                else if (uravnenieMode == 2)
                    SetUravnenie(i, $"x = {num2} - {num} - {num1}", num2 - num - num1);
                else
                    SetUravnenie(i, $"x = {num1} + {num2}  + {num}", num1 + num2 + num);
            }
        }
        else
        {
            GenerateUravnenia(0);
        }
    }

    public void CheckAnswers()
    {
        if (_inputPlayer[0].text == _trueAnswers[0].ToString() && _inputPlayer[1].text == _trueAnswers[1].ToString() && _inputPlayer[2].text == _trueAnswers[2].ToString())
        {
            this.gameObject.SetActive(false);
            _scriptMap.GamesReadyUpdate();
        }
        else
            _scriptMenus.ViewError(_textError);
    }
}
