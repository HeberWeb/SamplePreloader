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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SamplePreloader
{
    /// <summary>
    /// Interaction logic for PreloaderCircleCarousel.xaml
    /// </summary>
    public partial class PreloaderCircleBreath : UserControl
    {
        private bool alteraGeral = true;
        private double speed = 2;
        private TimeSpan time = new TimeSpan(0, 0, 1);
        private double sizeStart = 20;
        private double sizeEnd = 30;
        public PreloaderCircleBreath()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetAnimation("animation1", alteraGeral);
        }

        private void DoubleAnimation_Completed1(object sender, EventArgs e)
        {
            alteraGeral = !alteraGeral;
            this.SetAnimation("animation1", alteraGeral);
        }

        public void SetAnimation(string nameAnimation, bool altera)
        {
            double sizeFrom;
            double sizeTo;
            if (altera)
            {
                sizeFrom = sizeStart;
                sizeTo = sizeEnd;
            }
            else
            {
                sizeFrom = sizeEnd;
                sizeTo = sizeStart;
            }

            Storyboard storyboard = this.FindResource(nameAnimation) as Storyboard;
            DoubleAnimation doubleAnimationWidth = storyboard.Children[0] as DoubleAnimation;
            DoubleAnimation doubleAnimationHeigth = storyboard.Children[1] as DoubleAnimation;
            doubleAnimationWidth.From = sizeFrom;
            doubleAnimationWidth.To = sizeTo;
            doubleAnimationWidth.Duration = this.time;
            doubleAnimationHeigth.From = sizeFrom;
            doubleAnimationHeigth.To = sizeTo;
            doubleAnimationHeigth.Duration = this.time;
            storyboard.SpeedRatio = speed;
            storyboard.Begin();
        }
    }
}
