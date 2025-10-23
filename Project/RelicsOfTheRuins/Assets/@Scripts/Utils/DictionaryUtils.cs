using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class DictionaryUtils
    {
        public static bool IsEmpty<TKey, TVal>(this Dictionary<TKey,TVal> dict)
        {
            return dict.Count <= 0;
        }
    }
}