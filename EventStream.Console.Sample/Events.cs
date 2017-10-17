











using System.Collections.Generic;
using System.Linq;
using System;
using EventStreaming;

namespace EventStream.Console.Sample
{
    public class AmbientContext : IAmbientContext
    {
        private readonly Dictionary<string, object> _dynamicValues = new Dictionary<string, object>();
        private readonly Dictionary<string, Func<object>> _evaluatedValues = new Dictionary<string, Func<object>>();

		public IEnumerable<KeyValuePair<string, object>> GetAmbientData()
		{
		    return Enumerable.Union(
		        _dynamicValues,
		        _evaluatedValues.Select(kv => new KeyValuePair<string, object>(kv.Key, kv.Value()))
		        );
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


        public void SetTimestampFunc(Func<string> timestamp)
        {
            _evaluatedValues["timestamp"] = timestamp;
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
			new[]
            {


                new KeyValuePair<string, object>("event_type", "LOGGED_IN"),

                new KeyValuePair<string, object>("event_sub_group", "AUTH"),

                new KeyValuePair<string, object>("event_group", "BBNC_CLIENT_INSTRUMENTATION"),

            });

            return e;
        }
    }
}