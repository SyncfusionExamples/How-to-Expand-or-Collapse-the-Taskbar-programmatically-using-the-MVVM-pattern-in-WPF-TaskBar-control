# How-to-Expand-or-Collapse-the-Taskbar-programmatically-using-the-MVVM-pattern-in-WPF-TaskBar-control
This repository contains the sample that how to expand or collapse the Taskbar programmatically using the MVVM pattern in WPF TaskBar control.
The Taskbar  can be expand or collapse by populating the items through ViewModel by using IsOpened property of TaskBar . Different content for each TaskBarItem, can be set by using the ContentTemplateSelector property of ContentPresenter .

```XAML
<Window.Resources>
<DataTemplate x:Key="DefaultTemplate">
<StackPanel>
<TextBlock Text="Default content" />
</StackPanel>
</DataTemplate>
<DataTemplate x:Key="NormalTemplate">
<Grid>
<Grid.ColumnDefinitions>
<ColumnDefinition/>
<ColumnDefinition/>
</Grid.ColumnDefinitions>
<StackPanel Margin="5">
<TextBlock Margin="2" Text="{Binding Name}" />
<TextBlock Margin="2" Text="{Binding DateOfBirth}" />
<TextBlock Margin="2" Text="{Binding Geneder}" />
<TextBlock Margin="2" Text="{Binding DateOfJoining}"/>
</StackPanel>
<StackPanel Grid.Column="1" Margin="5">
<TextBlock
Margin="2"
HorizontalAlignment="Center"
VerticalAlignment="Center">
Employee Photo
</TextBlock>
<Image
Margin="2"
Height="100"
VerticalAlignment="Top"
Source="{Binding ImageSource}" />
</StackPanel>
</Grid>
</DataTemplate>
<local:PremiumUserDataTemplateSelector
x:Key="TaskBarContentTemplateSelector"
DefaultTemplate="{StaticResource DefaultTemplate}"
NormalTemplate="{StaticResource NormalTemplate}" />
</Window.Resources>


<Grid>
<syncfusion:TaskBar
Name="taskBar"
Width="500"
Height="300"
Margin="0,10,0,0"
VerticalAlignment="Top"
ScrollViewer.HorizontalScrollBarVisibility="Auto"
ItemsSource="{Binding TaskBarItems}">
<syncfusion:TaskBar.ItemContainerStyle>
<Style TargetType="{x:Type syncfusion:TaskBarItem}">
<Setter Property="Header" Value="{Binding Header}" />
<Setter Property="syncfusion:TaskBar.IsOpened" Value="{Binding IsOpened}" />
<Setter Property="ItemsSource" Value="{Binding TaskbarContentItems}" />
<Setter Property="ItemContainerStyle">
<!--ContentTemplateSelector used to set different content for each TaskBarItem-->
<Setter.Value>
<Style TargetType="ContentPresenter">
<Setter Property="ContentTemplateSelector" Value="{StaticResource TaskBarContentTemplateSelector}" />
</Style>
</Setter.Value>
</Setter>
</Style>
</syncfusion:TaskBar.ItemContainerStyle>
</syncfusion:TaskBar>
</Grid>
```

```C#

public class PremiumUserDataTemplateSelector : DataTemplateSelector
{
public DataTemplate DefaultTemplate { get; set; }
public DataTemplate NormalTemplate { get; set; }
public override DataTemplate SelectTemplate(object item, DependencyObject container)
{
FrameworkElement elemnt = container as FrameworkElement;
// Set the different content for taskbaritem according your desire
if ((item as Contentmodel).Name == "Content1")
{
return elemnt.FindResource("DefaultTemplate") as DataTemplate;
}

return elemnt.FindResource("NormalTemplate") as DataTemplate;
}
}
```

ViewModel
```
public class TaskBarViewModel : NotificationObject
{

private ObservableCollection<TaskBarModel> taskbarItems;
public ObservableCollection<TaskBarModel> TaskBarItems
{
get { return taskbarItems; }
set
{
taskbarItems = value;
this.RaisePropertyChanged(nameof(TaskBarItems));
}
}
public TaskBarViewModel()
{
taskbarItems = new ObservableCollection<TaskBarModel>();
PopulateCollection();
}

public void PopulateCollection()
{
//Adding the tileview items into the collection
List<Contentmodel> ContentItem1 = new List<Contentmodel>();


ContentItem1.Add(new Contentmodel() { Name = "Name : Alicia Mendez", DateOfBirth = "Date Of Birth : 06-03-1981", Geneder = "Gender : Female", DateOfJoining = "Date Of Joining : 06-03-2003" ,ImageSource= "/Taskbar_Mvvm;component/Assets/People/People_Circle0.png" });

TaskBarItems.Add(new TaskBarModel() { Header = "Employee1 Personal Details", TaskbarContentItems = ContentItem1, IsOpened = false });

List<Contentmodel> ContentItem2 = new List<Contentmodel>();

ContentItem2.Add(new Contentmodel() { Name = "Name : Danial William", DateOfBirth = "Date Of Birth : 04-03-1982", Geneder = "Gender : Male", DateOfJoining = "Date Of Joining : 09-03-2004", ImageSource = "/Taskbar_Mvvm;component/Assets/People/People_Circle2.png" });
TaskBarItems.Add(new TaskBarModel() { Header = "Employee2 Personal Details", TaskbarContentItems = ContentItem2, IsOpened = false });

List<Contentmodel> ContentItem3 = new List<Contentmodel>();

ContentItem3.Add(new Contentmodel() { Name = "Name : Kinsley Elena", DateOfBirth = "Date Of Birth :08-09-1983", Geneder = "Gender : Female", DateOfJoining = "Date Of Joining : 09-03-2005", ImageSource = "/Taskbar_Mvvm;component/Assets/People/People_Circle1.png" });
TaskBarItems.Add(new TaskBarModel() { Header = "Employee3 Personal Details", TaskbarContentItems = ContentItem3, IsOpened = true });

}
}
```

Model
```
TaskBarModel cs file

public class TaskBarModel : NotificationObject
    {
        public string Header { get; set; }


        public TaskBarModel()
        {
            taskbarContentItems = new List<Contentmodel>();

        }

       private bool isOpen;

        public bool IsOpened
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                this.RaisePropertyChanged(nameof (IsOpened));
            }
        }
           
      
        private int invokeParameter = 1;

        public int InvokeParameter
        {
            get { return invokeParameter; }
            set { invokeParameter = value; RaisePropertyChanged("InvokeParameter"); }
        }

        private List<Contentmodel> taskbarContentItems;

        public List<Contentmodel> TaskbarContentItems
        {
            get { return taskbarContentItems; }
            set
            {
                taskbarContentItems = value;
                this.RaisePropertyChanged(nameof(TaskbarContentItems));
            }
        }
    }

Contentmodel cs file

    public class Contentmodel
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set { name = value; }
        }

        private string dateOfBirth;
        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set { dateOfBirth = value; }
        }


        private string gender;
        public string Geneder
        {
            get
            {
                return gender;
            }
            set { gender = value; }
        }

        private string position;
        public string Position
        {
            get
            {
                return position;
            }
            set { position = value; }
        }

        private string dateOfJoining;
        public string DateOfJoining
        {
            get
            {
                return dateOfJoining;
            }
            set { dateOfJoining = value; }
        }


        private string imageSource;
        public string ImageSource
        {
            get
            {
                return imageSource;
            }
            set { imageSource = value; }
        }
    }
    
  ```
Output:
 


