using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
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
        public static int point_size = 5;
            static double total_operCost_New;

        public static List<double> SaleOut_total;
        public static List<double> SaleOut_total_old;
        public static List<double> Labor_total;
        public static List<double> Labor_total_old;
        public static List<double> Sale_In_total;
        public static List<double> Sale_In_total_old;
        public static List<double> Total_fee;
        public static List<double> Total_fee_old;
        public static List<double> Total_expend;
        public static List<double> Total_expend_old;
        public static List<double> Oper_Cost_total;
        public static List<double> Oper_Cost_total_old;
        public static List<double> Total_value;
        public static List<double> Total_value_old;
        public static List<double> tem1;
        public static List<double> Total_Old;
        public static List<double> Total_New;

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


            public object numericUpDown1;
            public object numericUpDown2;
            public object numericUpDown3;
            public object numericUpDown4;
            public object numericUpDown5;
            public object numericUpDown6;
            public object numericUpDown7;
            public object numericUpDown8;
            public object label28;

            public object textBox1;
            public object textBox2;
            public object textBox3;
            public object textBox4;
            public object textBox5;
            public object textBox6;


            public object radioButton1_CheckedChanged_1;
            public object btn_Read_Click;


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
                total_operCost_New = 0;
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
            public double Total_saleOut_old()
            {
                total_saleOut_old += saleOut;
                return total_saleOut_old;
            }
            public double Total_saleOut_New()
            {
                total_saleOut_New += Get_total_sale();
                return total_saleOut_New;
            }
            public double Total_saleIn_old()
            {
                total_saleIn_old +=Get_saleIn;
                return total_saleIn_old;
            }
            public double Total_saleIn_New()
            {
                total_saleIn_New += Get_total_salein();
                return total_saleIn_New;
            }
            public double Total_fee_old()
            {
                total_fee_old += Get_fee;
                return total_fee_old;
            }
            public double Total_fee_New()
            {
                total_fee_New += Get_total_fee();
                return total_fee_New;
            }
            public double Total_expend_old()
            {
                total_expend_old +=Get_expend;
                return total_expend_old;
            }
            public double Total_expend_New()
            {
                total_expend_New += Get_total_expend();
                return total_expend_New;
            }
            public double Total_operCost_old()
            {
                total_operCost_old += Get_expend;
                return total_operCost_old;
            }
            public double Total_operCost_New
            {
                get
                {
                return total_operCost_New;

                }
                set
                {

                total_operCost_New += Get_total_expend();
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
        }
        private void btn_Read_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = true;

            List<Budget> data = new List<Budget>();

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
                        //string line = reader.ReadLine();
                        //string[] items = line.Split(',');
                        //Budget can = new Budget();
                        //can.SaleOut = Convert.ToDouble(items[0]);        //  Medziagu pardavimo kaina
                        //can.LabourSaleOut = Convert.ToDouble(items[1]);  //  Paslaugu pardavimo kaina
                        //can.SaleIn = Convert.ToDouble(items[2]);         //  Prekiu savikaina
                        //can.Fee = Convert.ToDouble(items[3]);            //  Atliginimai
                        //can.Expend = Convert.ToDouble(items[4]);         //  Patalpu nuoma, nusidevejimas, paskolos
                        //can.OperCost = Convert.ToDouble(items[5]);
                        //data.Add(can);
                    }
                }
            }
            else MessageBox.Show("File no selected");
        }
        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox1.Enabled = true;

            List<Budget> data = new List<Budget>();

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
                        Budget can = new Budget();
                        can.SaleOut = Convert.ToDouble(items[0]);        //  Medziagu pardavimo kaina
                        can.LabourSaleOut = Convert.ToDouble(items[1]);  //  Paslaugu pardavimo kaina
                        can.SaleIn = Convert.ToDouble(items[2]);        //  Prekiu savikaina
                        can.Fee = Convert.ToDouble(items[3]);          //  Atliginimai
                        can.Expend = Convert.ToDouble(items[4]);         //  Patalpu nuoma, nusidevejimas, paskolos
                        can.OperCost = Convert.ToDouble(items[5]);
                        data.Add(can);
                    }
                }
            }
            else MessageBox.Show("File no selected");

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
            Total_New = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                value = data[i];
                Total_New.Add(value.Total_New);
            }
            tem1 = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                tem1.Add(0);
            }

            label29.Text = Convert.ToString(total_operCost_New);


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
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Prognozuojamas pelnas",
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
                    Title = "Pateiktos vertes",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_value_old),
                },
            };
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Veiklos sanaudos",
                    Values = new ChartValues<double>(Oper_Cost_total),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Pateiktos vertės",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Oper_Cost_total_old),
                },
            };
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Paslaugų pajamos",
                    Values = new ChartValues<double>(Labor_total),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },

                new LineSeries
                {
                    Title = "Pateiktos vertes",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Labor_total_old),
                },
            };
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Atsargų pirkimo išlaidos",
                    Values = new ChartValues<double>(Sale_In_total),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Pateiktos vertes",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Sale_In_total_old),
                },
            };
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Darbo užmokesčio sanaudos",
                    Values = new ChartValues<double>(Total_fee),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Pateiktos vertes",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_fee_old),
                },
            };
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Plėtros, nuomos, lizingo sanaudos",
                    Values = new ChartValues<double>(Total_expend),
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Circle,
                },
                new LineSeries
                {
                    Title = "Pateiktos vertes",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_expend_old),
                },
            };
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Prognozuojamos vertes",
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
                    Title = "Pateiktos vertes",
                    PointGeometrySize = point_size,
                    PointGeometry = DefaultGeometries.Square,
                    Values = new ChartValues<double>(Total_Old),
                },
            };
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            SaleOut_total_old = new List<double>{ 0 };
            Labor_total = new List<double>{ 0 };
            SaleOut_total = new List<double>{ 0 };
            Labor_total_old = new List<double>{ 0 };
            Sale_In_total = new List<double>{ 0 };
            Sale_In_total_old = new List<double>{ 0 };
            Total_fee = new List<double>{ 0 };
            Total_fee_old = new List<double>{ 0 };
            Total_expend = new List<double>{ 0 };
            Total_expend_old = new List<double>{ 0 };
            Oper_Cost_total = new List<double>{ 0 };
            Oper_Cost_total_old = new List<double>{ 0 };
            Total_value = new List<double>{ 0 };
            Total_value_old = new List<double>{ 0 };
            tem1 = new List<double>{ 0 };
            Total_Old = new List<double>{ 0 };
            Total_New = new List<double> { 0 };
            SaleOut_total_old.Clear();
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
        }
    }
}
           