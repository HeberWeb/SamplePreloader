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
    /// Interaction logic for PreLoaderControl.xaml
    /// </summary>
    public partial class PreLoaderControl : UserControl
    {
        // Flag variables used as a toggle to animate the block in both directions

        private bool Animation1RuningForward = true;
        private bool Animation2RuningForward = true;
        private bool Animation3RuningForward = true;
        private bool Animation4RuningForward = true;
        private double blockWidth = 16;
        public PreLoaderControl()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Double blockSplitWidth = this.Width / 100;
            if (blockSplitWidth > 0.50)
                blockSplitWidth = 0.50;
            blockWidth = (this.Width / 2) - (blockSplitWidth * 4);
            double blockHeight = (this.Height / 2) - (blockSplitWidth * 4);
            gridBlock1.Width = blockWidth;
            gridBlock2.Width = blockWidth;
            gridBlock3.Width = blockWidth;
            gridBlock4.Width = blockWidth;
            gridBlock1.Height = blockHeight;
            gridBlock2.Height = blockHeight;
            gridBlock3.Height = blockHeight;
            gridBlock4.Height = blockHeight;
            StartAnimation("ProgressAnimation1", Animation1RuningForward);
        }

        // When the animation #1 is completed the following event function 
        // will start the animation #2
        // Animation1RunningForward is toggled to animate the width from and to 0

        private void ProgressAnimation1_Completed(object sender, EventArgs e)
        {
            Animation1RuningForward = !Animation1RuningForward;
            StartAnimation("ProgressAnimation2", Animation2RuningForward);
        }

        // When the animation #2 is completed the following event function 
        // will start the animation #3 
        // Animation2RunningForward is toggled to animate the width from and to 0

        private void ProgressAnimation2_Completed(object sender, EventArgs e)
        {
            Animation2RuningForward = !Animation2RuningForward;
            StartAnimation("ProgressAnimation3", Animation3RuningForward);
        }

        // When the animation #3 is completed the following event function 
        // will start the animation #4 
        // Animation3RunningForward is toggled to animate the width from and to 0


        private void ProgressAnimation3_Completed(object sender, EventArgs e)
        {
            Animation3RuningForward = !Animation3RuningForward;
            StartAnimation("ProgressAnimation4", Animation4RuningForward);
        }

        // When the animation #4 is completed the following event function 
        // will start the animation #1 
        // Animation4RunningForward is toggled to animate the width from and to 0

        private void ProgressAnimation4_Completed(object sender, EventArgs e)
        {
            Animation4RuningForward = !Animation4RuningForward;
            StartAnimation("ProgressAnimation1", Animation1RuningForward);
        }

        // Begins the storyboard animation specified in the storyboardResourceName variable
        // The RunForward flag will toggle the widthFrom, widthTo values from 0 to
        // the calculated block width and vice versa.

        private void StartAnimation(String storyboardResourceName, bool RunForward)
        {
            double widthFrom = blockWidth;
            double widthTo = 0;
            if (RunForward)
            {
                widthFrom = blockWidth;
                widthTo = 0;
            }
            else
            {
                widthFrom = 0;
                widthTo = blockWidth;
            }
            Storyboard storyboard = this.FindResource(storyboardResourceName) as Storyboard;
            DoubleAnimation doubleanimation = storyboard.Children[0] as DoubleAnimation;
            doubleanimation.From = widthFrom;
            doubleanimation.To = widthTo;
            storyboard.Begin();
        }
    }
}
