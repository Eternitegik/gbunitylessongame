using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenesScript : MonoBehaviour {

    public GameObject _lights;
    public GameObject _ceiling;

    [SerializeField]
    private bool _onOff = true;

    private void Awake()
    {
        if (_onOff)
        {
            _lights.SetActive(false);
            _ceiling.SetActive(true);
        }

    }
}
