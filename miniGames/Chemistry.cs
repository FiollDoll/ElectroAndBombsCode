using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chemistry : MonoBehaviour
{
    [SerializeField] private GameObject[] _modeMenus = new GameObject[2];
    private int _mode;

    [Header("MettalOrNot")]
    [SerializeField] private Text[] _textElementsMettalOrNot = new Text[8];
    private string[] _elementsMetallOrNot = new string[8];
    public string[] _trueAnswerMetallOrNot = new string[8];
    private string[] _answerPlayerMetallOrNot = new string[8];

    [Header("Elements")]
    [SerializeField] private Text[] _textElements = new Text[4];
    private string[] _trueAnswer = new string[4];
    private string[] _answerPlayer = new string[4];
    private InputField[] _playerInput = new InputField[4];

    private void Start()
    {
        _mode = Random.Range(0, 2);
        _modeMenus[_mode].gameObject.SetActive(true);
        if (_mode == 0)
            MettalOrNotGenerate();
        else if (_mode == 1)
            ElementsGenerate();
    }

    private void MettalOrNotGenerate()
    {
        Dictionary<string, string> elements = new Dictionary<string, string>()
        {
            ["H"] = "NM", ["He"] = "NM", ["Li"] = "M", ["C"] = "NM", ["N"] = "NM",
            ["O"] = "NM", ["F"] = "NM", ["Na"] = "M", ["Mg"] = "M", ["Al"] = "M",
            ["Si"] = "NM", ["P"] = "NM", ["Cl"] = "NM", ["K"] = "M", ["Ca"] = "M",
            ["Ti"] = "M", ["Cr"] = "M", ["Mn"] = "M", ["Fe"] = "M", ["Co"] = "M",
            ["S"] = "NM", ["Ge"] = "M", ["As"] = "NM", ["Se"] = "NM", ["Br"] = "NM"
        };
            for (int i = 0; i < 8; i++)
            {
                int num = Random.Range(0, elements.Count);
                _textElementsMettalOrNot[i].text = elements.ElementAt(num).Key;
                _trueAnswerMetallOrNot[i] = elements.ElementAt(num).Value;
            }            
    }

    public void Mettal(int number)
    {
        _answerPlayerMetallOrNot[number] = "M";
        _textElementsMettalOrNot[number].color = new Color(0, 255, 0);
    }

    public void NMettal(int number)
    {
        _answerPlayerMetallOrNot[number] = "NM";
        _textElementsMettalOrNot[number].color = new Color(255, 0, 0);
    }

    public void MettalOrNotCheck()
    {
        int answersTrue = 0;
        for (int i = 0; i < 8; i++)
        {
            if (_answerPlayerMetallOrNot[i] == _trueAnswerMetallOrNot[i])
                answersTrue++;
            else
                answersTrue--;
        }
        if (answersTrue == 8)
        {
            this.gameObject.SetActive(false);
            // Добавить ещё учёт сделанных машин
            for (int i = 0; i < 3; i++)
                _textElementsMettalOrNot[i].text = "///";
        }

    }

    private void ElementsGenerate()
    {
        Dictionary<string, string> elements = new Dictionary<string, string>()
        {
            ["H"] = "водород", ["He"] = "гелий", ["Li"] = "литий", ["B"] = "бор",
            ["C"] = "углерод", ["Be"] = "берилий", ["Al"] = "алюминий", ["Mg"] = "магний",
            ["Si"] = "кремний", ["Na"] = "натрий", ["O"] = "кислород", ["F"] = "фтор",
            ["P"] = "фосфор", ["Cu"] = "медь", ["Zn"] = "цинк", ["I"] = "йод",
            ["Mn"] = "марганец", ["Fe"] = "железо", ["K"] = "калий", ["Ca"] = "кальций"
        };
        int mode = Random.Range(0, 2);

        for (int i = 0; i < 4; i++)
        {
            int num = Random.Range(0, elements.Count);
            if (mode == 0)
            {
                _textElements[i].text = elements.ElementAt(num).Key;
                _trueAnswer[i] = elements.ElementAt(num).Value;                
            }
            else
            {
                _textElements[i].text = elements.ElementAt(num).Value;
                _trueAnswer[i] = elements.ElementAt(num).Key;                    
            }
        }    
    }


    public void MenuExit()
    {
        this.gameObject.SetActive(false);
    }
}
