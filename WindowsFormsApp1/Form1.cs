using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private class Budget<T> : Budget
        {
            private readonly List<Budget> data;
            public Budget(List<Budget> data)
            {
                this.data = data;
            }
        }
        List<Budget> data;

        public static double portf_Gr = 10;
        public static double portf_Drop = 10;
        public static double portfolio = 1300;
        public static double labor_cost = 30.7;
        public static double employee = 24;
        public static double emplo_New = 22.5;
        public static double emplo_Effi = 85;
        public static double profit_Var = 36;
        public static double fee_Var = 5;
        public static double expend_Var = 6;
        public static double operCost_Var = 10;
        public static double saleIn_Var = 3.46;
        public static double inflation_Var = 2.9;
        public static double total_old = 0;
        public static double total_new = 0;
        public static int point_size = 9;
        public static int option = 1;

        public static int Fee_New_sum = 0;
        public static int Fee_Old_sum = 0;
        public static int Total_New_sum = 0;
        public static int Total_Old_sum = 0;
        public static int Total_sale_new_sum = 0;
        public static int Total_sale_old_sum = 0;
        public static int Total_Labor_new_sum = 0;
        public static int Total_Labor_old_sum = 0;
        public static int Total_Expand_new_sum = 0;
        public static int Total_Expand_old_sum = 0;
        public static int Total_Oper_Cost_new_sum = 0;
        public static int Total_Oper_Cost_old_sum = 0;

        private List<double> SaleOut_total;
        private List<double> SaleOut_total_old;
        private List<double> Labor_total;
        private List<double> Labor_total_old;
        private List<double> Sale_In_total;
        private List<double> Sale_In_total_old;
        private List<double> Total_fee;
        private List<double> Total_fee_New;
        private List<double> Total_fee_old;
        private List<double> Total_fee_old_sum;
        private List<double> Total_expend;
        private List<double> Total_expend_old;
        private List<double> Oper_Cost_total;
        private List<double> Oper_Cost_total_old;
        private List<double> Total_value;
        private List<double> Total_value_old;
        private List<double> tem1;
        private List<double> Total_Old;
        private List<double> Total_New;
        private List<double> Total_sale_new;
        private List<double> Total_sale_old;
        private List<double> Labor_total_new_line;
        private List<double> Labor_total_old_line;
        private List<double> Expand_total_old_line;
        private List<double> Expand_total_new_line;
        private List<double> Oper_Cost_total_old_line;
        private List<double> Oper_Cost_total_new_line;

        private class Budget
        {
            private double saleOut;        //  Medziagu pardavimo kaina
            private double labourSaleOut;  //  Paslaugu pardavimo kaina
            private double saleIn;         //  Prekiu savikaina
            private double fee;            //  Atliginimai
            private double expend;         //  Patalpu nuoma, nusidevejimas, paskolos
            private double operCost;       //  Veiklos sanaudos
            static double total_old;
            static double total_new;
            static double total_saleOut_old;
            static double total_saleOut_New;
            static double total_saleIn_old;
            static double total_saleIn_New;
            static double total_fee_old;
            static double total_fee_New;
            static double total_expend_old;
            static double total_expend_New;
            static double total_operCost_old;
            static double total_operCost_new;
            static double total_labor_New;
            static double total_labor_Old;

            public double Get_saleOut
            {
                get => saleOut;
                set { saleOut = value; }
            }
            public double SaleOut
            {
                get => saleOut;
                set { saleOut = value; }
            }
            public double Get_labourSaleOut
            {
                get => labourSaleOut;
                set { labourSaleOut = value; }
            }
            public double LabourSaleOut
            {
                get => labourSaleOut;
                set { labourSaleOut = value; }
            }
            public double Get_saleIn
            {
                get => saleIn;
                set { saleIn = value; }
            }
            public double SaleIn
            {
                get => saleIn;
                set { saleIn = value; }
            }
            public double Get_fee
            {
                get => fee;
                set { fee = value; }
            }
            public double Fee
            {
                get => fee;
                set { fee = value; }
            }
            public double Get_expend
            {
                get => expend;
                set { expend = value; }
            }
            public double Expend
            {
                get => expend;
                set { expend = value; }
            }
            public double Get_operCost
            {
                get => operCost;
                set { operCost = value; }
            }
            public double OperCost
            {
                get => operCost;
                set { operCost = value; }
            }
            public Budget()
            {
                saleOut = 0;
                labourSaleOut = 0;
                saleIn = 0;
                fee = 0;
                expend = 0;
                operCost = 0;
                total_old = 0;
                total_new = 0;
                total_saleOut_old = 0;
                total_saleOut_New = 0;
                total_saleIn_old = 0;
                total_saleIn_New = 0;
                total_fee_old = 0;
                total_fee_New = 0;
                total_expend_old = 0;
                total_expend_New = 0;
                total_operCost_old = 0;
                total_operCost_new = 0;
                total_labor_Old = 0;
                total_labor_New = 0;
            }
            public Budget(double a_saleOut, double a_labourSaleOut, double a_saleIn, double a_fee, double a_expend, double a_operCost)
            {
                saleOut = a_saleOut;
                labourSaleOut = a_labourSaleOut;
                saleIn = a_saleIn;
                fee = a_fee;
                expend = a_expend;
                operCost = a_operCost;
            }
            public Budget(Budget a)
            {
                saleOut = a.saleOut;
                labourSaleOut = a.labourSaleOut;
                saleIn = a.saleIn;
                fee = a.fee;
                expend = a.expend;
                operCost = a.operCost;
            }

            public double Get_total_sale() => Get_total_salein() * ((profit_Var / 100) + 1);
            public double Get_total_salein() => Get_saleIn * (1 - (portf_Drop / 100)) * ((portf_Gr / 100) + 1) * (saleIn_Var / 100 + 1);
            public double Get_total_labor_Cost() => (1 - (portf_Drop / 100)) * ((portf_Gr / 100) + 1) * (labor_cost * emplo_New * 21 * 8 * emplo_Effi / 100);
            public double Get_total_fee() => ((Get_fee / employee) * emplo_New * ((fee_Var / 100) + 1));
            public double Get_total_expend() => Get_expend * ((expend_Var / 100) + 1);
            public double Get_total_operCost() => Get_operCost * ((operCost_Var / 100) + (inflation_Var * .12) + 1);
            public double Get_total_value() => Get_total_sale() + Get_total_labor_Cost() - Get_total_salein() - Get_total_fee() - Get_total_expend() - Get_total_operCost();
            public double Get_total_margin() => (Get_total_value() / (Get_total_salein() + Get_total_fee() + Get_total_expend() + Get_total_operCost())) * 100;
            public double Total_old_margin()
            => ((Get_saleOut + Get_labourSaleOut - Get_saleIn - Get_fee - Get_expend - Get_operCost) / (Get_saleIn + Get_fee + Get_expend + Get_operCost)) * 100;
            public double Get_total_profit() => (Get_saleOut - Get_saleIn) / Get_saleIn * 100;
            public double Total_value_old() => Get_saleOut + Get_labourSaleOut - Get_saleIn - Get_fee - Get_expend - Get_operCost;
            public double Total_Old
            {
                get
                {
                    total_old += Total_value_old();
                    return total_old;
                }
            }
            public double Total_New
            {
                get
                {
                    total_new = total_new + Get_total_value();
                    return total_new;
                }
            }
            public double Total_saleOut_old
            {
                get
                {
                    total_saleOut_old += saleOut;
                    return total_saleOut_old;
                }
            }
            public double Total_saleOut_New
            {
                get
                {
                    total_saleOut_New += Get_total_sale();
                    return total_saleOut_New;
                }
            }
            public double Total_saleIn_old()
            {
                total_saleIn_old += Get_saleIn;
                return total_saleIn_old;
            }
            public double Total_saleIn_New()
            {
                total_saleIn_New += Get_total_salein();
                return total_saleIn_New;
            }
            public double Total_fee_old_sum
            {
                get
                {
                    total_fee_old += Get_fee;
                    return total_fee_old;
                }
            }
            public double Total_fee_New
            {
                get
                {
                    total_fee_New += Get_total_fee();
                    return total_fee_New;
                }
            }
            public double Total_labor_old
            {
                get
                {
                    total_labor_Old += LabourSaleOut;
                    return total_labor_Old;
                }
            }
            public double Total_labor_new
            {
                get
                {
                    total_labor_New += Get_total_labor_Cost();
                    return total_labor_New;
                }
            }
            public double Total_expend_old
            {
                get
                {
                    total_expend_old += Get_expend;
                    return total_expend_old;
                }
            }
            public double Total_expend_New
            {
                get
                {
                    total_expend_New += Get_total_expend();
                    return total_expend_New;
                }
            }
            public double Total_operCost_old
            {
                get
                {
                    total_operCost_old += Get_operCost;
                    return total_operCost_old;
                }
            }
            public double Total_operCost_new
            {
                get
                {
                    total_operCost_new += Get_total_operCost();
                    return total_operCost_new;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });

            cartesianChart1.LegendLocation = LegendLocation.Bottom;

            btnLoad.Enabled = false;
            btnReset.Enabled = false;
            radioButton7.Enabled = false;
            radioButton14.Enabled = false;
            groupBox3.Enabled = false;
            label84.Enabled = false;
        }
        private void btn_Read_Click(object sender, EventArgs e)
        {
            data = new List<Budget>();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File (*.txt)|*.txt| All file (*.*)|*,*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                using (var reader = File.OpenText(ofd.FileName))
                {
                    if (!reader.EndOfStream) reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] items = line.Split(',');
                        Budget can = new Budget
                        {
                            SaleOut = Convert.ToDouble(items[0]),        //  Medziagu pardavimo kaina
                            LabourSaleOut = Convert.ToDouble(items[1]),  //  Paslaugu pardavimo kaina
                            SaleIn = Convert.ToDouble(items[2]),         //  Prekiu savikaina
                            Fee = Convert.ToDouble(items[3]),            //  Atliginimai
                            Expend = Convert.ToDouble(items[4]),         //  Patalpu nuoma, nusidevejimas, paskolos
                            OperCost = Convert.ToDouble(items[5])
                        };
                        data.Add(can);
                    }
                }
            }
            else _ = MessageBox.Show("File no selected\nClick Load and Reset Button!", "Alert");
            btn_Read.Enabled = false;
            btnLoad.Enabled = true;
        }
        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            btnReset.Enabled = true;
            radioButton7.Enabled = true;
            radioButton14.Enabled = true;
            label84.Enabled = true;


            Budget value = new Budget<Budget>(data);

            Total_value = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_value.Add(value.Get_total_value());
            }

            Total_value_old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_value_old.Add(value.Total_value_old());
            }

            SaleOut_total = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                SaleOut_total.Add(value.Get_total_sale());
            }

            SaleOut_total_old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                SaleOut_total_old.Add(value.Get_saleOut);
            }

            Labor_total = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Labor_total.Add(value.Get_total_labor_Cost());
            }

            Labor_total_old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Labor_total_old.Add(value.Get_labourSaleOut);
            }

            Sale_In_total = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Sale_In_total.Add(value.Get_total_salein());
            }

            Sale_In_total_old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Sale_In_total_old.Add(value.Get_saleIn);
            }

            Total_fee = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_fee.Add(value.Get_total_fee());
            }

            Total_fee_old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_fee_old.Add(value.Get_fee);
            }

            Total_expend = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_expend.Add(value.Get_total_expend());
            }

            Total_expend_old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_expend_old.Add(value.Get_expend);
            }

            Oper_Cost_total = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Oper_Cost_total.Add(value.Get_total_operCost());
            }

            Oper_Cost_total_old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Oper_Cost_total_old.Add(value.Get_operCost);
            }

            Total_Old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_Old.Add(value.Total_Old);
            }
            for (int i = 0; i < data.Count; i++)
            {
                Total_Old_sum = (int)Total_Old[i];
            }

            Total_New = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_New.Add(value.Total_New);
            }
            for (int i = 0; i < data.Count; i++)
            {
                Total_New_sum = (int)Total_New[i];
            }

            Total_fee_old_sum = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_fee_old_sum.Add(value.Total_fee_old_sum);
            }
            for (int i = 0; i < Total_fee_old_sum.Count; i++)
            {
                Fee_Old_sum = (int)Total_fee_old_sum[i];
            }
            Total_fee_New = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_fee_New.Add(value.Total_fee_New);
            }
            for (int i = 0; i < Total_fee_New.Count; i++)
            {
                Fee_New_sum = (int)Total_fee_New[i];
            }

            Total_sale_new = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_sale_new.Add(value.Total_saleOut_New);
            }
            for (int i = 0; i < Total_sale_new.Count; i++)
            {
                Total_sale_new_sum = (int)Total_sale_new[i];
            }
            Total_sale_old = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_sale_old.Add(value.Total_saleOut_old);
            }
            for (int i = 0; i < Total_sale_old.Count; i++)
            {
                Total_sale_old_sum = (int)Total_sale_old[i];
            }

            Labor_total_new_line = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Labor_total_new_line.Add(value.Total_labor_new);
            }
            for (int i = 0; i < Labor_total_new_line.Count; i++)
            {
                Total_Labor_new_sum = (int)Labor_total_new_line[i];
            }
            Labor_total_old_line = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Labor_total_old_line.Add(value.Total_labor_old);
            }
            for (int i = 0; i < Labor_total_old_line.Count; i++)
            {
                Total_Labor_old_sum = (int)Labor_total_old_line[i];
            }

            Expand_total_new_line = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Expand_total_new_line.Add(value.Total_expend_New);
            }
            for (int i = 0; i < Expand_total_new_line.Count; i++)
            {
                Total_Expand_new_sum = (int)Expand_total_new_line[i];
            }
            Expand_total_old_line = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Expand_total_old_line.Add(value.Total_expend_old);
            }
            for (int i = 0; i < Expand_total_old_line.Count; i++)
            {
                Total_Expand_old_sum = (int)Expand_total_old_line[i];
            }

            Oper_Cost_total_new_line = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Oper_Cost_total_new_line.Add(value.Total_operCost_new);
            }
            for (int i = 0; i < Oper_Cost_total_new_line.Count; i++)
            {
                Total_Oper_Cost_new_sum = (int)Oper_Cost_total_new_line[i];
            }
            Oper_Cost_total_old_line = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Oper_Cost_total_old_line.Add(value.Total_operCost_old);
            }
            for (int i = 0; i < Oper_Cost_total_old_line.Count; i++)
            {
                Total_Oper_Cost_old_sum = (int)Oper_Cost_total_old_line[i];
            }

            tem1 = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                tem1.Add(0);
            }

            label74.Text = Convert.ToString(Fee_Old_sum);
            label73.Text = Convert.ToString(Fee_New_sum);
            label72.Text = Convert.ToString(Fee_New_sum - Fee_Old_sum);
            double tf = ((Fee_New_sum - Fee_Old_sum) / (double)Fee_Old_sum) * 100;
            tf = Math.Round(tf, 2);
            label68.Text = Convert.ToString(tf);

            label42.Text = Convert.ToString(Total_Old_sum);
            label41.Text = Convert.ToString(Total_New_sum);
            label40.Text = Convert.ToString(Total_New_sum - Total_Old_sum);
            double tn = ((Total_New_sum - Total_Old_sum) / (double)Total_Old_sum) * 100;
            tn = Math.Round(tn, 2);
            label36.Text = Convert.ToString(tn);

            label66.Text = Convert.ToString(Total_sale_old_sum);
            label65.Text = Convert.ToString(Total_sale_new_sum);
            label64.Text = Convert.ToString(Total_sale_new_sum - Total_sale_old_sum);
            double ts = ((Total_sale_new_sum - Total_sale_old_sum) / (double)Total_sale_old_sum) * 100;
            ts = Math.Round(ts, 2);
            label60.Text = Convert.ToString(ts);

            label58.Text = Convert.ToString(Total_Labor_old_sum);
            label57.Text = Convert.ToString(Total_Labor_new_sum);
            label56.Text = Convert.ToString(Total_Labor_new_sum - Total_Labor_old_sum);
            double tl = ((Total_Labor_new_sum - Total_Labor_old_sum) / (double)Total_Labor_old_sum) * 100;
            tl = Math.Round(tl, 2);
            label52.Text = Convert.ToString(tl);

            label82.Text = Convert.ToString(Total_Expand_old_sum);
            label81.Text = Convert.ToString(Total_Expand_new_sum);
            label80.Text = Convert.ToString(Total_Expand_new_sum - Total_Expand_old_sum);
            double te = ((Total_Expand_new_sum - Total_Expand_old_sum) / (double)Total_Expand_old_sum) * 100;
            te = Math.Round(te, 2);
            label76.Text = Convert.ToString(te);

            label50.Text = Convert.ToString(Total_Oper_Cost_old_sum);
            label49.Text = Convert.ToString(Total_Oper_Cost_new_sum);
            label48.Text = Convert.ToString(Total_Oper_Cost_new_sum - Total_Oper_Cost_old_sum);
            double to = ((Total_Oper_Cost_new_sum - Total_Oper_Cost_old_sum) / (double)Total_Oper_Cost_old_sum) * 100;
            to = Math.Round(to, 2);
            label44.Text = Convert.ToString(to);

            label98.Text = Convert.ToString(Total_sale_old_sum + Total_Labor_old_sum);
            label97.Text = Convert.ToString(Total_sale_new_sum + Total_Labor_new_sum);
            label96.Text = Convert.ToString(Total_sale_new_sum + Total_Labor_new_sum - Total_sale_old_sum + Total_Labor_old_sum);
            double tv = ((Total_sale_new_sum + Total_Labor_new_sum - Total_sale_old_sum - Total_Labor_old_sum) / ((double)Total_sale_old_sum + (double)Total_Labor_old_sum)) * 100;
            tv = Math.Round(tv, 2);
            label92.Text = Convert.ToString(tv);

            if (option == 1)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Profit amounts ",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                    Values = new ChartValues<double>(Total_New),
                },
                new LineSeries
                {
                    Title = "",
                    PointGeometry = null,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)),
                    Values = new ChartValues<double>(tem1)
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_Old),
                },
            };


            }
            if (option == 0)
            {

                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Profit amounts",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                    Values = new ChartValues<double>(Total_value),
                },
                new LineSeries
                {
                    Title = "",
                    PointGeometrySize = 0,
                    PointGeometry = null,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)),
                    Values = new ChartValues<double>(tem1),
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_value_old),
                },
            };
            }


        }
        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
        }
        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            portf_Gr = Convert.ToDouble(numericUpDown1.Value);
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            portf_Drop = Convert.ToDouble(numericUpDown2.Value);
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            labor_cost = Convert.ToDouble(numericUpDown3.Value);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            portfolio = Convert.ToDouble(textBox1.Text);
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            employee = Convert.ToDouble(numericUpDown4.Value);
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            emplo_New = Convert.ToDouble(numericUpDown5.Value);
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            profit_Var = Convert.ToDouble(numericUpDown6.Value);
        }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            emplo_Effi = Convert.ToDouble(numericUpDown7.Value);
        }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            point_size = Convert.ToInt16(numericUpDown8.Value);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            operCost_Var = Convert.ToDouble(textBox2.Text);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            fee_Var = Convert.ToDouble(textBox3.Text);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            expend_Var = Convert.ToDouble(textBox4.Text);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            inflation_Var = Convert.ToDouble(textBox5.Text);
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            saleIn_Var = Convert.ToDouble(textBox6.Text);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cartesianChart1.Visible = true;
            groupBox2.Enabled = false;
            groupBox1.Enabled = false;
        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (option == 0)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Profit amounts",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                    Values = new ChartValues<double>(Total_value),
                },
                new LineSeries
                {
                    Title = "",
                    PointGeometrySize = 0,
                    PointGeometry = null,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)),
                    Values = new ChartValues<double>(tem1),
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_value_old),
                },
            };
            }
            if (option == 1)
            {

                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Profit amounts",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                    Values = new ChartValues<double>(Total_New),
                },
                new LineSeries
                {
                    Title = "",
                    PointGeometry = null,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)),
                    Values = new ChartValues<double>(tem1)
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_Old),
                },
            };
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (option == 0)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Operating costs",
                    Values = new ChartValues<double>(Oper_Cost_total),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Oper_Cost_total_old),
                },
            };
            }
            if (option == 1)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Operating costs",
                    Values = new ChartValues<double>(Oper_Cost_total_new_line),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Oper_Cost_total_old_line),
                },
            };
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (option == 0)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Labour sale out",
                    Values = new ChartValues<double>(Labor_total),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },

                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Labor_total_old),
                },
            };
            }
            if (option == 1)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Labour sale out",
                    Values = new ChartValues<double>(Labor_total_new_line),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },

                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Labor_total_old_line),
                },
            };
            }

        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (option == 0)
            {
                cartesianChart1.Series = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "Sale in parts",
                    Values = new ChartValues<double>(SaleOut_total),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(SaleOut_total_old),
                },
            };

            }
            if (option == 1)
            {
                cartesianChart1.Series = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "Sale in parts",
                    Values = new ChartValues<double>(Total_sale_new),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_sale_old),
                },
            };

            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (option == 0)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Salary expenses",
                    Values = new ChartValues<double>(Total_fee),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_fee_old),
                },
            };
            }

            if (option == 1)
            {

                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Salary expenses",
                    Values = new ChartValues<double>(Total_fee_New),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_fee_old_sum),
                },
            };
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (option == 0)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Expansion, rent, leasing",
                    Values = new ChartValues<double>(Total_expend),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_expend_old),
                },
            };
            }
            if (option == 1)
            {
                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Expansion, rent, leasing",
                    Values = new ChartValues<double>(Expand_total_new_line),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Amounts submitted",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Expand_total_old_line),
                }
            };
            }
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            SaleOut_total_old = new List<double> { 0 };
            Labor_total = new List<double> { 0 };
            SaleOut_total = new List<double> { 0 };
            Labor_total_old = new List<double> { 0 };
            Sale_In_total = new List<double> { 0 };
            Sale_In_total_old = new List<double> { 0 };
            Total_fee = new List<double> { 0 };
            Total_fee_old = new List<double> { 0 };
            Total_expend = new List<double> { 0 };
            Total_expend_old = new List<double> { 0 };
            Oper_Cost_total = new List<double> { 0 };
            Oper_Cost_total_old = new List<double> { 0 };
            Total_value = new List<double> { 0 };
            Total_value_old = new List<double> { 0 };
            tem1 = new List<double> { 0 };
            Total_Old = new List<double> { 0 };
            Total_New = new List<double> { 0 };
            Labor_total_old_line = new List<double> { 0 };
            Labor_total_new_line = new List<double> { 0 };
            Total_sale_old = new List<double> { 0 };
            Total_sale_new = new List<double> { 0 };
            Total_fee_New = new List<double> { 0 };
            Total_fee_old_sum = new List<double> { 0 };
            Expand_total_old_line = new List<double> { 0 };
            Expand_total_new_line = new List<double> { 0 };
            Oper_Cost_total_new_line = new List<double> { 0 };
            Oper_Cost_total_old_line = new List<double> { 0 };

            tem1.Clear();
            Total_New.Clear();
            Total_Old.Clear();
            Total_fee_New.Clear();
            Total_fee_old_sum.Clear();
            Total_sale_old.Clear();
            Total_sale_new.Clear();
            Labor_total.Clear();
            SaleOut_total.Clear();
            Labor_total_old.Clear();
            Sale_In_total.Clear();
            Sale_In_total_old.Clear();
            Total_fee.Clear();
            Total_fee_old.Clear();
            Total_expend.Clear();
            Total_expend_old.Clear();
            Oper_Cost_total.Clear();
            Oper_Cost_total_old.Clear();
            Total_value.Clear();
            Total_value_old.Clear();
            SaleOut_total_old.Clear();
            Labor_total_old_line.Clear();
            Labor_total_new_line.Clear();
            Expand_total_old_line.Clear();
            Expand_total_new_line.Clear();
            Oper_Cost_total_old_line.Clear();
            Oper_Cost_total_new_line.Clear();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            option = 1;
            btnLoad.Enabled = false;
            radioButton14.Checked = false;
            radioButton7.Checked = false;
            radioButton7.Enabled = false;
            radioButton14.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            btn_Read.Enabled = true;
            label84.Enabled = false;

            Fee_Old_sum = 0;
            Fee_New_sum = 0;
            Total_New_sum = 0;
            Total_Old_sum = 0;
            Total_sale_new_sum = 0;
            Total_sale_old_sum = 0;
            Total_Labor_new_sum = 0;
            Total_Labor_old_sum = 0;
            Total_Expand_new_sum = 0;
            Total_Expand_old_sum = 0;
            Total_Oper_Cost_new_sum = 0;
            Total_Oper_Cost_old_sum = 0;

            cartesianChart1.Series.Clear();
            Oper_Cost_total_new_line.Clear();
            Oper_Cost_total_old_line.Clear();
            Expand_total_new_line.Clear();
            Expand_total_old_line.Clear();
            Total_fee_New.Clear();
            Total_fee_old_sum.Clear();
            SaleOut_total_old.Clear();
            Labor_total_old_line.Clear();
            Labor_total_new_line.Clear();
            Total_sale_old.Clear();
            Total_sale_new.Clear();
            Labor_total.Clear();
            SaleOut_total.Clear();
            Labor_total_old.Clear();
            Sale_In_total.Clear();
            Sale_In_total_old.Clear();
            Total_fee.Clear();
            Total_fee_old.Clear();
            Total_expend.Clear();
            Total_expend_old.Clear();
            Oper_Cost_total.Clear();
            Oper_Cost_total_old.Clear();
            Total_value.Clear();
            Total_value_old.Clear();
            tem1.Clear();
            Total_Old.Clear();
            Total_New.Clear();

            label74.Text = Convert.ToString(Fee_Old_sum);
            label73.Text = Convert.ToString(Fee_New_sum);
            label72.Text = Convert.ToString(Fee_New_sum - Fee_Old_sum);
            label68.Text = Convert.ToString(0);

            label42.Text = Convert.ToString(Total_Old_sum);
            label41.Text = Convert.ToString(Total_New_sum);
            label40.Text = Convert.ToString(Total_New_sum - Total_Old_sum);
            label36.Text = Convert.ToString(0);

            label66.Text = Convert.ToString(Total_sale_old_sum);
            label65.Text = Convert.ToString(Total_sale_new_sum);
            label64.Text = Convert.ToString(Total_sale_new_sum - Total_sale_old_sum);
            label60.Text = Convert.ToString(0);

            label58.Text = Convert.ToString(Total_Labor_old_sum);
            label57.Text = Convert.ToString(Total_Labor_new_sum);
            label56.Text = Convert.ToString(Total_Labor_new_sum - Total_Labor_old_sum);
            label52.Text = Convert.ToString(0);

            label82.Text = Convert.ToString(Total_Expand_old_sum);
            label81.Text = Convert.ToString(Total_Expand_new_sum);
            label80.Text = Convert.ToString(Total_Expand_new_sum - Total_Expand_old_sum);
            label76.Text = Convert.ToString(0);

            label50.Text = Convert.ToString(Total_Oper_Cost_old_sum);
            label49.Text = Convert.ToString(Total_Oper_Cost_new_sum);
            label48.Text = Convert.ToString(Total_Oper_Cost_new_sum - Total_Oper_Cost_old_sum);
            label44.Text = Convert.ToString(0);

            label98.Text = Convert.ToString(Total_sale_old_sum + Total_Labor_old_sum);
            label97.Text = Convert.ToString(Total_sale_new_sum + Total_Labor_new_sum);
            label96.Text = Convert.ToString(Total_sale_new_sum + Total_Labor_new_sum - Total_sale_old_sum + Total_Labor_old_sum);
            label92.Text = Convert.ToString(0);
            btnReset.Enabled = false;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            option = 0;
            radioButton1.Checked = true;
        }
        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            option = 1;
            radioButton1.Checked = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
