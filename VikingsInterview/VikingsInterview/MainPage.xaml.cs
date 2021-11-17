using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VikingsInterview
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        public void OnClick(object sender, RoutedEventArgs e)
        {
            double CperA;
            double aveYards;
            double touchPercent;
            double intValue;
            double rating;

            if (Name.Text == "") { Results.Text = "Please provide the player's name"; return; }
            if (PA.Value.Equals(double.NaN)) { Results.Text = "Please provide the Pass Attempts"; return; }
            if (PC.Value.Equals(double.NaN)) { Results.Text = "Please provide the Pass Completions"; return; }
            if (Yards.Value.Equals(double.NaN)) { Results.Text = "Please provide the Passing Yards"; return; }
            if (Touchdowns.Value.Equals(double.NaN)) { Results.Text = "Please provide the Passing Touchdowns"; return; }
            if (Interceptions.Value.Equals(double.NaN)) { Results.Text = "Please provide the Interceptions"; return; }
            try
            {
                CperA = (PC.Value / PA.Value * 100 - 30) * 0.05;
                if (CperA < 0)
                {
                    CperA = 0;
                }
                if (CperA > 2.375)
                {
                    CperA = 2.375;
                }

                aveYards = (Yards.Value / PA.Value - 3) * 0.25;
                if (aveYards < 0)
                {
                    aveYards = 0;
                }
                if (aveYards > 2.375)
                {
                    aveYards = 2.375;
                }

                touchPercent = (Touchdowns.Value / PA.Value * 100) * 0.2;
                if (touchPercent > 2.375)
                {
                    touchPercent = 2.375;
                }

                intValue = 2.375 - ((Interceptions.Value / PA.Value * 100) * 0.25);
                if (intValue < 0)
                {
                    intValue = 0;
                }

                rating = (CperA + aveYards + touchPercent + intValue) / 6 * 100;
                Results.Text = Name.Text + "'s QB rating is " + rating.ToString("0.0") + "\n";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
