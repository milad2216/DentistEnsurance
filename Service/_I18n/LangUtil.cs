using System;
using System.Resources;
using Service.I18n;

namespace Service._I18n
{
    public static class LangUtil
    {
        private static ResourceManager _resourceManager;

        public static void Init(string language)
        {
            if (language.ToLower() == "fa")
            {
                _resourceManager = fa.ResourceManager;
            }else if (language.ToLower() == "en")
            {
                _resourceManager = en.ResourceManager;
            }
            else
            {
                throw new Exception("no " + language);
            }
        }


        public static string Get(string key)
        {
            if (_resourceManager == null)
            {
                Init("fa");
            }
            string value = key;
            try
            {
                value = _resourceManager.GetString(key);
            }
            catch (Exception)
            {
                value = key;
            }
            return value;
        }
    }


}