# Ci.Mvc.Alert
[![Build Status](https://dev.azure.com/lettucebo/Github.Build/_apis/build/status/Ci.Mvc.Alert/Ci.Mvc.Alert.Build?branchName=master)](https://dev.azure.com/lettucebo/Github.Build/_build/latest?definitionId=28&branchName=master)

##### A quick way to show alert mseeage for aspnet mvc and aspnetcore mvc

![Ci.Mvc.Alert](https://i.imgur.com/8XqqtLy.png)

## Notice
This library require Bootbox.js(http://bootboxjs.com/#) to run, you can use nuget, libman to install or just put it in scripts folder and reference it.

If there is no bootbox.js browser console will show error msg as below:

![](https://i.imgur.com/FYO97e9.png)

## Intro
At controller's action set alert message
```csharp
// no title dialog
this.SetAlert("A quick way to show alert mseeage for aspnet mvc and aspnetcore mvc");

// has title dialog
this.SetAlert("A quick way to show alert mseeage for aspnet mvc and aspnetcore mvc", "CiMvcAlert");
```

**Result**

![](https://i.imgur.com/5adKudN.png)

![Ci.Mvc.Alert](https://i.imgur.com/8XqqtLy.png)

## Usage

### Install Package

use nuget to install package: [Ci.Mvc.Alert](https://www.nuget.org/packages/Ci.Mvc.Alert/)

```base
Package Explorer: Install-Package Ci.Mvc.Alert
DotNet CLI: dotnet add package Ci.Mvc.Alert
```

then at controller action set alert message

```csharp
// no title dialog
this.SetAlert("A quick way to show alert mseeage for aspnet mvc and aspnetcore mvc");

// has title dialog
this.SetAlert("A quick way to show alert mseeage for aspnet mvc and aspnetcore mvc", "CiMvcAlert");
```

**this** means Controller

It use Controller to extened method, so you also can get controller instance to use this method

```csharp
var controller = ViewContext.Controller;
controller.SetAlert("A quick way to show alert mseeage for aspnet mvc and aspnetcore mvc");
```

To show the message at view, at view add following code

### ASP.NET

html
```csharp
@using Ci.Mvc.Alert
...
@Html.ShowAlert()
```

### ASP.NET Core

At _ViewImports.cshtml add TagHelper
```c#
@addTagHelper *, Ci.Mvc.Alert.NetCore
```

then add `cimvcalert` tag at razor page(cshtml)
```html
<cimvcalert></cimvcalert>
```

### Example

ASP.NET MVC:
<br/>
[Ci.Mvc.Alert.Net.Example](https://github.com/lettucebo/Ci.Mvc.Alert/tree/master/Ci.Mvc.Alert.Net.Example): [_Layout.cshtml](https://github.com/lettucebo/Ci.Mvc.Alert/blob/master/Ci.Mvc.Alert.Net.Example/Views/Shared/_Layout.cshtml)

ASP.NET Core MVC:
<br/>
[Ci.Mvc.Alert.NetCore.Example](https://github.com/lettucebo/Ci.Mvc.Alert/tree/master/Ci.Mvc.Alert.NetCore.Example): [_ViewImports.cshtml](https://github.com/lettucebo/Ci.Mvc.Alert/blob/master/Ci.Mvc.Alert.NetCore.Example/Views/_ViewImports.cshtml), [_Layout.cshtml](https://github.com/lettucebo/Ci.Mvc.Alert/blob/master/Ci.Mvc.Alert.NetCore.Example/Views/Shared/_Layout.cshtml)

### Note

Be aware JavaScript sequence, `<cimvcalert></cimvcalert>` must put after bootbox.js
