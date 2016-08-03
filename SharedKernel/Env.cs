using System;

namespace SharedKernel
{
    using System.Collections;
    using System.Configuration; 

    public class Env
    {
        private static readonly Lazy<IDictionary> _envVariables = new Lazy<IDictionary>(Environment.GetEnvironmentVariables); 

        public static string Get(string key, string defaultValue = null, bool throwExceptionIfNotFound = true)
        {
            foreach (DictionaryEntry env in _envVariables.Value)
            {
                if (key.Equals(env.Key))
                { 
                    return (string) env.Value;
                }
            }

            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }  
    }
}
