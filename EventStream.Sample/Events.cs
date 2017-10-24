










using System.Collections.Generic;
using System.Linq;
using System;
using EventStreaming;

namespace BB
{
    public class AmbientContext : IAmbientContext
    {
        private readonly Dictionary<string, object> _dynamicValues = new Dictionary<string, object>(9);
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

        public void SetPlatformType(string platformType)
        {
            _dynamicValues["platform_type"] = platformType;
        }

        public void ClearPlatformType()
        {
            _dynamicValues.Remove("platform_type"); 
        }

        public void SetSessionId(string sessionId)
        {
            _dynamicValues["session_id"] = sessionId;
        }

        public void ClearSessionId()
        {
            _dynamicValues.Remove("session_id"); 
        }

        public void SetUserSnId(string userSnId)
        {
            _dynamicValues["user_sn_id"] = userSnId;
        }

        public void ClearUserSnId()
        {
            _dynamicValues.Remove("user_sn_id"); 
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

        public void SetTransactionFunnel(string transactionFunnel)
        {
            _dynamicValues["transaction_funnel"] = transactionFunnel;
        }

        public void ClearTransactionFunnel()
        {
            _dynamicValues.Remove("transaction_funnel"); 
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

        public static Event LOGGED_IN()
        {
            var e = new Event("LOGGED_IN",
			new KeyValuePair<string, object>[]
            {

            });
            return e;
		}

        public static Event PURCHASE()
        {
            var e = new Event("PURCHASE",
			new KeyValuePair<string, object>[]
            {

            });
            return e;
		}

    }
}