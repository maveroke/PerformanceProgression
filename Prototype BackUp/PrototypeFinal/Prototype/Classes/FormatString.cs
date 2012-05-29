using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplicationValueInput
{
    class FormatString
    {
        private string Str;
        protected string negativeResponse = "It's not the right format";
        public FormatString(string text)
        {
            //Str = text.Trim(' ');
            Str = text.Replace(" ", string.Empty);
        }

        public string Distance()
        {
            try
            {
                double Num;
                bool isNum = double.TryParse(Str, out Num);
                if (isNum)
                {
                    if (Num > 0 && Num < 120)
                        return "working";
                    else
                        return "Isnt a real value";
                }
                else
                    return negativeResponse;
            }
            catch
            {
                return negativeResponse;
            }
        }

        public string Points()
        {
            try
            {
                double Num;
                bool isNum = double.TryParse(Str, out Num);
                if (isNum)
                {
                    if (!Str.Contains('.') && Convert.ToInt32(Str) < 10000 && Convert.ToInt32(Str) > 0)
                        return "working";
                    else
                        return "Invalid number";
                }
                else
                    return negativeResponse;
            }
            catch
            {
                return negativeResponse;
            }
        }

        public string Time()
        {
            try
            {
                double Num;
                bool isNum = double.TryParse(Str.Replace(":", ""), out Num);
                //takes MM:SS.ss
                if (Str.Contains(':') && Str.Contains('.'))
                {
                    if (isNum)
                    {
                        string[] temp = Str.Split(':', '.');
                        if (temp[0].CompareTo("") != 0)
                            if (temp[1].CompareTo("") != 0)
                                if (temp[2].CompareTo("") != 0)
                                {
                                    if (Convert.ToInt32(temp[0]) >= 0 && Convert.ToInt32(temp[0]) < 60 &&
                                        Convert.ToInt32(temp[1]) >= 0 && Convert.ToInt32(temp[1]) < 60 &&
                                        Convert.ToInt32(temp[2]) >= 0 && Convert.ToInt32(temp[2]) < 100)
                                        return "working";
                                    else
                                        return "Invalid time";
                                }
                                else
                                    return "Missing split secs";
                            else
                                return "Missing secs";
                        else
                            return "Missing mins";
                    }
                    else
                        return "Invalid number";
                }
                //case its AA:BB or AA.BB
                else if (Str.Contains(':') || Str.Contains('.'))
                {
                    string[] temp = Str.Split(':', '.');
                    if (temp[0].CompareTo("") != 0)
                    {
                        if (temp[1].CompareTo("") != 0)
                        {
                            if (Convert.ToInt32(temp[0]) >= 0 && Convert.ToInt32(temp[0]) < 60 &&
                                        Convert.ToInt32(temp[1]) >= 0 && Convert.ToInt32(temp[1]) < 100)
                                return "working";
                            else
                                return "Invalid Time";
                        }
                        else return "Invalid number";

                    }
                    else return "Invalid number";

                }
                else
                    return negativeResponse;
            }
            catch
            {
                return negativeResponse;
            }
        }

        public string Date()
        {
            //string opt = ".";
            // if (Str.Contains("-")) { opt = "-"; }
            // else if (Str.Contains("/")) { opt = "/"; }
            // switch (opt)
            // {
            //  case "-":
            //      return checkDate('-');
            //  case "/":
            return checkDate('/');
            //  default:
            //      return checkDate('.');
            // }
        }

        private string checkDate(char split)
        {
            try
            {
                double Num;
                string ver = Convert.ToString(split);
                bool isNum = double.TryParse(Str.Replace(ver, ""), out Num);
                if (isNum)
                {
                    string[] temp2 = Str.Split(split);
                    if (temp2[0].CompareTo("") != 0)
                    {
                        if (temp2[1].CompareTo("") != 0)
                        {
                            if (temp2[2].CompareTo("") != 0)
                            {
                                //check that they are ints above or equal to the lowest value
                                if (Convert.ToInt32(temp2[0]) >= 1 &&
                                    Convert.ToInt32(temp2[1]) >= 1 &&
                                    Convert.ToInt32(temp2[2]) >= 1900 && Convert.ToInt32(temp2[2]) < 2200)
                                {

                                    string tempDay = temp2[0], tempMonth = temp2[1];
                                    //Not possible, return negative response
                                    if (Convert.ToInt32(tempDay) > 12 && Convert.ToInt32(tempMonth) > 12)
                                    {
                                        return negativeResponse;
                                    }
                                    //check that month is under 12. If not assume that format == mm/dd/yyyy instead of dd/mm/yyyy
                                    else if (Convert.ToInt32(tempMonth) > 12) { tempDay = temp2[1]; tempMonth = temp2[0]; }

                                    int daysInMonth;
                                    switch (Convert.ToInt32(tempMonth))
                                    {
                                        case 2:
                                            daysInMonth = 28;
                                            break;
                                        case 4:
                                        case 6:
                                        case 9:
                                        case 11:
                                            daysInMonth = 30;
                                            break;
                                        default:
                                            daysInMonth = 31;
                                            break;
                                    }
                                    if (Convert.ToInt32(tempDay) <= daysInMonth)
                                        return "working";
                                    else
                                        return "Not that many days in the Month";
                                }
                                else
                                    return "Invalid time";
                            }
                            else
                                return "Missing years";
                        }
                        else
                            return "Missing days";
                    }
                    else
                        return "Missing months";
                }
                else
                    return negativeResponse;
            }
            catch
            {
                return negativeResponse;
            }
        }
    }
}
