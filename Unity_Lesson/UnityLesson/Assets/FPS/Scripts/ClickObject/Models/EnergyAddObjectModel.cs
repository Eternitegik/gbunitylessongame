using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class EnergyAddObjectModel : MonoBehaviour
    {
        private Vector3 _deletPosition;
        private Transform _transform;

        public float _energy;

        private void Awake()
        {
            //_deletPosition = new Vector3(Random.Range(-2f,2f), -1, Random.Range(-2f,2f));
            _deletPosition = new Vector3(0, -1, 0);
            _transform = gameObject.GetComponent<Transform>();
        }

        public void DestroyMove()
        {
            _transform.position = _deletPosition;
        }
    }
}
