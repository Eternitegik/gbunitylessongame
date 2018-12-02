using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class FlashlightViewText : MonoBehaviour
    {

        private Text _text;
        private FleshLightModel _fleshLightModel;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _fleshLightModel = FindObjectOfType<FleshLightModel>();
        }

        private void Update()
        {
            _text.text = _fleshLightModel._energy.ToString();
        }
    }
}
