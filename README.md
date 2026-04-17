# Expand or Collapse the TaskBar Programmatically Using MVVM in WPF

This sample demonstrates how to **programmatically expand and collapse the Syncfusion WPF TaskBar control using the MVVM pattern**.

It shows how to manage the open/close state of `TaskBarItem` instances using data binding, without manipulating UI elements directly from code‑behind.

---

## Overview

The **Syncfusion WPF TaskBar** control is used to display expandable panels containing grouped content.  
In MVVM‑based applications, UI state (such as expanded or collapsed panels) is controlled through **bindable properties** in the ViewModel.

This sample illustrates:
- Binding TaskBar items to a ViewModel
- Expanding or collapsing TaskBar items programmatically
- Displaying custom content using DataTemplates
- Selecting templates dynamically using a DataTemplateSelector

---

## What This Sample Demonstrates

- Implementing TaskBar using the MVVM pattern
- Binding `IsOpened` property to expand or collapse items
- Populating TaskBar content dynamically
- Using `ItemTemplate` and `HeaderTemplate`
- Displaying different content layouts using a `DataTemplateSelector`

---

## Key MVVM Concept

The **expanded or collapsed state of a TaskBarItem** is controlled by the `IsOpened` property in the model:

```csharp
public bool IsOpened
{
    get { return isOpen; }
    set
    {
        isOpen = value;
        this.RaisePropertyChanged(nameof(IsOpened));
    }
}
```
## DataModels

### TaskBarModel
```Csharp
public class TaskBarModel : NotificationObject
{
    public string Header { get; set; }

    private bool isOpen;
    public bool IsOpened
    {
        get { return isOpen; }
        set
        {
            isOpen = value;
            RaisePropertyChanged(nameof(IsOpened));
        }
    }

    public List<Contentmodel> TaskbarContentItems { get; set; }

    public TaskBarModel()
    {
        TaskbarContentItems = new List<Contentmodel>();
    }
}
```

### ContentModel
```Csharp
public class Contentmodel
{
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public string Geneder { get; set; }
    public string Position { get; set; }
    public string DateOfJoining { get; set; }
    public string ImageSource { get; set; }
}
```

### ViewModel
The ViewModel exposes a collection of TaskBarModel items. Each item controls its own expanded or collapsed state through IsOpened.
```Csharp
public class TaskBarViewModel : NotificationObject
{
    public ObservableCollection<TaskBarModel> TaskBarItems { get; set; }

    public TaskBarViewModel()
    {
        TaskBarItems = new ObservableCollection<TaskBarModel>();
        PopulateCollection();
    }

    private void PopulateCollection()
    {
        TaskBarItems.Add(
            new TaskBarModel()
            {
                Header = "Employee1 Personal Details",
                IsOpened = false,
                TaskbarContentItems =
                {
                    new Contentmodel
                    {
                        Name = "Name : Alicia Mendez",
                        DateOfBirth = "Date Of Birth : 06-03-1981",
                        Geneder = "Gender : Female",
                        DateOfJoining = "Date Of Joining : 06-03-2003",
                        ImageSource = "/Assets/People/People_Circle0.png"
                    }
                }
            });

        TaskBarItems.Add(
            new TaskBarModel()
            {
                Header = "Employee3 Personal Details",
                IsOpened = true
            });
    }
}
```
---

## Key Benefits
- Clean, maintainable MVVM implementation
- No direct UI manipulation from code‑behind
- Easy integration into existing WPF applications
- Ideal for dashboards, navigation panels, and workflow‑driven UIs

This sample serves as a practical reference for developers looking to control the WPF TaskBar dynamically while adhering to MVVM best practices.
