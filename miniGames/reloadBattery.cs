using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reloadBattery : MonoBehaviour
{

    [SerializeField] private Text _textBattery, _textActiveOrNot;
    private bool _activeOrNot;
    [SerializeField] private player _playerScript;
    private float _batteryTotal;

    public void SetFlashLight()
    {
        void Set(bool activate, bool haveBattery, string status, bool buttonInteractable, float battery)
        {
            _activeOrNot = activate;
            _playerScript.haveBattery = haveBattery;
            _textActiveOrNot.text = status;    
            _batteryTotal = battery;  
            GameObject.Find("Canvas/ButtonFlashLight").GetComponent<Button>().interactable = buttonInteractable;        
        }
        if (_activeOrNot)
        {
            _playerScript._battery = _batteryTotal;        
            Set(false, true, "неактивно", true, 0);    
        }
        else
            Set(true, false, "Активно", false, _playerScript._battery);
    }

    private void Update()
    {
        if (_activeOrNot)
        {
            _textBattery.text = (_batteryTotal * 25).ToString();
            _batteryTotal += 0.5f * Time.deltaTime;
            Debug.Log(_batteryTotal);
        }
    }
}
