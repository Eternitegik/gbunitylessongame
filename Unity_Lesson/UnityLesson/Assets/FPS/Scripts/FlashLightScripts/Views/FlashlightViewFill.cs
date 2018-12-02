using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class FlashlightViewFill : MonoBehaviour
    {

        private Image _image;
        private FleshLightModel _fleshLightModel;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _fleshLightModel = FindObjectOfType<FleshLightModel>();
        }

        private void Update()
        {
            _image.fillAmount = _fleshLightModel._energy / 100;
        }
    }
}
