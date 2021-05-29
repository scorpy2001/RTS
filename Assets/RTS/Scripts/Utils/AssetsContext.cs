using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RTS.Utils
{
    [CreateAssetMenu(fileName = nameof(AssetsContext), menuName = "Strategy Game/" + nameof(AssetsContext), order = 0)]
    public class AssetsContext : ScriptableObject
    {
        [SerializeField] private Object[] _objects;
        
        public Object GetObjectOfType(Type targetType, string targetName = null)
        {
            return _objects.FirstOrDefault(_ => _.GetType().IsAssignableFrom(targetType) && (targetName == null || _.name == targetName));
        }
    }
}
