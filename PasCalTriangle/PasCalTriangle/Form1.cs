using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PasCalTriangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class PascalTriangle
        {
            #region Output
            /// <summary>
            /// 輸出n層巴斯卡三角形
            /// </summary>
            /// <param name="n">層級</param>
            /// <param name="output">輸出</param>
            public void CreatePascal(int n, TextBox output)
            {
                if (n >= 0)
                {
                    output.TextAlign = HorizontalAlignment.Center; //把textbox設置為置中（比較整齊）
                    int[,] Pascal = CreatePascalTri(n);            //製造巴斯卡三角形矩陣
                    int Z = calcBits(Pascal);                      //計算最大位元
                    string Str = string.Empty;                     //建立一變數
                    Str = Str.PadLeft(Z, '0');                     //用來補0
                    int i = 0, j = i;
                    int now_Step = 0;
                    while (now_Step != n)
                    {
                        for (i = now_Step, j = 0; i >= 0 && j <= now_Step; i--, j++)
                        {
                            output.Text += Pascal[i, j].ToString(Str) + " ";
                        }
                        output.Text += "\r\n";
                        now_Step++;
                    }
                }
            }

            /// <summary>
            /// 輸出n層巴斯卡三角形
            /// </summary>
            /// <param name="n">層級</param>
            /// <param name="output">輸出</param>
            public void CreatePascal_AnotherVersion(int n, TextBox output)
            {
                if (n >= 0)
                {
                    output.TextAlign = HorizontalAlignment.Center; //把textbox設置為置中（比較整齊）
                    int Z = calcBits(n);                      //計算最大位元
                    string Str = string.Empty;                     //建立一變數
                    Str = Str.PadLeft(Z, '0');                     //用來補0
                    int i = 0, j = i;
                    int now_Step = 0;
                    while (now_Step != n)
                    {
                        for (i = now_Step, j = 0; i >= 0 && j <= now_Step; i--, j++)
                        {
                            output.Text += pascal(i,j).ToString(Str) + " ";
                        }
                        output.Text += "\r\n";
                        now_Step++;
                    }
                }
            }
            #endregion
            #region CalcBits
            /// <summary>
            /// 計算在n層巴斯卡三角形裡面出現最大的數值為幾位數
            /// </summary>
            /// <param name="Pascal">巴斯卡三角形矩陣</param>
            /// <returns>最大位數</returns>
            private int calcBits(int[,] Pascal)
            {
                int max = 1;
                for (int i = 0; i < Pascal.GetLength(0); i++)
                {
                    for (int j = 0; j < Pascal.GetLength(1) - i - 1; j++)
                    {
                        if (max < Pascal[i, j].ToString().Length)
                            max = Pascal[i, j].ToString().Length;
                    }
                }
                return max;
            }
            /// <summary>
            /// 計算在n層巴斯卡三角形裡面出現最大的數值為幾位數
            /// </summary>
            /// <param name="n">[n,m]位置</param>
            /// <param name="m">[n,m]位置</param>
            /// <returns>最大位數</returns>
            private int calcBits(int n)
            {
                int max = 1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n-i-1; j++) 
                    {
                        if (max < pascal(i,j).ToString().Length)
                            max = pascal(i, j).ToString().Length;
                    }
                }
                return max;
            }
            #endregion
            #region CalcPascalTriangle
            /// <summary>
            /// 整個class的核心，用來創建巴斯卡三角形矩陣
            /// </summary>
            /// <param name="n">層級</param>
            /// <returns>巴斯卡三角形矩陣</returns>
            private int[,] CreatePascalTri(int n)
            {
                int[,] Tri = new int[n + 1, n + 1];
                for (int i = 0; i < Tri.GetLength(0); i++)
                { Tri[0, i] = 1; Tri[i, 0] = 1; }
                for (int i = 1; i < Tri.GetLength(0); i++)
                {
                    for (int j = 1; j < Tri.GetLength(1); j++)
                    {
                        Tri[i, j] = Tri[i - 1, j] + Tri[i, j - 1];
                    }
                }
                return Tri;
            }
            /// <summary>
            /// 用遞迴產生巴斯卡三角形的值
            /// </summary>
            /// <param name="n">[n,m]位置</param>
            /// <param name="m">[n,m]位置</param>
            /// <returns>該位置的值</returns>
            private int pascal(int n, int m)
            {
                if ((m == 0 || n == 0))
                {
                    return 1;
                }
                else
                {
                    return pascal(n - 1, m) + pascal(n, m - 1);
                }
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            int n = 0;
            int.TryParse(textBox2.Text, out n);
            PascalTriangle pascal = new PascalTriangle();
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            pascal.CreatePascal_AnotherVersion(n, textBox1);
            sw.Stop();
            MessageBox.Show(string.Format("遞迴使用了{0}毫秒", sw.ElapsedMilliseconds.ToString()));
            sw.Reset();
            sw.Start();
            pascal.CreatePascal(n, textBox1);
            sw.Stop();
            MessageBox.Show(string.Format("矩陣使用了{0}毫秒", sw.ElapsedMilliseconds.ToString()));
        }
    }
}
