using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using System.Reflection;
using System.Windows.Interactivity;
using Syncfusion.Windows.Shared;
using Syncfusion.SfSkinManager;

namespace Taskbar_Mvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SfSkinManager.SetTheme(this, new Theme("Office2019Colorful"));
            InitializeComponent();

        }

    }
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
  
}
