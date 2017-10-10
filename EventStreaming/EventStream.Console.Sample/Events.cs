











using System.Collections.Generic;
using EventStreaming;
using System;

namespace EventStream.Console.Sample
{
    public class AmbientContext : IAmbientContext
    {
        private readonly Dictionary<string, object> _dynamicValues = new Dictionary<string, object>();

		public IEnumerable<KeyValuePair<string, object>> GetAmbientData()
		{
		    return _dynamicValues;
		}

        public void SetFacility(string facility)
        {
            _dynamicValues["facility"] = facility; 
        }
        
        public void ClearFacility()
        {
            _dynamicValues.Remove("facility"); 
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

        public void SetClientTimestamp(long clientTimestamp)
        {
            _dynamicValues["client_timestamp"] = clientTimestamp; 
        }
        
        public void ClearClientTimestamp()
        {
            _dynamicValues.Remove("client_timestamp"); 
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

    }

    public static partial class GeneratedEvents
    {

        public static Event LOGGED_IN(string machineId, string spinsSelected)
        {
            var e = new Event("LOGGED_IN",
			new[]
            {

                new KeyValuePair<string, object>("machine_id", machineId),

                new KeyValuePair<string, object>("spins_selected", spinsSelected),


                new KeyValuePair<string, object>("event_type", "LOGGED_IN"),

                new KeyValuePair<string, object>("event_sub_group", "AUTH"),

                new KeyValuePair<string, object>("event_group", "CLIENT_INSTRUMENTATION"),

            });

            return e;
        }
    }
}