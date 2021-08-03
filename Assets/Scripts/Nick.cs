using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nick : MonoBehaviour
{
    [SerializeField] private GameObject _pref;

    [SerializeField] public GameObject _target { private get; set; }

    private GameObject _nick;
    private void Start()
    {
        _nick = Instantiate(_pref);
        _nick.transform.parent = GameObject.Find("Canvas").transform;
        _nick.SetActive(true);
    }

    private void Update()
    {
        if (!_target) return;
        var kek = Camera.main.WorldToScreenPoint(new Vector3(_target.transform.position.x, _target.transform.position.y + 1, _target.transform.position.z));
        RectTransform rectTransform = _nick.GetComponent<RectTransform>();
        rectTransform.position = kek;
    }
}
