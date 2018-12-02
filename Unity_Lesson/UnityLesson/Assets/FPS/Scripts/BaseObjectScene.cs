using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace FPS
//{
//    /// <summary>
//    /// Базовый класс всех объектов на сцене
//    /// </summary>
//    public abstract class BaseObjectScene : MonoBehaviour
//    {
//        protected int _layer;
//        public int Layer
//        {
//            get
//            {
//                return _layer;
//            }
//            set
//            {
//                _layer = value;
//                SetLayers(transform, _layer);
//            }
//        }

//        private string _name;
//        public string Name
//        {
//            get
//            {
//                return _name;
//            }
//            set
//            {
//                _name = value;
//                name = _name;
//            }
//        }


//        protected bool _isVisible;
//        public bool IsVisible
//        {
//            get
//            {
//                if (!_renderer)
//                    return false;

//                return _renderer.enabled;
//            }
//            set
//            {
//                _isVisible = value;
//                SetVisibility(transform, _isVisible);
//            }
//        }

//        protected Collider _collider;
//        public Collider Collider
//        {
//            get
//            {
//                if (!_collider) _collider = GetComponent<Collider>();
//                return _collider;
//            }
//        }

//        protected Rigidbody _rigidbody;
//        public Rigidbody Rigidbody
//        {
//            get
//            {
//                return _rigidbody;
//            }
//        }
//        protected Material _material;
//        public Material Material
//        {
//            get
//            {
//                return _material;
//            }
//        }

//        protected GameObject _gameobject;
//        public GameObject GameObject
//        {
//            get
//            {
//                return _gameobject;
//            }
//        }

//        protected Renderer _renderer;
//        protected Color _color;
//        public Color Color
//        {
//            get
//            {
//                return _color;
//            }
//            set
//            {
//                _color = value;
//                _material.color = _color;
//            }
//        }

//        protected virtual void Awake()
//        {
//            _gameobject = GetComponent<GameObject>();
//            _rigidbody = GetComponent<Rigidbody>();
//            Name = name;
//            _layer = gameObject.layer;

//            _renderer = GetComponent<Renderer>();
//            if (_renderer)
//                _material = _renderer.material;
//            if (_material)
//                _color = _material.color;
//        }

//        private void SetLayers(Transform objTransform, int layer)
//        {
//            objTransform.gameObject.layer = layer;
//            foreach (Transform c in objTransform)
//            {
//                SetLayers(c, layer);
//            }
//        }

//        private void SetVisibility(Transform objTransform, bool visible)
//        {
//            var rend = objTransform.GetComponent<Renderer>();
//            if (rend)
//                rend.enabled = visible;

//            foreach (var r in GetComponentsInChildren<Renderer>(true))
//                r.enabled = visible;
//        }
//    }
//}

namespace FPS
{
    /// <summary>
    /// Базовый класс всех объектов на сцене
    /// </summary>
    public abstract class BaseObjectScene : MonoBehaviour
    {
        protected int _layer;
        protected Color _color;
        protected Material _material;
        protected Transform _myTransform;
        protected Vector3 _position;
        protected Quaternion _rotation;
        protected Vector3 _scale;
        protected GameObject _instanceObject;
        protected Rigidbody _rigidbody;
        protected string _name;
        protected bool _isVisible;

        #region UnityFunction
        protected virtual void Awake()
        {
            _instanceObject = gameObject;
            _name = _instanceObject.name;
            if (GetComponent<Renderer>())
            {
                _material = GetComponent<Renderer>().material;
            }
            _rigidbody = _instanceObject.GetComponent<Rigidbody>();
            _myTransform = _instanceObject.transform;
        }
        #endregion

        #region Property
        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                InstanceObject.name = _name;
            }
        }
        /// <summary>
        /// Слой объекта
        /// </summary>
        public int Layers
        {
            get { return _layer; }
            set
            {
                _layer = value;

                if (_instanceObject != null)
                {
                    _instanceObject.layer = _layer;
                }
                if (_instanceObject != null)
                {
                    AskLayer(GetTransform, value);
                }
            }
        }
        /// <summary>
        /// Цвет материала объекта
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                if (_material != null)
                {
                    _material.color = _color;
                }
                AskColor(GetTransform, _color);
            }
        }
        public Material GetMaterial
        {
            get { return _material; }
        }

        /// <summary>
        /// Позиция объекта
        /// </summary>
        public Vector3 Position
        {
            get
            {
                if (InstanceObject != null)
                {
                    _position = GetTransform.position;
                }
                return _position;
            }
            set
            {
                _position = value;
                if (InstanceObject != null)
                {
                    GetTransform.position = _position;
                }
            }
        }
        /// <summary>
        /// Размер объекта
        /// </summary>
        public Vector3 Scale
        {
            get
            {
                if (InstanceObject != null)
                {
                    _scale = GetTransform.localScale;
                }
                return _scale;
            }
            set
            {
                _scale = value;
                if (InstanceObject != null)
                {
                    GetTransform.localScale = _scale;
                }
            }
        }
        /// <summary>
        /// Поворот объекта
        /// </summary>
        public Quaternion Rotation
        {
            get
            {
                if (InstanceObject != null)
                {
                    _rotation = GetTransform.rotation;
                }

                return _rotation;
            }
            set
            {
                _rotation = value;
                if (InstanceObject != null)
                {
                    GetTransform.rotation = _rotation;
                }
            }
        }
        /// <summary>
        /// Получить физическое свойство объекта
        /// </summary>
        public Rigidbody GetRigidbody
        {
            get { return _rigidbody; }
        }
        /// <summary>
        /// Ссылка на gameObject
        /// </summary>
        public GameObject InstanceObject
        {
            get { return _instanceObject; }
        }
        /// <summary>
        /// Скрывает/показывает объект
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                if (_instanceObject.GetComponent<MeshRenderer>())
                    _instanceObject.GetComponent<MeshRenderer>().enabled = _isVisible;
                if (_instanceObject.GetComponent<SkinnedMeshRenderer>())
                    _instanceObject.GetComponent<SkinnedMeshRenderer>().enabled = _isVisible;
            }
        }
        /// <summary>
        /// Получить Transform объекта
        /// </summary>
        public Transform GetTransform
        {
            get { return _myTransform; }
        }

        #endregion


        #region PrivateFunction
        /// <summary>
        /// Выставляет слой себе и всем вложенным объектам независимо от уровня вложенности
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="lvl">Слой</param>
        private void AskLayer(Transform obj, int lvl)
        {
            obj.gameObject.layer = lvl;       // Выставляем объекту слой
            if (obj.childCount > 0)
            {
                foreach (Transform d in obj) // Проходит по всем вложенным объектам
                {
                    AskLayer(d, lvl);        // Рекурсивный вызов функции
                }
            }
        }

        /// <summary>
        /// Выставляет цвет себе и всем вложенным объектам независимо от уровня вложенности
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="color">Цвет</param>
        private void AskColor(Transform obj, Color color)
        {
            obj.gameObject.GetComponent<Renderer>().material.color = color; // Выставляем объекту слой
            if (obj.childCount > 0)
            {
                foreach (Transform c in obj) // Проходит по всем вложенным объектам
                {
                    AskColor(c, color);        // Рекурсивный вызов функции
                }
            }
        }
        #endregion

    }
}
