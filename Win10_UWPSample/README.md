### NurApi for UWP
NurApi UWP is basically same as in other C# targets, except transport layers are different.

Documentation: [NurApi UWP Documentation.chm](https://github.com/NordicID/nur_sdk/blob/master/dotnet/docs/NurApi%20UWP%20Documentation.chm)

#### Requirements
- Windows 10 machine
- Visual Studio 2017 with UWP support
- At least Windows 10 SDK Build 15063

#### UWP async programming
Normally in UWP apps in order to keep your app responsive, async APIs are used.
However, most of the NurApi method are synchronous, thus it is recommended to wrap them inside Task:
```
await Task.Run(async () => {
  try {
    // Call NurApi synchronous function here
  } catch (Exception e) {
    // Handle error here
  }
});
```

#### Transport layer
Transport layers are different in NurApi UWP. Connection is made based on device connection spec.

Device connection spec is string containing key/value pairs, separated by semicolon. 
- TCP example: "type=TCP;addr=address:port", where address can be hostname or ip address.
- BLE example: "type=BLE;addr=XX:XX:XX:XX:XX:XX", where address is BT MAC address
- USB example: "type=USB;addr=deviceid", where address is usually obtained via NurDeviceWatcher
- Serial example: "type="SER;addr=COM5", where address is COMx or deviceid obtained via NurDeviceWatcher

You can use NurDeviceWatcher to find all type of attached/nearby devices, such as BLE, TCP (mdns), USB, Serial.

Manual connect example:
```
// At minimum, type and addr keys are needed always.
await mApi.ConnectAsync("type=TCP;addr=192.168.1.4:4333");
```
