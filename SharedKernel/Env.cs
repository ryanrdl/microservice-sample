using System;

namespace SharedKernel
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;

    public class Env
    {
        private static readonly Lazy<IDictionary> _envVariables =
            new Lazy<IDictionary>(Environment.GetEnvironmentVariables);

        public static string Get(string key, string defaultValue = null, bool throwExceptionIfNotFound = true)
        {
            foreach (var env in All())
            {
                if (key.Equals(env.Key))
                {
                    return env.Value;
                }
            }

            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        public static IDictionary<string, string> All()
        {
            IDictionary<string, string> result = new Dictionary<string, string>();
            foreach (DictionaryEntry env in _envVariables.Value)
            {
                result.Add(env.Key?.ToString(), env.Value?.ToString());
            }
            return result;
        }
    }
}