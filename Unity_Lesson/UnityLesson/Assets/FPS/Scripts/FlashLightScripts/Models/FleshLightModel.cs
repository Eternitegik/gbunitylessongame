using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FleshLightModel : MonoBehaviour
    {
        public event Action<bool> FlashlightStateChanged;

        private Light _Light;

        public bool IsOn {get { return _Light.enabled; } }
        [Space(10)]
        public float _energy; //Исходное количество заряда в фонарике
        public float _deley; //Задержка при работе с зарядом в фонарике
        public float _reduceEnergy; //Количество отнимаемого заряда
        public float _addEnergy; //Количество добавляемого заряда

        private void Awake()
        {
            _Light = GetComponent<Light>();
            StartCoroutine(FLEnergy());
        }

        public void On()
        {
            _Light.enabled = true;
            if (FlashlightStateChanged != null) FlashlightStateChanged.Invoke(true);
        }

        public void Off()
        {
            _Light.enabled = false;
            if (FlashlightStateChanged != null) FlashlightStateChanged.Invoke(false);
        }

        IEnumerator FLEnergy()
        {
            while (true)
            {
                yield return new WaitForSeconds(_deley);
                if (_Light.enabled)
                {
                    if(_energy > 0) _energy -= _reduceEnergy;
                }
                else
                {
                    if (_energy < 100) _energy += _addEnergy;
                }
                if (_energy > 100) _energy = 100;
                if (_energy == 0) Off();
            }
        }
    }
}
