using System;

namespace RTS.Utils
{
    public class InjectAssetAttribute : Attribute
    {
        public readonly string AssetName; 
        
        public InjectAssetAttribute(string assetName = null)
        {
            AssetName = assetName;
        }
    }
}