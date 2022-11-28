using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Steema.Numerics;
using Steema.Numerics.ChartHelpers;
using Steema.Numerics.Windows;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace Numerics_DataBase
{
    public partial class Form1 : Form
    {
        private TChart _chart = new TChart();
        private DataSet _data;
        private FastLine _line1, _line2, _line3, _line4, _line5;
        private FastLine _line1P, _line2P, _line3P, _line4P, _line5P;
        private readonly PredictionEditor _predictionEditor = new PredictionEditor();
        private PredictionData _predictionData = new PredictionData();

        private void bEdit_Click(object sender, EventArgs e)
        {
            _predictionEditor.ShowDialog();
        }

        private void InitPredictions()
        {
            _predictionData.BestGuess = BestGuess.Projected;
            _predictionData.ConfidenceLevel = 0.95F;
            _predictionData.Horizon = 1825;
            _predictionData.SeriesLength = _line1.Count;
            _predictionData.TrainSize = _line1.Count;

            _predictionEditor.SetPredictions(0, _predictionData);
        }

        private void bDoPredictions_Click(object sender, EventArgs e)
        {
            var watch = Stopwatch.StartNew();
            Cursor.Current = Cursors.WaitCursor;

            void DoSeries(FastLine series, FastLine prediction, PredictionResult result)
            {
                prediction.Title = series.Title + $" Prediction, BestWindowSize {result.BestWindowSize}";
                AddPredictionToSeries(series, prediction, result);
            }

            var predictions = new List<Task<PredictionResult>>
            {
                Task.Run(() => TeeChartHelper.Predictions_FromSeries(_line1, _predictionEditor.GetPredictionData())),
                Task.Run(() => TeeChartHelper.Predictions_FromSeries(_line2, _predictionEditor.GetPredictionData())),
                Task.Run(() => TeeChartHelper.Predictions_FromSeries(_line3, _predictionEditor.GetPredictionData())),
                Task.Run(() => TeeChartHelper.Predictions_FromSeries(_line4, _predictionEditor.GetPredictionData())),
                Task.Run(() => TeeChartHelper.Predictions_FromSeries(_line5, _predictionEditor.GetPredictionData())),                
            };

            Task.WaitAll(predictions.ToArray());

            if(_chart.Series.Count == 5)
            {
                _line1P = new FastLine(_chart.Chart);
                _line2P = new FastLine(_chart.Chart);
                _line3P = new FastLine(_chart.Chart);
                _line4P = new FastLine(_chart.Chart);
                _line5P = new FastLine(_chart.Chart);                
            }
            else
            {
                for (int i = 5; i < 10; i++)
                {
                    _chart[i].Clear();
                }
            }


            DoSeries(_line1, _line1P, predictions[0].Result);
            DoSeries(_line2, _line2P, predictions[1].Result);
            DoSeries(_line3, _line3P, predictions[2].Result);
            DoSeries(_line4, _line4P, predictions[3].Result);
            DoSeries(_line5, _line5P, predictions[4].Result);            

            watch.Stop();
            MessageBox.Show($"That took {watch.ElapsedMilliseconds} milliseconds to calculate (not draw)");
            Cursor.Current = Cursors.Default;
        }

        private void AddPredictionToSeries(FastLine fromSeries, FastLine toSeries, PredictionResult predictionData)
        {
            var xvals = new List<double>();

            var predictionParams = _predictionEditor.GetPredictionData();

            if(predictionParams.BestGuess != BestGuess.Overlay)
            {
                var lastX = DateTime.FromOADate(fromSeries.XValues.Value.Take(fromSeries.Count).TakeLast(1).First());
                var span = TimeSpan.FromDays(1);

                for (var i = 0; i < 1825; i++)
                {
                    lastX += span;
                    xvals.Add(lastX.ToOADate());
                }
            }
            else
            {
                xvals = fromSeries.XValues.Value.Take(fromSeries.Count).TakeLast(predictionParams.Horizon).ToList();
            }


            TeeChartHelper.Add_Predictions(fromSeries, toSeries, null, null, predictionData, xvals);
        }

        public Form1()
        {
            InitializeComponent();

            _chart.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(_chart);
            _chart.Axes.Bottom.Labels.Angle = 90;

            _chart.AfterDraw += _chart_AfterDraw;
        }

        private void _chart_AfterDraw(object sender, Steema.TeeChart.Drawing.IGraphics3D g)
        {
           if(_chart.Series.Count == 0)
            {
                var text = "Wait a second";
                g.Font.Color = Color.Red;
                g.Font.Size = 36;
                var size = g.MeasureString(g.Font, text);
                g.TextOut(g.ChartXCenter - (int)(size.Width / 2), g.ChartYCenter - (int)(size.Height / 2), "Wait a second");
            }
        }

        private async Task<DataSet> GetDataSet()
        {
            var connection = new MySqlConnection("server=qs4591.pair.com;port=3306;uid=nook4_10;password=4KDHXkXB;database=nook4_examples");

            using var command = new MySqlCommand($"SELECT * FROM `fact_machinedata`", connection);
            using var adapter = new MySqlDataAdapter(command);
            var dataSet = new DataSet();
            await adapter.FillAsync(dataSet);

            return dataSet;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _data = await Task.Run(async () => await GetDataSet());

            var table = _data.Tables[0].AsEnumerable();

            _line1 = new FastLine(_chart.Chart);
            _line2 = new FastLine(_chart.Chart);
            _line3 = new FastLine(_chart.Chart);
            _line4 = new FastLine(_chart.Chart);
            _line5 = new FastLine(_chart.Chart);

            _line1.Title = _data.Tables[0].Columns[0].ColumnName;
            _line2.Title = _data.Tables[0].Columns[1].ColumnName;
            _line3.Title = _data.Tables[0].Columns[2].ColumnName;
            _line4.Title = _data.Tables[0].Columns[3].ColumnName;
            _line5.Title = _data.Tables[0].Columns[4].ColumnName;            

            var today = DateTime.Today;

            foreach (var t in table)
            {
                for (var i = 1; i < 6; i++)
                {
                    _chart[i-1].Add(today, (double)t.ItemArray[i]);
                }

                today = today.AddDays(1);
            }

            InitPredictions();
        }
    }
}
