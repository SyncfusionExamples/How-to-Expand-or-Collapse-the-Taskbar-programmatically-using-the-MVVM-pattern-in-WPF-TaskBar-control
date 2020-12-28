using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskbar_Mvvm
{
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
}
