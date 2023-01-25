using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering;

public class player : MonoBehaviour
{
    [Header("Stats")]
    private int _hp = 100;
    private int _oxugen = 100;

    public float _battery = 4;
   
    [Header("Sprites")]
    [SerializeField] private SpriteRenderer[] _spriteRendererBody = new SpriteRenderer[8];
    [SerializeField] private Sprite[] _spriteHead = new Sprite[3];
    [SerializeField] private Sprite[] _spriteLeck= new Sprite[3];
    [SerializeField] private Sprite[] _spriteBody = new Sprite[3];
    [SerializeField] private Sprite[] _spriteArm = new Sprite[3];
    [SerializeField] private Sprite[] _spriteLeg = new Sprite[3];
    [SerializeField] private Sprite[] _spriteFeet = new Sprite[3];

    [Header("Menus")]
    [SerializeField] private GameObject[] _menus = new GameObject[0];

    [Header("Texts")]
    [SerializeField] private Text _textTimer;
    [SerializeField] private Text _hpText, _oxugenText, _batteryText;

    [Header("Other")]
    [SerializeField] private GameObject _buttonActive;
    private string _objectTrigger;
    public float _timer;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _flashlight;
    private bool _openInventory;

    private void Start()
    {
        int bodyInt = Random.Range(0, 3);
        _spriteRendererBody[0].sprite = _spriteHead[bodyInt];
        _spriteRendererBody[1].sprite = _spriteLeck[bodyInt];
        _spriteRendererBody[2].sprite = _spriteBody[bodyInt];
        _spriteRendererBody[3].sprite = _spriteArm[bodyInt];
        _spriteRendererBody[4].sprite = _spriteArm[bodyInt];
        _spriteRendererBody[5].sprite = _spriteLeg[bodyInt];
        _spriteRendererBody[6].sprite = _spriteLeg[bodyInt];
        _spriteRendererBody[7].sprite = _spriteFeet[bodyInt];
        _spriteRendererBody[8].sprite = _spriteFeet[bodyInt];
    }

    private void Move(float x, float y)
    {
        if (_timer >= 0)
            transform.position += new Vector3(x, y, 0);
        StartCoroutine(Walk());
    }

    public void MoveX(float x)
    {
        Move(x, 0);
    }

    public void MoveY(float y)
    {
        Move(0, y);
    }

    public void ButtonActivate()
    {
        Dictionary<int, string> objects = new Dictionary<int, string>()
        {
            [0] = "book", [1] = "enableLight", [2] = "defeat",
            [3] = "Chemistry(Clone)", [4] = "algebra(Clone)", [5] = "morze(Clone)",
            [6] = "code(Clone)", [7] = "bomb", [8] = "Scheme(Clone)", 
            [9] = "boxExtrem", [10] = "batteryScheme", [11] = "phis(Clone)"
        };

        for (int i = 0; i < objects.Count; i++)
        {
            Debug.Log(_objectTrigger);
            if (_objectTrigger == objects[i])
                _menus[i].gameObject.SetActive(true);
        }
    }

    public void PlayerMenuOpen(bool activate)
    {
        _menus[2].gameObject.SetActive(activate);
        _openInventory = activate;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _buttonActive.gameObject.SetActive(true);
        _objectTrigger = other.gameObject.name;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _buttonActive.gameObject.SetActive(false);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        float timerMinut = Mathf.Round(_timer);
        _textTimer.text = "Осталось времени: " + timerMinut.ToString();
        
        if (_battery > 0)
        {
            _battery -= Time.deltaTime / 35;
            _flashlight.intensity = _battery / 4;            
        }
        if (_openInventory)
        {
            float battery = _battery * 25;
            _batteryText.text = "Заряд батареи: " + Mathf.Round(battery).ToString();
            _hpText.text = "Здоровье: " + _hp.ToString();
            _oxugenText.text = "Кислород: " + Mathf.Round(_oxugen).ToString();
        }
    }

    private IEnumerator Walk()
    {
        GetComponent<Animator>().SetBool("walk", true);
        yield return new WaitForSeconds(0.2f);
        GetComponent<Animator>().SetBool("walk", false);
    }
}
