### NurApi UWP sample using MVVM pattern

This folder contains simple UWP MVVM oriented sample for NurApi.

###### MVVM
Model-View-ViewModel is popular design pattern for UWP apps.

This sample MVVM part is based on Diederik Krols great article [HERE](https://xamlbrewer.wordpress.com/2017/02/06/building-splitview-navigation-in-uwp/)

### Requirements
- Windows 10 machine
- Visual Studio 2017 with UWP support
- At least Windows 10 SDK Build 15063

### NurApi for UWP
NurApi UWP is basically same as other C# targets, except transport layers are different.

Documentation: [NurApi UWP Documentation.chm](https://github.com/NordicID/nur_sdk/blob/master/dotnet/docs/NurApi%20UWP%20Documentation.chm)

###### UWP async programming
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

### Sample content
- Connection handling to multiple readers at same time.
- Basic tag inventory functionality.
- Basic accessory device (EXA series) operations.

### Code location
- Finding devices: see `NurDeviceWatcher` usage in [ConnPageViewModel.cs](ViewModels/ConnPageViewModel.cs)
- Connecting devices: see `ConnectCommand` function in [ConnPageViewModel.cs](ViewModels/ConnPageViewModel.cs)
- Tag inventory: see file [InventoryPageViewModel.cs](ViewModels/InventoryPageViewModel.cs)
- Accessory device (EXA series) usage: see file [AccessoryDevPageViewModel.cs](ViewModels/AccessoryDevPageViewModel.cs)
- XAML Views: see [Views](Views) folder
