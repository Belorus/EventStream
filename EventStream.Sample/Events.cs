using System.Collections.Generic;
using System.Linq;
using System;
using EventStream;
using EventStream.Abstractions;

namespace EventStream.Console.Sample
{
    public class AmbientContext : IAmbientContext
    {
        private readonly Dictionary<string, object> _dynamicValues = new Dictionary<string, object>(6);
        private readonly Dictionary<string, Func<object>> _evaluatedValues = new Dictionary<string, Func<object>>(1);

        public int UserSeed { get; set; }

        public object GetValue(string key)
        {
            if (_dynamicValues.TryGetValue(key, out var value))
            {
                return value;
            }
            else
            {
                if (_evaluatedValues.TryGetValue(key, out var func))
                {
                    return func();
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetUserId(string userId)
        {
            _dynamicValues["user_id"] = userId;
        }

        public void ClearUserId()
        {
            _dynamicValues.Remove("user_id");
        }

        public void SetSessionId(string sessionId)
        {
            _dynamicValues["session_id"] = sessionId;
        }

        public void ClearSessionId()
        {
            _dynamicValues.Remove("session_id");
        }

        public void SetLoginMode(string loginMode)
        {
            _dynamicValues["login_mode"] = loginMode;
        }

        public void ClearLoginMode()
        {
            _dynamicValues.Remove("login_mode");
        }

        public void SetAppVersion(string appVersion)
        {
            _dynamicValues["app_version"] = appVersion;
        }

        public void ClearAppVersion()
        {
            _dynamicValues.Remove("app_version");
        }

        public void SetOsName(string osName)
        {
            _dynamicValues["os_name"] = osName;
        }

        public void ClearOsName()
        {
            _dynamicValues.Remove("os_name");
        }

        public void SetOsVersion(string osVersion)
        {
            _dynamicValues["os_version"] = osVersion;
        }

        public void ClearOsVersion()
        {
            _dynamicValues.Remove("os_version");
        }

        public void SetTimestampFunc(Func<long> timestamp)
        {
            _evaluatedValues["timestamp"] = () => timestamp();
        }

        public void ClearTimestampFunc()
        {
            _evaluatedValues.Remove("timestamp");
        }
    }

    public static partial class Events
    {
        private static readonly KeyValuePair<string, object>[] EmptyArray = new KeyValuePair<string, object>[0];

        public static Event LOGGED_IN()
        { 
            return new Event("LOGGED_IN", EmptyArray);
        } 

    }
}