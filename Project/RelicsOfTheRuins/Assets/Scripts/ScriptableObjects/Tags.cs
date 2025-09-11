using UnityEngine;


namespace RelicsOfTheRuins.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Tags", menuName = "ScriptableObjects/Tags", order = 4)]
    public class Tags : ScriptableObject
    {
        public string[] _explorerDataHubPublishableTag;
    }
}