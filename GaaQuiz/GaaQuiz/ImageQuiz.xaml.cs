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
    public partial class ImageQuiz : PhoneApplicationPage
    {


        private int corrected_Images = 0;





        private int totalQuestions_Images = 0;



        private List<Question> questions_Images = new List<Question>();
        private Question currentQuestion_Images = new Question();

        private SoundEffect correctSound, wrongSound;


        public ImageQuiz()
        {
            InitializeComponent();

            FrameworkDispatcher.Update();

            this.LoadSound("Sounds/correct.wav", out correctSound);
            this.LoadSound("Sounds/wrong.wav", out wrongSound);

            this.initialize_Images();

            this.startImages();
        }



        private void showGameFinished()
        {
            int totalScore = (corrected_Images);

            // Configure message box 
            string message = "You finished with a score of " + corrected_Images + "/15.";
            string caption = "Game Over";
            MessageBoxButton buttons = MessageBoxButton.OK;
            // Show message box
            MessageBoxResult result = MessageBox.Show(caption, message, buttons);

            NavigationService.Navigate(new Uri("/SelectCategory.xaml", UriKind.Relative));
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


        private void btnAImages_Click(object sender, RoutedEventArgs e)
        {
            this.compareImages(btnAImages.Content.ToString());
        }

        private void btnBImages_Click(object sender, RoutedEventArgs e)
        {
            this.compareImages(btnBImages.Content.ToString());
        }

        private void btnCImages_Click(object sender, RoutedEventArgs e)
        {
            this.compareImages(btnCImages.Content.ToString());
        }

        private void nextQuestion_Images()
        {
            questions_Images = ShuffleList<Question>(questions_Images);
            currentQuestion_Images = questions_Images.ElementAt<Question>(0);
            //txtQuestionImages.Text = currentQuestion_Images.text;

            Images.Source = currentQuestion_Images.image;
            btnAImages.Content = currentQuestion_Images.a;
            btnBImages.Content = currentQuestion_Images.b;
            btnCImages.Content = currentQuestion_Images.c;

            questions_Images.RemoveAt(0);
        }

        private void compareImages(String answer)
        {


            if (answer.Equals(currentQuestion_Images.answer))
            {
                this.correctSound.Play();
                corrected_Images++;
                totalQuestions_Images++;

                txtCorrectImages.Text = "Correct: " + corrected_Images + "/" + totalQuestions_Images;

                // Configure message box 
                string message = "Correct Answer!";
                string caption = "";
                MessageBoxButton buttons = MessageBoxButton.OK;
                // Show message box
                MessageBoxResult result = MessageBox.Show(caption, message, buttons);

                this.nextQuestion_Images();
            }
            else
            {
                this.wrongSound.Play();
                totalQuestions_Images++;

                txtCorrectImages.Text = "Correct: " + corrected_Images + "/" + totalQuestions_Images;

                // Configure message box 
                string message = "Wrong Answer!";
                string caption = "";
                MessageBoxButton buttons = MessageBoxButton.OK;
                // Show message box
                MessageBoxResult result = MessageBox.Show(caption, message, buttons);

                this.nextQuestion_Images();
            }


            if (totalQuestions_Images > 14)
            {
                this.stopImages();
            }


        }



        private void stopImages()
        {

            btnAImages.IsEnabled = false;
            btnBImages.IsEnabled = false;
            btnCImages.IsEnabled = false;

            this.showGameFinished();

        }

        private void startImages()
        {

            this.nextQuestion_Images();
        }

        private void initialize_Images()
        {
            Question question = null;
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Antrim.jpg", UriKind.Relative));
            //
            question.a = "Antrim";
            question.b = "Wexford";
            question.c = "Down";
            question.answer = "Antrim";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Armagh.jpg", UriKind.Relative));
            question.a = "Derry";
            question.b = "Armagh";
            question.c = "Tyrone";
            question.answer = "Armagh";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Carlow.jpg", UriKind.Relative));
            question.a = "Westmeath";
            question.b = "Wicklow";
            question.c = "Carlow";
            question.answer = "Carlow";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Cavan.jpg", UriKind.Relative));
            question.a = "Monaghan";
            question.b = "Cavan";
            question.c = "Waterford";
            question.answer = "Cavan";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Clare.jpg", UriKind.Relative));
            question.a = "Clare";
            question.b = "Kildare";
            question.c = "Roscommon";
            question.answer = "Clare";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Cork.jpg", UriKind.Relative));
            question.a = "Cork";
            question.b = "Tyrone";
            question.c = "Louth";
            question.answer = "Cork";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/derry.jpg", UriKind.Relative));
            question.a = "Longford";
            question.b = "Derry";
            question.c = "Tyrone";
            question.answer = "Derry";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Donegal.jpg", UriKind.Relative));
            question.a = "Kerry";
            question.b = "Fermanagh";
            question.c = "Donegal";
            question.answer = "Donegal";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/DOWN.jpg", UriKind.Relative));
            question.a = "Westmeath";
            question.b = "Sligo";
            question.c = "Down";
            question.answer = "Down";
            questions_Images.Add(question);

            //template  (10)
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Dublin.jpg", UriKind.Relative));
            question.a = "Cork";
            question.b = "Galway";
            question.c = "Dublin";
            question.answer = "Dublin";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/fermanagh.jpg", UriKind.Relative));
            question.a = "Meath";
            question.b = "Fermanagh";
            question.c = "Donegal";
            question.answer = "Fermanagh";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/galway.jpg", UriKind.Relative));
            question.a = "Westmeath";
            question.b = "Galway";
            question.c = "Limerick";
            question.answer = "Galway";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/kerry.png", UriKind.Relative));
            question.a = "Kerry";
            question.b = "Mayo";
            question.c = "Donegal";
            question.answer = "Kerry";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Kildare.jpg", UriKind.Relative));
            question.a = "Clare";
            question.b = "Kildare";
            question.c = "Wicklow";
            question.answer = "Kildare";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/laois.jpg", UriKind.Relative));
            question.a = "Laois";
            question.b = "Longford";
            question.c = "Cavan";
            question.answer = "Laois";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/LEITRIM.jpg", UriKind.Relative));
            question.a = "Roscommon";
            question.b = "Kilkenny";
            question.c = "Leitrim";
            question.answer = "Leitrim";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Limerick.jpg", UriKind.Relative));
            question.a = "Fermanagh";
            question.b = "Limerick";
            question.c = "Leitrim";
            question.answer = "Limerick";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/longford.jpg", UriKind.Relative));
            question.a = "Wexford";
            question.b = "Kildare";
            question.c = "Longford";
            question.answer = "Longford";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/LOUTH.jpg", UriKind.Relative));
            question.a = "Carlow";
            question.b = "Galway";
            question.c = "Louth";
            question.answer = "Louth";
            questions_Images.Add(question);

            //template  (20)
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Mayo.jpg", UriKind.Relative));         
            question.a = "Mayo";
            question.b = "Armagh";
            question.c = "Antrim";
            question.answer = "Mayo";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Meath.jpg", UriKind.Relative));
            question.a = "Meath";
            question.b = "Kerry";
            question.c = "Limerick";
            question.answer = "Meath";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/monaghan.jpg", UriKind.Relative));
            question.a = "Laois";
            question.b = "Monaghan";
            question.c = "Offaly";
            question.answer = "Monaghan";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/OFFALY.jpg", UriKind.Relative));
            question.a = "Tipperary";
            question.b = "Offaly";
            question.c = "Louth";
            question.answer = "Offaly";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Roscommon.jpg", UriKind.Relative));
            question.a = "Mayo";
            question.b = "Leitrim";
            question.c = "Roscommon";
            question.answer = "Roscommon";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Sligo.jpg", UriKind.Relative));
            question.a = "Down";
            question.b = "Longford";
            question.c = "Sligo";
            question.answer = "Sligo";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/tipperary.jpg", UriKind.Relative));
            question.a = "Clare";
            question.b = "Tipperary";
            question.c = "Kilkenny";
            question.answer = "Tipperary";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Tyrone.jpg", UriKind.Relative));
            question.a = "Tyrone";
            question.b = "Derry";
            question.c = "Louth";
            question.answer = "Tyrone";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/waterford.jpg", UriKind.Relative));
            question.a = "Waterford";
            question.b = "Galway";
            question.c = "Cork";
            question.answer = "Waterford";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/westmeath.jpg", UriKind.Relative));
            question.a = "Galway";
            question.b = "Westmeath";
            question.c = "Waterford";
            question.answer = "Westmeath";
            questions_Images.Add(question);

            //template (30)
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Wexford.jpg", UriKind.Relative));
            question.a = "Kildare";
            question.b = "Wexford";
            question.c = "Longford";
            question.answer = "Wexford";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/WICKLOW.jpg", UriKind.Relative));
            question.a = "Westmeath";
            question.b = "Wexford";
            question.c = "Wicklow";
            question.answer = "Wicklow";
            questions_Images.Add(question);

            //template
            question = null;
            question = new Question();
            question.image = new BitmapImage(new Uri("Images/Kilkenny.jpg", UriKind.Relative));
            question.a = "Kilkenny";
            question.b = "Wexford";
            question.c = "Clare";
            question.answer = "Kilkenny";
            questions_Images.Add(question);



        }


    }
}