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
using System.Net;
using System.Xml.Linq;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace DICDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();

        public MainWindow()
        {
            dic.Add("ASP.Net", 30);
            dic.Add("C#", 84);
            dic.Add("VB.Net", 67);
            
            InitializeComponent();
        }

        private void cboForums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = cboForums.SelectedItem as ComboBoxItem;

            if (dic.ContainsKey(item.Content.ToString()))
            {
                int forumID = dic[item.Content.ToString()];
                GetForumData(forumID);
            }
        }

        private void GetForumData(int forumID)
        {
            List<ForumThread> forumThreads = null;

            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += delegate(object s, DoWorkEventArgs e)
            {
                XDocument doc = XDocument.Load(string.Format("http://www.dreamincode.net/forums/xml.php?showforum={0}", forumID));

                var query = from c in doc.Root.Descendants("topic")
                            select new ForumThread
                            {
                                ID = (!string.IsNullOrWhiteSpace(c.Element("id").Value)) ? Int64.Parse(c.Element("id").Value) : 0,
                                Icon = c.Element("icon").Value.Trim(),
                                Title = c.Element("title").Value.Trim(),
                                Description = c.Element("description").Value.Trim(),
                                URL = c.Element("url").Value.Trim(),
                                Replies = (!string.IsNullOrWhiteSpace(c.Element("replies").Value)) ? int.Parse(c.Element("replies").Value.Replace(",", "")) : 0,
                                Views = int.Parse(c.Element("views").Value.Replace(",", "")),
                                CreatedUser = new User(c.Element("user")),
                                LastPost = new LastThreadPost(c.Element("lastpost"))
                            };

                forumThreads = query.ToList();
            };

            bg.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e)
            {
                foreach (var thread in forumThreads)
                {
                    if (thread.Replies == 0 && thread.Icon != "t_closed")
                    {
                        ForumPostControl control = new ForumPostControl();
                        control.ThreadTitle = thread.Title;
                        control.ThreadDescription = thread.Description;
                        control.UserName = thread.CreatedUser.Name;
                        control.UserURL = string.Format("http://www.dreamincode.net/forums/user/{0}-{1}/", thread.CreatedUser.ID, thread.CreatedUser.Name);
                        control.ThreadURL = string.Format("http://www.dreamincode.net/forums/showtopic{0}.htm", thread.ID);

                        stpThreads.Children.Add(control);
                    }
                }

                StopProgressBar();
            };

            StartProgressBar();

            bg.RunWorkerAsync();
        }

        private void StartProgressBar()
        {
            //MediaElement element = new MediaElement();
            //element.Source = new Uri(@"C:\Users\ralford\Documents\Visual Studio 2010\Projects\DICDemo\DICDemo\3 Doors Down - Be Like That.mp3", UriKind.Absolute);
            //element.Height = 20;
            //element.Width = 20;

            //MediaTimeline timeline = new MediaTimeline();
            //timeline.BeginTime = TimeSpan.FromMilliseconds(5000);
            //timeline.Duration = new Duration(TimeSpan.FromMilliseconds(15000));
            //timeline.Source = element.Source;

            //element.Clock = timeline.CreateClock(true) as MediaClock;
            //element.LoadedBehavior = MediaState.Manual;
            //element.UnloadedBehavior = MediaState.Manual;

            //element.Loaded += delegate(object s, RoutedEventArgs e)
            //{
            //    element.Play();
            //};

            //element.Unloaded += delegate(object s, RoutedEventArgs e)
            //{
            //    element.Stop();
            //};

            //stpThreads.Children.Add(element);
            pbProgress.Image = System.Drawing.Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\progress.gif");
            pbProgress.Visible = true;
        }

        void element_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void StopProgressBar()
        {
            pbProgress.Visible = false;
        }
    }
}
