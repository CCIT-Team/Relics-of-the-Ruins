

using System.Collections.Generic;

namespace Data
{
    public interface ILoader<TKey, TVal>
    {
        Dictionary<TKey, TVal> MakeDict();
    }
}