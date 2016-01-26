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
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Windows.Resources;
using Microsoft.Phone.Tasks;

namespace GaaQuiz
{
    public partial class Quiz : PhoneApplicationPage
    {


        private int correctedAnswers = 0;

        private int totalQuestions = 0;


        private List<Question> questions = new List<Question>();
        private Question currentQuestion = new Question();

        private SoundEffect correctSound, wrongSound;

        public Quiz()
        {
            InitializeComponent();

            FrameworkDispatcher.Update();

            this.LoadSound("Sounds/correct.wav", out correctSound);
            this.LoadSound("Sounds/wrong.wav", out wrongSound);


            this.initializeQuestions();
            this.startQuestions();
        }



        private List<E> ShuffleList<E>(List<E> inputList)
        {

            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); 
                randomList.Add(inputList[randomIndex]); 
                inputList.RemoveAt(randomIndex);
                
            }

            return randomList; 
        }


        private void LoadSound(String SoundFilePath, out SoundEffect Sound)
        {
            Sound = null;
            try
            {
                StreamResourceInfo SoundFileInfo = App.GetResourceStream(new Uri(SoundFilePath, UriKind.Relative));
                Sound = SoundEffect.FromStream(SoundFileInfo.Stream);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Couldn't load sound " + SoundFilePath);
            }
        }



        private void btnAAnswers_Click(object sender, RoutedEventArgs e)
        {
            this.compareAnswers(btnAAnswers.Content.ToString());
        }

        private void btnBAnswers_Click(object sender, RoutedEventArgs e)
        {
            this.compareAnswers(btnBAnswers.Content.ToString());
        }

        private void btnCAnswers_Click(object sender, RoutedEventArgs e)
        {
            this.compareAnswers(btnCAnswers.Content.ToString());
        }


        private void compareAnswers(String answer)
        {

            if (answer.Equals(currentQuestion.answer))
            {
                this.correctSound.Play();
                totalQuestions++;
                correctedAnswers++;

                txtCorrectQuestions.Text = "Correct: " + correctedAnswers + "/" + totalQuestions;


                // Configure message box 
                string message = "Correct Answer!";
                string caption = "";
                MessageBoxButton buttons = MessageBoxButton.OK;
                // Show message box
                MessageBoxResult result = MessageBox.Show(caption, message, buttons);

                this.nextQuestion();

            }
            else
            {
                this.wrongSound.Play();
                totalQuestions++;

                txtCorrectQuestions.Text = "Correct: " + correctedAnswers + "/" + totalQuestions;

                // Configure message box 
                string message = "Wrong Answer!";
                string caption = "";
                MessageBoxButton buttons = MessageBoxButton.OK;
                // Show message box
                MessageBoxResult result = MessageBox.Show(caption, message, buttons);

                this.nextQuestion();

            }


            if (totalQuestions > 14)
            {
                this.stopQuestions();
            }
        }





        private void nextQuestion()
        {
            questions = ShuffleList<Question>(questions);
            currentQuestion = questions.ElementAt<Question>(0);
            txtQuestion.Text = currentQuestion.text;
            btnAAnswers.Content = currentQuestion.a;
            btnBAnswers.Content = currentQuestion.b;
            btnCAnswers.Content = currentQuestion.c;

            questions.RemoveAt(0);
        }




        private void showGameFinished()
        {
            int totalScore = (correctedAnswers);

            // Configure message box 
            string message = "You finished with a score of " + correctedAnswers + "/15.";
            string caption = "Game Over";
            MessageBoxButton buttons = MessageBoxButton.OK;
            // Show message box
            MessageBoxResult result = MessageBox.Show(caption, message, buttons);

            NavigationService.Navigate(new Uri("/SelectCategory.xaml", UriKind.Relative));

        }



        private void stopQuestions()
        {

            btnAAnswers.IsEnabled = false;
            btnBAnswers.IsEnabled = false;
            btnCAnswers.IsEnabled = false;

            this.showGameFinished();

        }

        private void startQuestions()
        {

            this.nextQuestion();

        }

        private void initializeQuestions()
        {
            Question question = null;
            question = null;
            question = new Question();
            question.text = "Which club team has won the most All-Ireland Senior Club Championship titles?";
            question.a = "Crossmaglen Rangers";
            question.b = "Kilmacud Crokes";
            question.c = "Nemo Rangers";
            question.answer = "Nemo Rangers";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county has won the most All-Ireland Championship titles?";
            question.a = "Dublin";
            question.b = "Kerry";
            question.c = "Cork";
            question.answer = "Kerry";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county has the third most All-Ireland titles?";
            question.a = "Mayo";
            question.b = "Cork";
            question.c = "Galway";
            question.answer = "Galway";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "Which county won the 2012 All-Ireland Championship?";
            question.a = "Donegal";
            question.b = "Dublin";
            question.c = "Mayo";
            question.answer = "Donegal";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "Which Donegal player scored a goal within the first 4 minutes of the 2012 All-Ireland final?";
            question.a = "Michael Murphy";
            question.b = "Colm McFadden";
            question.c = "Karl Lacey";
            question.answer = "Michael Murphy";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "Which player was the highest scorer of the 2013 All-Ireland Championship?";
            question.a = "Martin Dunne";
            question.b = "Cillian O Connor";
            question.c = "Bernard Brogan";
            question.answer = "Cillian O Connor";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which team beat Kerry in the Polo Grounds, New York in 1947 to win the All-Ireland?";
            question.a = "Dublin";
            question.b = "Cork";
            question.c = "Cavan";
            question.answer = "Cavan";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these counties have never won an All-Ireland?";
            question.a = "Monaghan";
            question.b = "Louth";
            question.c = "Offaly";
            question.answer = "Monaghan";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these counties have never won an All-Ireland or provincial title?";
            question.a = "Tipperary";
            question.b = "Fermanagh";
            question.c = "Laois";
            question.answer = "Fermanagh";
            questions.Add(question);

            //template below (10)
            question = null;
            question = new Question();
            question.text = "Which team lost to Mayo in the 2013 Connacht Football Championship final?";
            question.a = "Roscommon";
            question.b = "Galway";
            question.c = "London";
            question.answer = "London";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which team beat Donegal in the 2013 Ulster Football Championship final?";
            question.a = "Tyrone";
            question.b = "Down";
            question.c = "Monaghan";
            question.answer = "Monaghan";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Where was the Gaa founded?";
            question.a = "Thurles";
            question.b = "Killarney";
            question.c = "Dublin";
            question.answer = "Thurles";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "What is Colm 'Gooch' Coopers best score in an All-Ireland Championship game?";
            question.a = "0-07";
            question.b = "2-3";
            question.c = "1-5";
            question.answer = "1-5";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "How many All-Irelands have Tyrone won under the management of Mickey Harte";
            question.a = "2";
            question.b = "3";
            question.c = "4";
            question.answer = "3";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "Who did Cork defeat in the 2010 All-Ireland Championship final?";
            question.a = "Mayo";
            question.b = "Tyrone";
            question.c = "Down";
            question.answer = "Down";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "How many goals were scored in the 2013 All-Ireland semi-final between Kerry and Dublin?";
            question.a = "6";
            question.b = "5";
            question.c = "3";
            question.answer = "6";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "Who won the Division 1 National Football League in 2013?";
            question.a = "Tyrone";
            question.b = "Kildare";
            question.c = "Dublin";
            question.answer = "Dublin";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Who did Meath beat in the Leinster Championship final after scoring a controversial goal in the 74th minute?";
            question.a = "Westmeath";
            question.b = "Laois";
            question.c = "Louth";
            question.answer = "Louth";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "Where is the headquaters of the GAA?";
            question.a = "Croke Park";
            question.b = "Semple Stadium";
            question.c = "Gaelic Grounds";
            question.answer = "Croke Park";
            questions.Add(question);

            //template below (20)
            question = null;
            question = new Question();
            question.text = "What is the capacity of Croke Park?";
            question.a = "82,300";
            question.b = "81,500";
            question.c = "79,600";
            question.answer = "82,300";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "What is the GAA stadium of Limerick called?";
            question.a = "Gaelic Grounds";
            question.b = "Fitzgerald Stadium";
            question.c = "O'Moore Park";
            question.answer = "Gaelic Grounds";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Who won the 2008 All-Ireland Football Championship?";
            question.a = "Kerry";
            question.b = "Tyrone";
            question.c = "Cork";
            question.answer = "Tyrone";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "What county does Ross Munnelly play for?";
            question.a = "Westmeath";
            question.b = "Wexford";
            question.c = "Laois";
            question.answer = "Laois";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which year did Sligo win the Connacht Football Championship?";
            question.a = "2006";
            question.b = "2007";
            question.c = "2008";
            question.answer = "2007";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county has won the most Connacht Football Championship titles?";
            question.a = "Mayo";
            question.b = "Galway";
            question.c = "Roscommon";
            question.answer = "Mayo";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "What is the name of the stadium of Antrim?";
            question.a = "Brewster Park";
            question.b = "Athletic Grounds";
            question.c = "Casement Park";
            question.answer = "Casement Park";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which year did Armagh draw with Fermanagh in the Ulster Football Championship Final?";
            question.a = "2006";
            question.b = "2007";
            question.c = "2008";
            question.answer = "2008";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these counties have never won a Leinster Football Championship?";
            question.a = "KilKenny";
            question.b = "Carlow";
            question.c = "Wicklow";
            question.answer = "Wicklow";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "In which year did Westmeath win their first Leinster Football Championship?";
            question.a = "1999";
            question.b = "2001";
            question.c = "2004";
            question.answer = "2004";
            questions.Add(question);

            //template below (30)
            question = null;
            question = new Question();
            question.text = "When was the last year Kerry or Cork did not win the Munster Football Championship?";
            question.a = "1992";
            question.b = "1994";
            question.c = "2000";
            question.answer = "1992";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "How many counties has Mick O'Dwyer managed?";
            question.a = "3";
            question.b = "2";
            question.c = "5";
            question.answer = "5";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "How many All-Ireland Football Championship titles has Colm Cooper won?";
            question.a = "3";
            question.b = "4";
            question.c = "6";
            question.answer = "4";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "How many All-Stars has Colm Cooper received?";
            question.a = "4";
            question.b = "7";
            question.c = "8";
            question.answer = "8";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "In which year did Joe Kernan manage Armagh to their first All-Ireland Football Championship title";
            question.a = "1998";
            question.b = "2002";
            question.c = "2003";
            question.answer = "2002";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "What is the name of the Ulster Football Championship Trophy?";
            question.a = "Anglo-Celt Cup";
            question.b = "J. J. Nestor Cup";
            question.c = "Delaney Cup";
            question.answer = "Anglo-Celt Cup";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "What is the name of the Connacht Football Championship Trophy?";
            question.a = "Anglo-Celt Cup";
            question.b = "J. J. Nestor Cup";
            question.c = "Delaney Cup";
            question.answer = "J. J. Nestor Cup";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "What is the name of the Leinster Football Championship Trophy?";
            question.a = "Anglo-Celt Cup";
            question.b = "J. J. Nestor Cup";
            question.c = "Delaney Cup";
            question.answer = "Delaney Cup";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "How many times in the last 80 years has the Munster Football Championship not been won by Cork or Kerry?";
            question.a = "6";
            question.b = "2";
            question.c = "9";
            question.answer = "2";
            questions.Add(question);


            //template below
            question = null;
            question = new Question();
            question.text = "How many All-Stars has Peter Canavan received?";
            question.a = "4";
            question.b = "5";
            question.c = "6";
            question.answer = "6";
            questions.Add(question);

            //template below (40)
            question = null;
            question = new Question();
            question.text = "Which county does Leighton Glynn play for?";
            question.a = "Wicklow";
            question.b = "Wexford";
            question.c = "Limerick";
            question.answer = "Wicklow";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county does Finian Hanley play for?";
            question.a = "Cork";
            question.b = "Galway";
            question.c = "Limerick";
            question.answer = "Galway";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county does Emmett Bolton play for?";
            question.a = "Derry";
            question.b = "Meath";
            question.c = "Kildare";
            question.answer = "Kildare";
            questions.Add(question);



            ///////////////////////////////////////////////////
            ///////////////////////////////////////////////////



            //template below
            question = null;
            question = new Question();
            question.text = "Which county are also known as The Royals?";
            question.a = "Limerick";
            question.b = "Meath";
            question.c = "Kerry";
            question.answer = "Meath";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "In which month is the All-Ireland final generally held?";
            question.a = "August";
            question.b = "September";
            question.c = "October";
            question.answer = "September";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which Ulster county was the first to win the Sam Maguire?";
            question.a = "Tyrone";
            question.b = "Cavan";
            question.c = "Donegal";
            question.answer = "Cavan";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which northern county were the first to bring the Sam Maguire back across the border?";
            question.a = "Derry";
            question.b = "Tyrone";
            question.c = "Down";
            question.answer = "Down";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which year did Down first win the All-Ireland?";
            question.a = "1960";
            question.b = "1963";
            question.c = "1966";
            question.answer = "1960";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county denied Kerry an unprecedented 5 in-a-row in 1982?";
            question.a = "Dublin";
            question.b = "Meath";
            question.c = "Offaly";
            question.answer = "Offaly";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "How many All-Irelands have Kerry won as of 2013?";
            question.a = "33";
            question.b = "36";
            question.c = "38";
            question.answer = "36";
            questions.Add(question);

            //template below  (50)
            question = null;
            question = new Question();
            question.text = "How many All-Irelands have Dublin won as of 2013?";
            question.a = "24";
            question.b = "25";
            question.c = "27";
            question.answer = "24";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these counties have won the most All-Irelands?";
            question.a = "Donegal";
            question.b = "Mayo";
            question.c = "Kildare";
            question.answer = "Kildare";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these counties have won the most All-Irelands?";
            question.a = "Wexford";
            question.b = "Tyrone";
            question.c = "Derry";
            question.answer = "Wexford";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county is also known as the Kingdom?";
            question.a = "Kerry";
            question.b = "Meath";
            question.c = "Dublin";
            question.answer = "Kerry";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Who did Tyrone beat in the 2013 All-Ireland final?";
            question.a = "Cork";
            question.b = "Kerry";
            question.c = "Armagh";
            question.answer = "Armagh";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county is home to Dr. Hyde Park?";
            question.a = "Westmeath";
            question.b = "Roscommon";
            question.c = "Louth";
            question.answer = "Roscommon";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which park is the Ulster Championship Final generally held?";
            question.a = "St. Tiernachs Park";
            question.b = "Caement Park";
            question.c = "Healy Park";
            question.answer = "St. Tiernachs Park";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which is the name of the Galway stadium?";
            question.a = "Pearse Park";
            question.b = "MacHale Park";
            question.c = "Gaelic Grounds";
            question.answer = "Pearse Park";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Where is Cusack Park?";
            question.a = "Tipperary";
            question.b = "Clare";
            question.c = "Waterford";
            question.answer = "Clare";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which county uses Parnell Park?";
            question.a = "Kildare";
            question.b = "Meath";
            question.c = "Dublin";
            question.answer = "Dublin";
            questions.Add(question);

            //template below  (60)
            question = null;
            question = new Question();
            question.text = "In 2003, which 3 counties had never won a provincial title?";
            question.a = "Antrim, Carlow and Wicklow";
            question.b = "Leitrim, Kilkenny and Wicklow";
            question.c = "Fermanagh, Westmeath and Wicklow";
            question.answer = "Fermanagh, Westmeath and Wicklow";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Excluding Kerry, which other team have won 4 in-a-row?";
            question.a = "Dublin";
            question.b = "Galway";
            question.c = "Wexford";
            question.answer = "Wexford";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these teams hold the most Ulster titles?";
            question.a = "Antrim";
            question.b = "Derry";
            question.c = "Donegal";
            question.answer = "Antrim";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these teams hold the most Leinster titles?";
            question.a = "Longford";
            question.b = "Westmeath";
            question.c = "Kilkenny";
            question.answer = "Kilkenny";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these teams hold the most Munster titles?";
            question.a = "Waterford";
            question.b = "Clare";
            question.c = "Limerick";
            question.answer = "Clare";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "In what year did Derry win the All-Ireland?";
            question.a = "1986";
            question.b = "1989";
            question.c = "1993";
            question.answer = "1993";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which 2 counties have a 100% success rate in All-Ireland finals?";
            question.a = "Donegal and Limerick";
            question.b = "Offaly and Meath";
            question.c = "Derry and Tipperary";
            question.answer = "Donegal and Limerick";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these teams hold the most All-Ireland titles?";
            question.a = "Mayo";
            question.b = "Wexford";
            question.c = "Tipperary";
            question.answer = "Wexford";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which of these teams hold the most All-Ireland titles?";
            question.a = "Donegal";
            question.b = "Derry";
            question.c = "Louth";
            question.answer = "Louth";
            questions.Add(question);

            //template below
            question = null;
            question = new Question();
            question.text = "Which team were the first to win an All-Ireland 'through the back door'?";
            question.a = "Cork";
            question.b = "Galway";
            question.c = "Armagh";
            question.answer = "Galway";
            questions.Add(question);

            //template below (70)
            question = null;
            question = new Question();
            question.text = "Out of Mayo's 14 appearances in All-Ireland finals, how many have they won?";
            question.a = "3";
            question.b = "5";
            question.c = "6";
            question.answer = "3";
            questions.Add(question);
   

        }
    }
}