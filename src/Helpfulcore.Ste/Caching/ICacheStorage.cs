using System.Collections.Concurrent;

namespace Helpfulcore.Ste.Caching
{
	internal interface ICacheStorage
    {
        ConcurrentDictionary<string, SitecoreMemoryCacheEntry> Entries { get; }
        void Clear();
    }
}
