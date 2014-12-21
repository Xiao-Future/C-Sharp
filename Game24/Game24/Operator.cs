using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace Game24
{
    public class Operator
    {
        List<int> randomNumber;
        string input;
        DataTable caculateInput = new DataTable();
        Random random;
        Regex regex1 = new Regex(@"\d");

        public Operator(string input)
        {
            this.input = input;
        }

        public bool JudgeThe24(string input,List<int> randomNumber,int[] judgeNumber)
        {
            int k = 0;
            for (int i = 0; i < 4; i++)
            {   
                if (randomNumber.Contains(judgeNumber[i]))
                {
                    k++;
                } 
            }
            if (k == 4)
            {
                if (caculateInput.Compute(input, "false").ToString() == "24")
                {
                    return true;
                }
            }
            return false;
        }

        public List<int> RandomTheNumber()
        {
            random = new Random();
            randomNumber = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                randomNumber.Add(random.Next(1, 14));
            }
            return randomNumber;
        }

        public int[] GotTheNumberOfInput(string input)
        {
            char[] inputSplit = input.ToCharArray();
            int[] judgeNumber = new int[4];
            int j = 0, i = 0;
            while (i < inputSplit.Length)
            {
                if (i < inputSplit.Length - 1)
                {
                    if (regex1.IsMatch(inputSplit[i].ToString()) && regex1.IsMatch(inputSplit[i + 1].ToString()))
                    {
                        judgeNumber[j] = int.Parse(inputSplit[i].ToString()) * 10 + int.Parse(inputSplit[i + 1].ToString());
                        i += 2;
                        j++;
                    }
                    else if (regex1.IsMatch(inputSplit[i].ToString()) && !regex1.IsMatch(inputSplit[i + 1].ToString()))
                    {
                        judgeNumber[j] = int.Parse(inputSplit[i].ToString());
                        i++;
                        j++;
                    }
                    else
                    {
                        i++;
                    } 
                }
                else
                {
                    if (j == 4)
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            judgeNumber[j] = int.Parse(inputSplit[i].ToString());
                        }
                        catch (Exception)
                        {
                            judgeNumber[j] = 0;
                        }
                        i++;
                    }
                }
            }
            return judgeNumber;
        }
    }
}
