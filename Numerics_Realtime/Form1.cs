using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Numerics_Realtime.Properties;
using Steema.Numerics;
using Steema.Numerics.ChartHelpers;
using Steema.Numerics.Windows;
using Steema.TeeChart.Styles;

namespace Anomaly_TeeChart
{
    public partial class Form1 : Form
    {
        private readonly FastLine _series1 = new FastLine();
        private readonly FastLine _series3 = new FastLine();
        private readonly FastLine _series4 = new FastLine();
        private readonly FastLine _series5 = new FastLine();
        private readonly Points _series2 = new Points();
        private readonly PredictionEditor _predictionEditor = new PredictionEditor();


        public Form1()
        {

            void InitializeChart()
            {
                tChart1 = new Steema.TeeChart.TChart
                {
                    Dock = DockStyle.Fill
                };

                tChart1.Axes.Bottom.Grid.DrawEvery = 1;
                tChart1.Axes.Bottom.Grid.Visible = true;
                tChart1.Axes.Bottom.Labels.Angle = 90;
                tChart1.Legend.CheckBoxes = true;
                tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
                tChart1.Axes.Bottom.Grid.Visible = false;                
                splitContainer1.Panel2.Controls.Add(tChart1);
            }

            InitializeComponent();
            InitializeChart();
            ResetData();
        }

        private void CbVisible_CheckedChanged(object sender, EventArgs e)
        {
            _series4.Visible = ((CheckBox)sender).Checked;
            _series5.Visible = ((CheckBox)sender).Checked;
        }

        private void CbRight_CheckedChanged(object sender, EventArgs e)
        {
            _series4.VertAxis = ((CheckBox)sender).Checked ? VerticalAxis.Right : VerticalAxis.Left;
            _series5.VertAxis = ((CheckBox)sender).Checked ? VerticalAxis.Right : VerticalAxis.Left;
        }

        private void Calculate_Predictions(PredictionData pdictionData)
        {
            PredictionData predictionData;

            if(pdictionData.IsEmpty)
            {
                predictionData = _predictionEditor.GetPredictionData();
            }
            else
            {
                predictionData = pdictionData;
            }

            PredictionResult predictions = null;

            try
            {
                predictions = TeeChartHelper.Predictions_FromSeries(_series1, predictionData);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (predictions != null)
            {
                List<double> xvals;
                if (pdictionData.BestGuess == BestGuess.Projected)
                {
                    xvals = new List<double>();
                    var lastX = DateTime.FromOADate(_series1.XValues.Value.Take(_series1.Count).TakeLast(1).First());
                    var span = TimeSpan.FromMilliseconds(timer1.Interval);

                    for (var i = 0; i < predictionData.Horizon; i++)
                    {
                        lastX += span;
                        xvals.Add(lastX.ToOADate());
                    }
                }
                else
                {
                    xvals = _series1.XValues.Value.Take(_series1.Count).TakeLast(predictionData.Horizon).ToList();
                }

                //_series3.Clear();
                _series4.Clear();
                _series5.Clear();
                TeeChartHelper.Add_Predictions(_series1, _series3, _series4, _series5, predictions, xvals);

                if(pdictionData.BestGuess == BestGuess.None)
                {
                    MessageBox.Show($"BestWindowSize: {predictions.BestWindowSize}, MSE: {predictions.MSE}");
                }
                else
                {
                    lbestWindowSize.Text = predictions.BestWindowSize.ToString();
                    lMSE.Text = predictions.MSE.ToString();
                }
            }
        }

        private void Calculate_Anomalies()
        {
            int[] anomalies = null;

            try
            {
                anomalies = TeeChartHelper.Anomalies_FromSeries(_series1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (anomalies != null)
            {
                TeeChartHelper.Add_Anomalies(_series1, _series2, anomalies);
            }
        }

        private void ImportTo()
        {
            ClearChart();

            _series1.VertAxis = VerticalAxis.Left;
            _series2.VertAxis = VerticalAxis.Left;
            _series3.VertAxis = VerticalAxis.Left;
            _series4.VertAxis = VerticalAxis.Right;
            _series5.VertAxis = VerticalAxis.Right;

            _series1.Title = "Sample1";
            _series1.LinePen.Width = 3;
            _series3.LinePen.Transparency = 80;
            
            //_series3.XValues.Order = ValueListOrder.None;
            //_series3.YValues.Order = ValueListOrder.;

            tChart1.Series.Add(_series1);

            //if (rbAnomaly.Checked)
            //{
            _series2.Title = "Anomalies";
            tChart1.Series.Add(_series2);

            //}
            //else if (rbPrediction.Checked)
            //{
            _series3.Title = "Prediction";
            tChart1.Series.Add(_series3);
            //_series4.Title = "ConfidenceLowerBound";
            //tChart1.Series.Add(_series4);
            //_series5.Title = "ConfidenceUpperBound";
            //tChart1.Series.Add(_series5);
            //}

            tChart1.Axes.Bottom.FixedLabelSize = false;
            tChart1.Axes.Left.FixedLabelSize = false;

            tChart1.Header.Text = $"Using Calculation Engine: ML.NET";
        }

        private void SetData(string[] data)
        {
            _data = data.Select(x =>
            {
                var ss = x.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                Tuple<DateTime, double> result = null;

                try
                {
                    result = new Tuple<DateTime, double>(DateTime.Parse(ss[0].Trim(), CultureInfo.InvariantCulture), double.Parse(ss[1].Trim(), CultureInfo.InvariantCulture));
                }
                catch (Exception)
                {
                    MessageBox.Show("Unrecognizable data format.");
                }


                return result;
            });

            _predictionEditor.SetPredictions(_data.Count(), default);
        }

        private void ClearChart()
        {
            _series1.Clear();
            _series2.Clear();
            _series3.Clear();
            _series4.Clear();
            _series5.Clear();
            tChart1.Series.Clear();
            tChart1.Header.Text = "TeeChart";
        }

        private void bClearChart_Click(object sender, EventArgs e)
        {
            ClearChart();
        }

        private IEnumerable<Tuple<DateTime, double>> _data;

        private void bData_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                SetData(File.ReadAllLines(path));
                lDataName.Text = Path.GetFileName(path);
                //ImportTo();
            }
        }

        private void ResetData()
        {
            SetData(Resources.Data_Samples.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
            ImportTo();
            timer1.Enabled = true;
        }

        private void bResetData_Click(object sender, EventArgs e)
        {
            ResetData();
            lDataName.Text = "";
        }

        private int _count = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_series1.Count > 500)
            {
                _series1.Delete(0);
                _series3.Delete(0);
            }

            if (_count == _data.Count()) _count = 0;

            var point = _data.ElementAt(_count);

            point = new Tuple<DateTime, double>(DateTime.Now, point.Item2);

            _series1.Add(point.Item1, point.Item2);

            if(_series1.Count > 100)
            {
                var last = DateTime.FromOADate(_series1.XValues[_series1.Count - 1]);
                last = last.AddSeconds(2);

                if (_series1.Count > 500)
                {
                    tChart1.Axes.Bottom.SetMinMax(DateTime.FromOADate(_series1.XValues[_series1.Count - 501]), last);
                    tChart1.Axes.Left.SetMinMax(_series1.YValues.Minimum - 100, _series1.YValues.Maximum + 100);
                }

                Calculate_Predictions(new PredictionData { BestGuess = BestGuess.Projected, ConfidenceLevel = 0.95F, Horizon = 20, SeriesLength = _series1.Count, TrainSize = _series1.Count });
                Calculate_Anomalies();
            }


            //if (_count > 0 && _count % 100 == 0)
            //{
            //    Calculate_Anomalies();
            //}


            ++_count;
        }
    }
}
