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

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=391641 dokumentiert.

namespace SimpleCalculator
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private float result;
        private float memory;
        private float first, second;
        private bool isfirst = true;
        private bool isfirstcomma = true;
        private enum Operators { PLUS, MINUS, DIVIDE, MULTIPLY };
        private int op;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void clearall(object sender, RoutedEventArgs e)
        {
            result = 0;
            display.Text = result.ToString();
            isfirst = true;
            isfirstcomma = true;

        }

        private void Memoryclear(object sender, RoutedEventArgs e)
        {
            memory = 0;
        }

        private void Click_zero(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "0";
            }
            else
            {
                display.Text = display.Text + 0;
            }

        }

        private void Click_one(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "1";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 1;
            }

        }

        private void Click_two(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "2";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 2;
            }

        }

        private void Click_three(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "3";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 3;
            }
        }

        private void Click_four(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "4";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 4;
            }
        }

        private void Click_five(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "5";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 5;
            }
        }

        private void Click_six(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "6";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 6;
            }
        }

        private void Click_seven(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "7";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 7;
            }
        }

        private void Click_eight(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "8";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 8;
            }
        }

        private void Click_nine(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "9";
                isfirst = false;
            }
            else
            {
                display.Text = display.Text + 9;
            }
        }

        private void Click_comma(object sender, RoutedEventArgs e)
        {
            if (isfirst)
            {
                display.Text = "0,";
                isfirst = false;
                isfirstcomma = false;
            }
            else if ( isfirstcomma)
            {
                display.Text = display.Text + ",";
                isfirstcomma = false;
            } else
            {
                display.Text = display.Text;
            }
        }

        private void MemoryStore(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(display.Text, out memory))
            {
                display.Text = "Error";
                isfirst = true;
            }
        }

        private void MemoryRestore(object sender, RoutedEventArgs e)
        {
            display.Text = memory.ToString();
        }

        private void Click_divide(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(display.Text, out first))
            {
                display.Text = "Error";
            }
            else
            {
                op = (int)Operators.DIVIDE;
            }
            isfirst = true;
            isfirstcomma = true;
        }

        private void Click_multiply(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(display.Text, out first))
            {
                display.Text = "Error";
            }
            else
            {
                op = (int)Operators.MULTIPLY;
            }
            isfirst = true;
            isfirstcomma = true;
        }

        private void Click_substract(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(display.Text, out first))
            {
                display.Text = "Error";

            }
            else
            {
                op = (int)Operators.MINUS;
            }
            isfirst = true;
            isfirstcomma = true;
        }

        private void Click_add(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(display.Text, out first))
            {
                display.Text = "Error";
            }
            else
            {
                op = (int)Operators.PLUS;
            }
            isfirst = true;
            isfirstcomma = true;
        }

        private void Click_sum(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(display.Text, out second))
            {
                display.Text = "Error";
            }
            else
            {
                if (op == 2 && second.Equals(0))
                {
                    display.Text = "Error";
                }
                else
                {

                    switch (op)
                    {
                        case 0:
                            result = first + second;
                            break;
                        case 1:
                            result = first - second;
                            break;
                        case 2:
                            result = first / second;
                            break;
                        case 3:
                            result = first * second;

                            break;
                        default:
                            break;
                    }
                    display.Text = result.ToString();
                }
            }
            first = 0;
            second = 0;
            isfirst = true;
            isfirstcomma = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
