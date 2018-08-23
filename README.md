# Ci.Mvc.Alert
A quick way to show alert mseeage for aspnet mvc

![Ci.Mvc.Alert](https://i.imgur.com/pbpcl26.png)

## Notice
This library require Bootbox.js(http://bootboxjs.com/#) to run, you can use nuget install or just put it in scripts folder and reference it.

## Usage
First install package via nuget
```
Install-Package Ci.Mvc.Alert
```

then at controller action set alert message
```csharp
this.SetAlert("Ci.Mvc.Alert Demo");
```

**this** means Controller

OR

it use Controller to extened method, so you also can get controller instance to use this method

```csharp
var controller = ViewContext.Controller;
controller.SetAlert("Ci.Mvc.Alert Demo");
```

To show the message at view, at view add following code
<br>
**ASP.NET**
```csharp
@Html.ShowAlert()
```

**ASP.NET Core**

Startup.cs add service
```csharp
services.AddScoped<ITagHelperComponent, CiMvcAlertTagHelper>();
```

```html
<cimvcalert></cimvcalert>
```

note: be aware javascript sqeuence(bootbox), must put after bootbox.js

then it's all set.
