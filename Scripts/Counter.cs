using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private float _delay = 0.5f;
    private int _count;
    private bool _isEnabled;
    private Coroutine _countingCoroutine;
    private float _timer;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isEnabled  == false)
            Enable();
        else if (Input.GetMouseButtonDown(0) && _isEnabled)
            Disable();
    }

    private void Enable()
    {
        _isEnabled = true;
        _countingCoroutine = StartCoroutine(Count());
    }

    private void Disable()
    {
        _isEnabled = false;
        StopCoroutine(_countingCoroutine);
    }

    private IEnumerator Count()
    {
        while (_isEnabled)
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _delay)
            {
                _timer %= _delay;
                _count++;
                _text.text = _count.ToString();
            }
            
            yield return null;
        }
    }
}
