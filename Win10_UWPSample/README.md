### NurApi for UWP
Basically same as for other C# targets, except transport layers are different.

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
    // Call NurApi synchronous funtion here
  } catch (Exception e) {
    // Handle error here
  }
});
```
