using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashlightController : BaseController
    {
        private FleshLightModel _model;

        private void Awake()
        {
            _model = FindObjectOfType<FleshLightModel>();
            _model.Off();
        }

        public void SwitchFlashlight()
        {
            //    if (_model.IsOn) _model.Off();
            //    else _model.On();
            if (_model.IsOn)
            {
                _model.Off();
            }
            else
            {
                if (_model._energy > 30)
                {
                    _model.On();
                }
            }
        }
    }
}
