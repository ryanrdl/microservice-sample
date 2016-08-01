using System;

namespace SharedKernel
{
    using System.Configuration; 

    public class Env
    {
        public static string Get(string key, string defaultValue = null, bool throwExceptionIfNotFound = true)
        {
            string value = GetFromUserEnv(key) ?? GetFromMachineEnv(key) ?? GetFromAppSettings(key);

            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(defaultValue))
            {
                value = defaultValue;
                Console.WriteLine($"Env.Get {key} = {value} from provided default value");
            }

            if (throwExceptionIfNotFound && string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(key), $"no value found for {key}"); 

            return value;
        }

        private static string GetFromUserEnv(string key)
        {
            string value = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);

            if (!string.IsNullOrWhiteSpace(value))
                Console.WriteLine($"Env.Get {key} = {value} from User Environmental Variables");

            return value;
        }

        private static string GetFromMachineEnv(string key)
        {
            string value = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Machine);

            if (!string.IsNullOrWhiteSpace(value))
                Console.WriteLine($"Env.Get {key} = {value} from Machine Environmental Variables");

            return value;
        }

        private static string GetFromAppSettings(string key)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(value))
                Console.WriteLine($"Env.Get {key} = {value} from App Settings");

            return value;
        }
    }
}
