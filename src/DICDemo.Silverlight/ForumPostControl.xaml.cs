using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace DICDemo.Silverlight
{
    /// <summary>
    /// Interaction logic for ForumPostControl.xaml
    /// </summary>
    public partial class ForumPostControl : UserControl
    {
        string _url;

        public ForumPostControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty ThreadTitleTextProperty = DependencyProperty.Register("ThreadTitle", typeof(string), typeof(ForumPostControl), new PropertyMetadata(""));
        public string ThreadTitle
        {
            get { return (string)GetValue(ThreadTitleTextProperty); }
            set { SetValue(ThreadTitleTextProperty, value); }
        }

        public static DependencyProperty ThreadDescriptionTextProperty = DependencyProperty.Register("ThreadDescription", typeof(string), typeof(ForumPostControl), new PropertyMetadata(""));
        public string ThreadDescription
        {
            get { return (string)GetValue(ThreadDescriptionTextProperty); }
            set { SetValue(ThreadDescriptionTextProperty, value); }
        }

        public static DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(string), typeof(ForumPostControl), new PropertyMetadata(""));
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static DependencyProperty UserURLProperty = DependencyProperty.Register("UserURL", typeof(string), typeof(ForumPostControl), new PropertyMetadata(""));
        /// <summary>
        /// Must set UserName property before setting URL
        /// </summary>
        public string UserURL
        {
            get { return (string)GetValue(URLProperty); }
            set
            {
                string xaml = string.Format("<HyperlinkButton Content=\"{0}\" NavigateUri=\"{1}\" TargetName=\"_blank\" />", UserName, value);
                rtbCreatedUser.Xaml = xaml;

                //FlowDocument fd = new FlowDocument();
                //fd.FontSize = 11;
                //Paragraph para = new Paragraph();

                //Run r = new Run(UserName);
                //Hyperlink hyperLink = new Hyperlink(r);
                //hyperLink.Foreground = Brushes.Black;
                //hyperLink.NavigateUri = new Uri(value);
                //hyperLink.RequestNavigate += delegate(object s, RequestNavigateEventArgs e)
                //{
                //    Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                //};

                //para.Inlines.Add(hyperLink);

                //fd.Blocks.Add(para);

                //rtbCreatedUser.Document = fd;
            }
        }

        public static DependencyProperty URLProperty = DependencyProperty.Register("ThreadURL", typeof(string), typeof(ForumPostControl), new PropertyMetadata(""));
        public string ThreadURL
        {
            get { return (string)GetValue(URLProperty); }
            set 
            {
                string xaml = string.Format("<HyperlinkButton Content=\"{0}\" NavigateUri=\"{1}\" TargetName=\"_blank\" />", ThreadTitle, value);
                rtbThreadTitle.Xaml = xaml;

                //FlowDocument fd = new FlowDocument();
                //fd.FontSize = 11;
                //Paragraph para = new Paragraph();

                //Run r = new Run(ThreadTitle);
                //Hyperlink hyperLink = new Hyperlink(r);
                //hyperLink.Foreground = Brushes.Black;
                //hyperLink.NavigateUri = new Uri(value);
                //hyperLink.RequestNavigate += delegate(object s, RequestNavigateEventArgs e)
                //{
                //    Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                //};

                //para.Inlines.Add(hyperLink);

                //fd.Blocks.Add(para);

                //rtbThreadTitle.Document = fd;
            }
        }
    }
}
