namespace MyStuff11net
{
    static class DictionaryExtension
    {
        public static Dictionary<K, T> OrderByKey<K, T>(this Dictionary<K, T> dicionario)
        {
            return dicionario.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);
        }

        public static Dictionary<K, T> OrderByValue<K, T>(this Dictionary<K, T> dicionario)
        {
            return dicionario.OrderBy(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
        }

        public static Dictionary<K, T> OrderByKeyDescending<K, T>(this Dictionary<K, T> dicionario)
        {
            return dicionario.OrderByDescending(p => p.Key).ToDictionary(p => p.Key, p => p.Value);
        }

        public static Dictionary<K, T> OrderByValueDescending<K, T>(this Dictionary<K, T> dicionario)
        {
            return dicionario.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
        }
    }

    class DictUses
    {
        void ForLoopDict()
        {
            Dictionary<string, int> keywordCounts = new Dictionary<string, int>();

            foreach (KeyValuePair<string, int> pair in keywordCounts.OrderBy(key => key.Value))
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }

            foreach (KeyValuePair<string, int> item in keywordCounts.OrderByValueDescending())
            {
                // do something with item.Key and item.Value
            }
        }
    }
}
