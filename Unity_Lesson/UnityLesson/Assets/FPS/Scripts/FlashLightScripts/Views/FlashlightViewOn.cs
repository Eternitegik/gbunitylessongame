using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class FlashlightViewOn : MonoBehaviour
    {
        private Image _image;
        private FleshLightModel _fleshLightModel;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _fleshLightModel = FindObjectOfType<FleshLightModel>();
            _fleshLightModel.FlashlightStateChanged += OnFlashlightStateChanged;
            OnFlashlightStateChanged(false);
        }

        private void OnFlashlightStateChanged(bool state)
        {
            _image.enabled = state ? _image.enabled = true : _image.enabled = false;
        }
    }
}
