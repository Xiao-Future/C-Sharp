using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaculateCapacity
{
    class Caculate
    {
        int row, column;
        double[,] data;

        public Caculate(int rowNum, int columnNum)
        {
            row = rowNum;
            column = columnNum;
            data = new double[row, column];
        }

        public Caculate(double[,] members)
        {
            row = members.GetUpperBound(0) + 1;
            column = members.GetUpperBound(1) + 1;
            data = new double[row, column];
            Array.Copy(members, data, row * column);
        }

        public Caculate(double[] vector)
        {
            row = 1;
            column = vector.GetUpperBound(0)+1;
            data = new double[1, column];
            for (int i = 0; i < vector.Length; i++)
            {
                data[0, i] = vector[i];
            }
        }

        public int rowNum { get { return row; } }
        public int columnNum { get { return column; } }
        public double this [int r,int c]
        {
            get{ return data[r,c];} 
            set{data[r,c]=value;}
        }

         #region 转置
        /// <summary>
        /// 将矩阵转置，得到一个新矩阵（此操作不影响原矩阵）
        /// </summary>
        /// <param name="input">要转置的矩阵</param>
        /// <returns>原矩阵经过转置得到的新矩阵</returns>
        public static Caculate transpose(Caculate input)
        {
            double[,] inverseMatrix = new double[input.column, input.row];
            for (int r = 0; r < input.row; r++)           
                for (int c = 0; c < input.column; c++)                
                    inverseMatrix[c, r] = input[r, c];
            return new Caculate(inverseMatrix);
        }
        #endregion

        public static Caculate operator +(Caculate  a, Caculate b)
        {
            if (a.row != b.row || a.column != b.column)
                throw new Exception("矩阵维数不匹配。");
            Caculate result = new Caculate(a.row, a.column);
            for (int i = 0; i < a.row; i++)           
                for (int j = 0; j < a.column; j++)                
                    result[i, j] = a[i, j] + b[i, j];
            return result;
        }

        public static Caculate operator -(Caculate a, Caculate b)
        {
            return a + b * (-1);
        }

         public static Caculate operator *(Caculate matrix, double factor)
        {
            Caculate result = new Caculate(matrix.row, matrix.column);
            for (int i = 0; i < matrix.row; i++)            
                for (int j = 0; j < matrix.column; j++)               
                    matrix[i, j] = matrix[i, j] * factor;
            return matrix;
        }
        public static Caculate operator *(double factor,Caculate matrix)
        {
            return matrix * factor;
        }
        public static Caculate operator *(Caculate a, Caculate b)
        {
            if(a.column!=b.row)
                throw new Exception("矩阵维数不匹配。");
            Caculate result = new Caculate(a.row, b.column);
            for (int i = 0; i < a.row; i++)            
                for (int j = 0; j < b.column; j++)                
                    for (int k = 0; k < a.column; k++)                    
                        result[i, j] += a[i, k] * b[k, j];                 
            return result;
        }
        public static double MatrixValue(double[,] MatrixList, int Level)  //求得|A| 如果为0 说明不可逆
        {
            //计算行列式的方法
            //   a1 a2 a3
            //  b1 b2 b3
            //  c1 c2 c3
            // 结果为 a1·b2·c3+b1·c2·a3+c1·a2·b3-a3·b2·c1-b3·c2·a1-c3·a2·b1(注意对角线就容易记住了）
            double[,] dMatrix = new double[Level, Level];   //定义二维数组，行列数相同
            for (int i = 0; i < Level; i++)
                for (int j = 0; j < Level; j++)
                    dMatrix[i, j] = MatrixList[i, j];     //将参数的值，付给定义的数组

            double c, x;
            int k = 1;
            for (int i = 0, j = 0; i < Level && j < Level; i++, j++)
            {
                if (dMatrix[i, j] == 0)   //判断对角线上的数据是否为0
                {
                    int m = i;
                    for (; dMatrix[m, j] == 0; m++) ;  //如果对角线上数据为0，从该数据开始依次往后判断是否为0
                    if (m == Level)                      //当该行从对角线开始数据都为0 的时候 返回0
                        return 0;
                    else
                    {
                        // Row change between i-row and m-row
                        for (int n = j; n < Level; n++)
                        {
                            c = dMatrix[i, n];
                            dMatrix[i, n] = dMatrix[m, n];
                            dMatrix[m, n] = c;
                        }
                        // Change value pre-value
                        k *= (-1);
                    }
                }
                // Set 0 to the current column in the rows after current row
                for (int s = Level - 1; s > i; s--)
                {
                    x = dMatrix[s, j];
                    for (int t = j; t < Level; t++)
                        dMatrix[s, t] -= dMatrix[i, t] * (x / dMatrix[i, j]);
                }
            }
            double sn = 1;
            for (int i = 0; i < Level; i++)
            {
                if (dMatrix[i, i] != 0)
                    sn *= dMatrix[i, i];
                else
                    return 0;
            }
            return k * sn;
        }

        public static double[,] ReverseMatrix(double[,] dMatrix, int Level)
        {
            double dMatrixValue = MatrixValue(dMatrix, Level);
            if (dMatrixValue == 0) return null;       //A为该矩阵 若|A| =0 则该矩阵不可逆 返回空

            double[,] dReverseMatrix = new double[Level, 2 * Level];
            double x, c;
            // Init Reverse matrix
            for (int i = 0; i < Level; i++)     //创建一个矩阵（A|I） 以对其进行初等变换 求得其矩阵的逆
            {
                for (int j = 0; j < 2 * Level; j++)
                {
                    if (j < Level)
                        dReverseMatrix[i, j] = dMatrix[i, j];   //该 （A|I）矩阵前 Level列为矩阵A  后面为数据全部为0
                    else
                        dReverseMatrix[i, j] = 0;
                }
                dReverseMatrix[i, Level + i] = 1;
                //将Level+1行开始的Level阶 矩阵装换为单位矩阵 （起初的时候该矩阵都为0 现在在把对角线位置装换为1 ）
                //参考http://www.shuxuecheng.com/gaosuzk/content/lljx/wzja/12/12-6.htm
            }

            for (int i = 0, j = 0; i < Level && j < Level; i++, j++)
            {
                if (dReverseMatrix[i, j] == 0)   //判断一行对角线 是否为0
                {
                    int m = i;
                    for (; dMatrix[m, j] == 0; m++) ;
                    if (m == Level)
                        return null;  //某行对角线为0的时候 判断该行该数据所在的列在该数据后 是否为0 都为0 的话不可逆 返回空值
                    else
                    {
                        // Add i-row with m-row
                        for (int n = j; n < 2 * Level; n++)   //如果对角线为0 则该i行加上m行 m行为（初等变换要求对角线为1，0-->1先加上某行，下面在变1）
                            dReverseMatrix[i, n] += dReverseMatrix[m, n];
                    }
                }
                //  此时数据： 第二行加上第一行为第一行的数据
                //    1   1   3      1    1    0
                //    1   0   1      0    1    0
                //    4   2   1      0    0    1
                //
                // Format the i-row with "1" start
                x = dReverseMatrix[i, j];
                if (x != 1)                  //如果对角线元素不为1  执行以下
                {
                    for (int n = j; n < 2 * Level; n++)
                        if (dReverseMatrix[i, n] != 0)
                            dReverseMatrix[i, n] /= x;   //相除  使i行第一个数字为1
                }
                // Set 0 to the current column in the rows after current row
                for (int s = Level - 1; s > i; s--)         //该对角线数据为1 时，这一列其他数据 要转换为0
                {
                    x = dReverseMatrix[s, j];
                    // 第一次时
                    //    1      1   3      1    1    0
                    //    1      0   1      0    1    0
                    //   4(x)   2   1      0    0    1
                    //
                    for (int t = j; t < 2 * Level; t++)
                        dReverseMatrix[s, t] -= (dReverseMatrix[i, t] * x);
                    //第一个轮回   用第一行*4 减去第三行 为第三行的数据  依次类推
                    //     1      1   3      1    1    0
                    //    1      0   1      0    1    0
                    //    0(x)   -2  -11    -4   -4   1

                }
            }
            // Format the first matrix into unit-matrix
            for (int i = Level - 2; i >= 0; i--)
            //处理第一行二列的数据 思路如上 就是把除了对角线外的元素转换为0 
            {
                for (int j = i + 1; j < Level; j++)
                    if (dReverseMatrix[i, j] != 0)
                    {
                        c = dReverseMatrix[i, j];
                        for (int n = j; n < 2 * Level; n++)
                            dReverseMatrix[i, n] -= (c * dReverseMatrix[j, n]);
                    }
            }
            double[,] dReturn = new double[Level, Level];
            for (int i = 0; i < Level; i++)
                for (int j = 0; j < Level; j++)
                    dReturn[i, j] = dReverseMatrix[i, j + Level];
            //就是把Level阶的矩阵提取出来（减去原先为单位矩阵的部分）
            return dReturn;
        }
    }
}
