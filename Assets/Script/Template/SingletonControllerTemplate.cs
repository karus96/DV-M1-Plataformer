using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Template
{
    public abstract class SingletonControllerTemplate<T> : MonoBehaviour where T : Component
    {
        [Tooltip("The object must persist between scenes?")]
        [SerializeField]
        private bool _persistent;

        //========================================================================================
        // Variables
        //========================================================================================
        [Tooltip("Single instance of the object.")]
        public static T CurrentInstance { get; private set; }

        //========================================================================================
        // Methods of the Unity 
        //========================================================================================
        protected virtual void Awake()
        {
            if (CurrentInstance == null) CurrentInstance = this as T;
            else if (CurrentInstance != this) DestroyImmediate(this);
            if (_persistent) DontDestroyOnLoad(gameObject);
        }
        //========================================================================================
    }
}
