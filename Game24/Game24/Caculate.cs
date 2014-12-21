using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game24
{
    public class Caculate
    {
        private List<double> number = new List<double>();
        public List<double> reSortResult = new List<double>();
        public List<double> reSortResult1 = new List<double>();

        public double toCaculate(double number1, double number2, int parameter)
        {
            switch (parameter)
            {
                case 0: return number1 + number2;
                case 1: return number1 - number2;
                case 2: return number1 * number2;
                default: return number1 / number2;
            }
        }

        public Caculate(int n1,int n2,int n3,int n4)
        {
            number.Add(n1);
            number.Add(n2);
            number.Add(n3);
            number.Add(n4);
        }

        public List<double> ReSort()//对4个数字进行排列组合
        {
            List<double> numberCopy = number;
            double[] reSort=new double[4];
            reSortResult.AddRange(number);
            for (int i = 0; i < 4; i++)
            {
                reSortResult[0] = numberCopy[i];
                for (int j = 0; j < 4; j++)
                {
                    if (j != i)
                    {
                        reSortResult[1] = numberCopy[j];
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        if (k != i && k!= j)
                        {
                            reSortResult[2] = numberCopy[k]; 
                        }
                        for (int w = 0; w < 4; w++)
                        {
                            if (w != i && w != j && w!= k)
                            {
                                reSortResult[3] = numberCopy[w];
                                if (w != i && w != j && w!= k && k != i && k!= j && j != i)
                                {
                                    for (int m = 0; m < 4; m++)
                                    {
                                        reSortResult1.Add(reSortResult[m]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return reSortResult1;
        }

        public List<string> Caculate24(List<double> number)//计算24点
        {
            //double sum, sum1, sum2, sum3, sum4;
            double sum;
            double sumOther, sumOther1, sumOther2;
            string resultSolution = "";
            List<string> resultSummary = new List<string>();
            for (int i = 0; i < reSortResult1.Count; i += 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int w = 0; w < 4; w++)
                        {
                            sum = toCaculate(number[i], number[i + 1], j);
                            //sum1 = toCaculate(number[i + 2], sum, k);
                            //sum3 = toCaculate(number[i + 3], sum1, w);
                            //sum4 = toCaculate(sum1,number[i+3], w);
                            sum = toCaculate(sum, number[i + 2], k);
                            //sum2 = toCaculate(number[i + 3], sum, w);
                            sum = toCaculate(sum, number[i + 3], w);
                            sumOther1 = toCaculate(number[i], number[i + 1], j);
                            sumOther2 = toCaculate(number[i + 2], number[i + 3], k);
                            sumOther = toCaculate(sumOther1, sumOther2, w);
                            resultSolution = "";
                            if (sum == 24)
                            {
                               resultSummary.Add(PrintTheResultSum(i, j, k, w, resultSolution,number));
                            }//done
                            //if (sum2 == 24)
                            //{
                            //   resultSummary.Add(PrintTheResultSum2(i, j, k, w, resultSolution, number));
                            //}//done
                            /*if (sum3 == 24)
                            {
                              resultSummary.Add(PrintTheResultSum3(i, j, k, w, resultSolution, number));
                            }*/
                            //if (sum4 == 24)
                            //{
                            //    resultSummary.Add(PrintTheResultSum4(i, j, k, w, resultSolution, number));
                            //}
                            if (sumOther == 24)
                            {
                               resultSummary.Add(PrintTheResultSumOther(i, j, k, w, resultSolution, number));
                            }
                        }
                    }
                }
            }
            if (resultSummary.Count == 0)
            {
                resultSummary.Add("没有结果！");
                return resultSummary;
            }
            else
            {
                resultSummary = JudgeTheResult(resultSummary);
                resultSummary = resultSummary.Distinct().ToList();//去除相同结果
                return resultSummary;
            }
        }
        private string PrintTheResultSum3(int i, int j, int k, int w, string resultSolution, List<double> number)
        {
            switch (j)
            {
                case 0: resultSolution += "(" + number[i].ToString() + "+" + number[i + 1].ToString() + ")" + ")"; break;
                case 1: resultSolution += "(" + number[i].ToString() + "-" + number[i + 1].ToString() + ")" + ")"; break;
                case 2: resultSolution += "(" + number[i].ToString() + "x" + number[i + 1].ToString() + ")" + ")"; break;
                case 3: resultSolution += "(" + number[i].ToString() + "÷" + number[i + 1].ToString() + ")" + ")"; break;
            }

            switch (k)
            {
                case 0: 
                    resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    resultSolution = "(" + number[i + 2].ToString() + "+" + resultSolution;
                    if (w == 0)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    break;
                case 1:
                    if (j == 2 || j == 3)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    resultSolution = "(" + number[i + 2].ToString() + "-" + resultSolution;
                    if (w == 0)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    break;
                case 2:
                    if (j == 2 || j == 3)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    resultSolution = "(" + number[i + 2].ToString() + "x" + resultSolution;
                    if (w != 3)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    break;
                case 3:
                    resultSolution = "(" + number[i + 2].ToString() + "÷" + resultSolution;
                    if (w != 3)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    break;
            }

            switch (w)
            {
                case 0: resultSolution = number[i + 3].ToString() + "+" + resultSolution; break;
                case 1: resultSolution = number[i + 3].ToString() + "-" + resultSolution; break;
                case 2: resultSolution = number[i + 3].ToString() + "x" + resultSolution; break;
                case 3: resultSolution = number[i + 3].ToString() + "÷" + resultSolution; break;
            }

            resultSolution += "=24";
            return resultSolution;
        }

        private string PrintTheResultSum2(int i, int j, int k, int w, string resultSolution, List<double> number)
        {
            switch (j)
            {
                case 0: resultSolution += "(" + "(" + number[i].ToString() + "+" + number[i + 1].ToString() + ")"; break;
                case 1: resultSolution += "(" + "(" + number[i].ToString() + "-" + number[i + 1].ToString() + ")"; break;
                case 2: resultSolution += "(" + "(" + number[i].ToString() + "x" + number[i + 1].ToString() + ")"; break;
                case 3: resultSolution += "(" + "(" + number[i].ToString() + "÷" + number[i + 1].ToString() + ")"; break;
            }

            switch (k)
            {
                case 0: resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    resultSolution += "+" + number[i + 2].ToString() + ")";
                    if (w == 0 || w == 1)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    break;
                case 1: resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    resultSolution += "-" + number[i + 2].ToString() + ")";
                    if (w == 0 || w == 1)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    break;
                case 2:
                    if (j == 2 || j == 3)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                        resultSolution += "x" + number[i + 2].ToString() + ")";
                    }
                    else
                    {
                        resultSolution += "x" + number[i + 2].ToString() + ")";
                    }
                    resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    break;
                case 3:
                    if (j == 2 || j == 3)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                        resultSolution += "÷" + number[i + 2].ToString() + ")";
                    }
                    else
                    {
                        resultSolution += "÷" + number[i + 2].ToString() + ")";
                    }
                    resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    break;
            }

            switch (w)
            {
                case 0: resultSolution = number[i + 3].ToString() + "+" + resultSolution; break;
                case 1: resultSolution = number[i + 3].ToString() + "-" + resultSolution; break;
                case 2: resultSolution = number[i + 3].ToString() + "x" + resultSolution; break;
                case 3: resultSolution = number[i + 3].ToString() + "÷" + resultSolution; break;
            }

            resultSolution += "=24";
            return resultSolution;
        }

        private string PrintTheResultSumOther(int i, int j, int k, int w, string resultSolution, List<double> number)
        {
            string resultSolution1 = "", resultSolution2 = "";
            switch (j)
            {
                case 0: resultSolution1 += "(" + number[i].ToString() + "+" + number[i + 1].ToString() + ")"; break;
                case 1: resultSolution1 += "(" + number[i].ToString() + "-" + number[i + 1].ToString() + ")"; break;
                case 2: resultSolution1 += "(" + number[i].ToString() + "x" + number[i + 1].ToString() + ")"; break;
                case 3: resultSolution1 += "(" + number[i].ToString() + "÷" + number[i + 1].ToString() + ")"; break; 
            }

            switch (k)
            {
                case 0: resultSolution2 += "(" + number[i + 2].ToString() + "+" + number[i + 3].ToString() + ")"; break;
                case 1: resultSolution2 += "(" + number[i + 2].ToString() + "-" + number[i + 3].ToString() + ")"; break;
                case 2: resultSolution2 += "(" + number[i + 2].ToString() + "x" + number[i + 3].ToString() + ")"; break;
                case 3: resultSolution2 += "(" + number[i + 2].ToString() + "÷" + number[i + 3].ToString() + ")"; break;
            } 
            
            switch (w)
            {
                case 0: 
                    resultSolution1 = resultSolution1.Substring(1, resultSolution1.Length - 1);
                    resultSolution1 = resultSolution1.Substring(0, resultSolution1.Length - 1);
                    resultSolution2 = resultSolution2.Substring(1, resultSolution2.Length - 1);
                    resultSolution2 = resultSolution2.Substring(0, resultSolution2.Length - 1);
                    resultSolution = resultSolution1 + "+" + resultSolution2;
                    break;
                case 1: 
                    resultSolution1 = resultSolution1.Substring(1, resultSolution1.Length - 1);
                    resultSolution1 = resultSolution1.Substring(0, resultSolution1.Length - 1);
                    if (k == 2 || k == 3)
                    {
                        resultSolution2 = resultSolution2.Substring(1, resultSolution2.Length - 1);
                        resultSolution2 = resultSolution2.Substring(0, resultSolution2.Length - 1);
                    }
                    resultSolution = resultSolution1 + "-" + resultSolution2;
                    break;
                case 2:
                    if (j == 2 || j == 3)
                    {
                        resultSolution1 = resultSolution1.Substring(1, resultSolution1.Length - 1);
                        resultSolution1 = resultSolution1.Substring(0, resultSolution1.Length - 1);
                    }
                    if (k == 2 || k == 3)
                    {
                        resultSolution2 = resultSolution2.Substring(1, resultSolution2.Length - 1);
                        resultSolution2 = resultSolution2.Substring(0, resultSolution2.Length - 1);
                    }
                    resultSolution = resultSolution1 + "x" + resultSolution2;
                    break;
                case 3:
                    if (j == 2 || j == 3)
                    {
                        resultSolution1 = resultSolution1.Substring(1, resultSolution1.Length - 1);
                        resultSolution1 = resultSolution1.Substring(0, resultSolution1.Length - 1);
                    }
                    resultSolution = resultSolution1 + "÷" + resultSolution2;
                    break;
            }
            resultSolution += "=24";
            if (w == 1 && k ==1 || w==3 && k ==3)
            {
                resultSolution = "";
            }
            return resultSolution;
        }

        private string PrintTheResultSum(int i, int j, int k, int w, string resultSolution, List<double> number)
        {
            switch (j)
            {
                case 0: resultSolution += "(" + "(" + number[i].ToString() + "+" + number[i + 1].ToString() + ")"; break;
                case 1: resultSolution += "(" + "(" + number[i].ToString() + "-" + number[i + 1].ToString() + ")"; break;
                case 2: resultSolution += "(" + "(" + number[i].ToString() + "x" + number[i + 1].ToString() + ")"; break;
                case 3: resultSolution += "(" + "(" + number[i].ToString() + "÷" + number[i + 1].ToString() + ")"; break;
            }

            switch (k)
            {
                case 0: resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    resultSolution += "+" + number[i + 2].ToString() + ")";
                    if (w == 0 || w == 1)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    break;
                case 1: resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    resultSolution += "-" + number[i + 2].ToString() + ")";
                    if (w == 0 || w == 1)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    }
                    break;
                case 2:
                    if (j == 2 || j == 3)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                        resultSolution += "x" + number[i + 2].ToString() + ")";
                    }
                    else
                    {
                        resultSolution += "x" + number[i + 2].ToString() + ")";
                    }
                    resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    break;
                case 3:
                    if (j == 2 || j == 3)
                    {
                        resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                        resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                        resultSolution += "÷" + number[i + 2].ToString() + ")";
                    }
                    else
                    {
                        resultSolution += "÷" + number[i + 2].ToString() + ")";
                    }
                    resultSolution = resultSolution.Substring(1, resultSolution.Length - 1);
                    resultSolution = resultSolution.Substring(0, resultSolution.Length - 1);
                    break;
            }

            switch (w)
            {
                case 0: resultSolution += "+" + number[i + 3].ToString(); break;
                case 1: resultSolution += "-" + number[i + 3].ToString(); break;
                case 2: resultSolution += "x" + number[i + 3].ToString(); break;
                case 3: resultSolution += "÷" + number[i + 3].ToString(); break;
            }

            resultSolution += "=24";
            return resultSolution;
        }

        public List<int> InitialResult(string result)//返回比较string型的两个数组
        {
            List<int> judge = new List<int>();
                for (int i = 0; i < 5; i++)
                {
                    judge.Add(0);
                }
                char[] resultSplit = result.ToCharArray();
                for (int i = 0; i < resultSplit.Length; i++)
                {
                    string pr = resultSplit[i].ToString();
                    switch (pr)
                    {
                        case "+": judge[0]++; break;
                        case "-": judge[1]++; break;
                        case "x": judge[2]++; break;
                        case "÷": judge[3]++; break;
                        case "(": judge[4]++; break;
                        default: break;
                    }
                }
                return judge;
        }

        public List<string> JudgeTheResult(List<string> result)//去除内涵是一样但表达式有区别的冗余结果
        {
            int judgeNumber = 0;
            for (int k = 0; k < result.Count; k++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (InitialResult(result[k])[i] == InitialResult(result[j])[i])
                        {
                            judgeNumber++;
                        }
                    }
                    if (judgeNumber == 5)
                    {
                        result[k] = result[j];
                    }
                    judgeNumber = 0;
                }
            }
            
            return result;
        }
        
    }
}
