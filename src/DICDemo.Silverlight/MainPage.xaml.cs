using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DICDemo.Silverlight
{
    public partial class MainPage : UserControl
    {

        public MainPage()
        {
            InitializeComponent();

            List<Forum> forumList = new List<Forum>();
            forumList.Add(new Forum("C#"));
            forumList.Add(new Forum("VB.Net"));
            forumList.Add(new Forum("ASP.Net"));

            lstForums.ItemsSource = forumList;
        }

        private void chkSelectForum_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void lstForums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = lstForums.SelectedItem as ListBoxItem;
            StackPanel stp = item.FindName("stpForumList") as StackPanel;

            if (stp == null)
                return;

            CheckBox cb = stp.FindName("chkSelectForum") as CheckBox;
            cb.IsChecked = true;
        }
    }

    public class Forum
    {
        public string ForumName { get; set; }

        public Forum(string name)
        {
            this.ForumName = name;
        }
    }
}
