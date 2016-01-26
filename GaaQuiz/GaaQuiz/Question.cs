using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GaaQuiz
{
    public class Question
    {
        public String text { get; set; }
        public ImageSource image { get; set; }
        public String a { get; set; }
        public String b { get; set; }
        public String c { get; set; }
        public String answer { get; set; }
    }
}
