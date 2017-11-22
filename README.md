# EventStream 
It is a C# client library that helps implementing application instrumentation. 
Basically it helps you sending structured events regarding what happens in your application to some server to analyze them later.

Basically library consists of 3 parts:

1. Config file format. JSON-based format, easily edited by guys from BI (Business Intelligence) team.
2. .NET library that helps with composing events
3. Codegen tool to generate code in C# to provide you some necessary boilerplate

To start using the library you should:
1. Compose your config with events you'd like to send. Here is an example relevant for a mobile application
```
    "ambient_context": {
        "user_id": "#string",
        "session_id": "#string",
        "login_mode": "#string",
        "app_version": "#string",
        "os_name": "#string",
        "os_version": "#string",
        "timestamp": "$long",
    },
    "groups": [
        {
            "percent": 30,
            "fields": {
                "event_group": "CLIENT_INSTRUMENTATION",
                "user_id": "@user_id",
                "session_id": "@session_id",
                "login_mode": "@login_mode",
                "app_version": "@app_version",
                "os_name": "@os_name",
                "os_version": "@os_version"
            },
            "groups": [
                {
                    "fields": {
                        "event_sub_group": "AUTH"
                    },
                    "events": [
                        {
                            "id": "LOGGED_IN",
                            "fields": {
                                "event_type": "LOGGED_IN",
                                "login_type": "$string"
                            }
                        }
                    ]
                }
            ]
        }
    ]
}

```

2. Invoke `EventStream.Codegen.exe -i path_to_config.json -o GeneratedEvents.cs -c GeneratedEvents -n MyAppNamespace`

3. Add generated .cs file to your project

4. Add similar code to app startup logic
```
var config = new ConfigParser(File.OpenRead("config.json")).ReadFullConfig();
var context = new AmbientContext();
var eventStreaming = new EventStreaming.EventStream(
    context,
    new BufferingEventDispatcher(new ConsoleEventSender()),
    new EventStreamSettings(),
    config);

context.SetAppVersion("1.01");
context.SetOsName("Windows");
context.SetUserId("123"); // This code can be added later
context.SetSessionId("1234"); // This code can be added later
context.SetTimestampFunc(() => DateTime.Now.Millisecond);
```

5. And finally `eventStreaming.SendAsync(GeneratedEvents.LOGGED_IN("Facebook"));`
