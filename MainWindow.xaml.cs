using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            CalcOutput.Text = TypeInput.Text;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            float total = 0;
            string equation = CalcOutput.Text.ToLower();

            string thisNum = "";
            bool needToAdd = true;
            bool needToMulti = false;
            for (int i = 0; i < equation.Length; i++)
            {
                if(equation[i] == ' ')
                {
                    continue;
                }
                else if(equation[i] == '+')
                {
                    if (needToAdd)
                    {
                        total += float.Parse(thisNum);
                        needToAdd = false;
                    }
                    else if (needToMulti)
                    {
                        total *= float.Parse(thisNum);
                        needToMulti = false;
                    }

                    needToAdd = true;
                    thisNum = "";
                }
                else if(equation[i] == '-')
                {
                    if (needToAdd)
                    {
                        total += float.Parse(thisNum);
                        needToAdd = false;
                    }
                    else if (needToMulti)
                    {
                        total *= float.Parse(thisNum);
                        needToMulti = false;
                    }

                    needToAdd = true;
                    thisNum = "-";
                }
                else if((equation[i] == 'x') | (equation[i] == '*'))
                {
                    if (needToAdd)
                    {
                        total += float.Parse(thisNum);
                        needToAdd = false;
                    }
                    else if (needToMulti)
                    {
                        total *= float.Parse(thisNum);
                        needToMulti = false;
                    }

                    thisNum = "";
                    needToMulti = true;
                }
                else if (equation[i] == '(')
                {
                    thisNum = BetweenBrackets(equation, i, 1).ToString();
                    i = equation.LastIndexOf(')');

                    if (needToAdd)
                    {
                        total += float.Parse(thisNum);
                        needToAdd = false;
                    }
                    else if (needToMulti)
                    {
                        total *= float.Parse(thisNum);
                        needToMulti = false;
                    }
                    else
                    {
                        total *= float.Parse(thisNum);
                    }
                }
                else
                {
                    thisNum += equation[i];
                }
            }

            if (needToAdd)
            {
                total += float.Parse(thisNum);
                needToAdd = false;
            }
            else if (needToMulti)
            {
                total *= float.Parse(thisNum);
                needToMulti = false;
            }

            CalcOutput.Text = total.ToString();
        }

        private bool isNum(string number)
        {
            bool isNum = true;

            foreach(char c in number)
            {
                if((c != '0') & (c != '9') & (c != '8') & (c != '7') & (c != '6') & (c != '5') & (c != '4') & (c != '3') & (c != '2') & (c != '1') & (c != '.') & (c != '-'))
                {
                    isNum = false;
                }
            }

            return isNum;
        }

        private float BetweenBrackets(string equation, int indexOfBracket, int bracketNum)
        {
            int numOfLastBrackets = 0;
            int indexOfEnd = equation.Length - 1;
            for(int i = equation.Length - 1; i > indexOfBracket; i--)
            {
                if(equation[i] == ')')
                {
                    numOfLastBrackets++;
                }
                if(numOfLastBrackets == bracketNum)
                {
                    indexOfEnd = i;
                    break;
                }

            }

            float total = 0;
            string thisNum = "";
            bool needToAdd = true;
            bool needToMulti = false;
            for(int i = indexOfBracket + 1; i < indexOfEnd; i++)
            {
                if (equation[i] == ' ')
                {
                    continue;
                }
                else if (equation[i] == '+')
                {
                    if (needToAdd)
                    {
                        total += float.Parse(thisNum);
                        needToAdd = false;
                    }
                    else if (needToMulti)
                    {
                        total *= float.Parse(thisNum);
                        needToMulti = false;
                    }

                    needToAdd = true;
                    thisNum = "";
                }
                else if (equation[i] == '-')
                {
                    if (needToAdd)
                    {
                        total += float.Parse(thisNum);
                        needToAdd = false;
                    }
                    else if (needToMulti)
                    {
                        total *= float.Parse(thisNum);
                        needToMulti = false;
                    }

                    needToAdd = true;
                    thisNum = "-";
                }
                else if ((equation[i] == 'x') | (equation[i] == '*'))
                {
                    if (needToAdd)
                    {
                        total += float.Parse(thisNum);
                        needToAdd = false;
                    }
                    else if (needToMulti)
                    {
                        total *= float.Parse(thisNum);
                        needToMulti = false;
                    }

                    thisNum = "";
                    needToMulti = true;
                }
                else if (equation[i] == '(')
                {
                    thisNum = BetweenBrackets(equation, i, bracketNum + 1).ToString();
                    i = equation.LastIndexOf(')');

                    if (needToAdd)
                    {
                        total += float.Parse(thisNum);
                        needToAdd = false;
                    }
                    else if (needToMulti)
                    {
                        total *= float.Parse(thisNum);
                        needToMulti = false;
                    }
                    else
                    {
                        total *= float.Parse(thisNum);
                    }
                }
                else
                {
                    thisNum += equation[i];
                }
            }

            if (needToAdd)
            {
                total += float.Parse(thisNum);
                needToAdd = false;
            }
            else if (needToMulti)
            {
                total *= float.Parse(thisNum);
                needToMulti = false;
            }

            return total;
        }
    }

}
