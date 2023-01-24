using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class enableLight : MonoBehaviour
{
    private int _trueAnswers;
    private int _answer;

    public GameObject lamp;
    [SerializeField] private InputField _inputAnswer;
    [SerializeField] private Text _wordText, _pointsArwer;

    private map _scriptMap;
    private void Start()
    {
        _scriptMap = GameObject.Find("map").GetComponent<map>();
        GenerateNumbersAndAnswer();
    }

    private void GenerateNumbersAndAnswer()
    {
        void GenerateNumbers(int nums, int num, int num1, int metod)
        {
            _answer = nums;
            if (metod == 0)
                _wordText.text = num.ToString()+ " + " + num1.ToString();
            else if (metod == 1)
                _wordText.text = num.ToString()+ " - " + num1.ToString();
        }

        int num, num1, metod = 0;
        num = Random.Range(0, 100);
        num1 = Random.Range(0, 100);
        metod = Random.Range(0, 2);
        if (metod == 0)
            GenerateNumbers(num + num1, num, num1, metod);
        else
            GenerateNumbers(num - num1, num, num1, metod);
    }

    public void CheckAnswer()
    {
        if (_inputAnswer.text == _answer.ToString())
            _trueAnswers++;
        else
            _trueAnswers = 0;
        _pointsArwer.text = _trueAnswers.ToString();
        _inputAnswer.text = "";
        if (_trueAnswers == 5)
        {
            lamp.gameObject.SetActive(true);
            _scriptMap.lampEnable = true;
            this.gameObject.SetActive(false);
        }
        GenerateNumbersAndAnswer();
    }

    public void ExitMenu()
    {
        this.gameObject.SetActive(false);
    }
}
