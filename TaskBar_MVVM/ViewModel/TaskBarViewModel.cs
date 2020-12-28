using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Taskbar_Mvvm
{
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
}
