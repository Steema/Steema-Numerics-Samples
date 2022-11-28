using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numerics_TeeChart.Properties;
using Steema.Numerics;
using Steema.Numerics.ChartHelpers;
using Steema.Numerics.Windows;
using Steema.TeeChart.Styles;

namespace Numerics_TeeChart
{
  public partial class NumericsForm : Form
  {
    private Steema.TeeChart.TChart _tChart1;
    readonly int _pH = 300;
    bool _hided = true;
    private readonly Timer _timer;
    int _buttonSelected = -1;

    private FastLine _series1;
    private FastLine _series3;
    private FastLine _series4;
    private FastLine _series5;
    private Points _series2;
    private readonly PredictionEditor _predictionEditor = new PredictionEditor();
    private readonly Timer _timer1 = new Timer();
    private readonly Timer _timerAnomalies = new Timer();
    private int _seriesPointsCount = 0;
    private int _seriesPointsAdded = 0;


    public NumericsForm()
    {

      void InitializeChart()
      {
        _tChart1 = new Steema.TeeChart.TChart
        {
          Dock = DockStyle.Fill
        };

        _series1 = new FastLine();
        _series3 = new FastLine();
        _series4 = new FastLine();
        _series5 = new FastLine();
        _series2 = new Points();

        _tChart1.Axes.Bottom.Grid.DrawEvery = 1;
        _tChart1.Axes.Bottom.Grid.Visible = false;
        _tChart1.Axes.Left.Grid.DrawEvery = 2;
        _tChart1.Axes.Left.Grid.Visible = true;
        _tChart1.Axes.Bottom.Labels.Angle = 90;
        _tChart1.Legend.CheckBoxes = true;
        _tChart1.Panel.MarginBottom = 10;
        _tChart1.Panel.Gradient.Visible = false;

        _tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Top;

        _tChart1.Tools.Add(new Steema.TeeChart.Tools.Annotation());
        (_tChart1.Tools[0] as Steema.TeeChart.Tools.Annotation).Left = 15;
        (_tChart1.Tools[0] as Steema.TeeChart.Tools.Annotation).Top = 10;
        (_tChart1.Tools[0] as Steema.TeeChart.Tools.Annotation).Shape.Transparent = true;

        _tChart1.Tools.Add(new Steema.TeeChart.Tools.Annotation());
        (_tChart1.Tools[1] as Steema.TeeChart.Tools.Annotation).Left = 15;
        (_tChart1.Tools[1] as Steema.TeeChart.Tools.Annotation).Top = 25;
        (_tChart1.Tools[1] as Steema.TeeChart.Tools.Annotation).Shape.Transparent = true;

        _tChart1.Tools.Add(new Steema.TeeChart.Tools.Annotation());
        (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Position = Steema.TeeChart.Tools.AnnotationPositions.Center;
        (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Shape.Transparent = true;
        (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Shape.Text = "Loading...";
        (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Shape.Font.Size = 20;
        (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Active = false;

        panelChart.Controls.Add(_tChart1);
        panelWarnings.Width = 300;
      }

      InitializeComponent();

      panelOptions.Height = 0;
      _timer = new Timer
      {
        Interval = 10
      };
      _timer.Tick += Timer_Tick;

      InitializeChart();
      cbDataSets.SelectedIndex = 1;
      _timer1.Interval = 1;
      _timer1.Tick += Timer1_Tick;

      _timerAnomalies.Interval = 5000;
      _timerAnomalies.Tick += TimerAnomalies_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (_hided)
      {
        panelOptions.Height += 20;
        if (panelOptions.Height >= _pH)
        {
          panelOptions.Height = 300;
          _timer.Stop();
          _hided = false;
          Refresh();
        }
      }
      else
      {
        panelOptions.Height -= 20;
        if (panelOptions.Height <= 0)
        {
          panelOptions.Height = 0;
          _timer.Stop();
          _hided = true;
          Refresh();
        }
      }
    }

    private void BOptions_Click(object sender, EventArgs e)
    {
      _timer.Start();
    }

    int _seconds = 0;
    private void TimerAnomalies_Tick(object sender, EventArgs e)
    {
      Calculate_Anomalies();
      if (_buttonSelected == 1)
        Calculate_Predictions();

      _seconds += 5;
      (_tChart1.Tools[1] as Steema.TeeChart.Tools.Annotation).Text = _anomalies.Length.ToString() + " Anomalies in " + _seconds.ToString() + " seconds";
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      var dataList = _data.ToList();
      if (_seriesPointsAdded < _seriesPointsCount - 1)
      {
        _series1.Add(dataList[_seriesPointsAdded + 1].Item1, dataList[_seriesPointsAdded].Item2);
        (_tChart1.Tools[0] as Steema.TeeChart.Tools.Annotation).Text = "Adding XVal : " + dataList[_seriesPointsAdded + 1].Item1.ToString() + " YVal : " + dataList[_seriesPointsAdded + 1].Item2.ToString();
        ++_seriesPointsAdded;
        _series1.Invalidate();
      }
      else
      {
        _timer1.Enabled = false;
        _timerAnomalies.Enabled = false;

        (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Active = false;
        bOptions.Enabled = true;
        bAnomalies.Enabled = true;
        bPrediction.Enabled = true;
        bAnomalies.Text = "SHOW ANOMALIES SAMPLE";
        bPrediction.Text = "SHOW PREDICTION SAMPLE";
        bStop.Enabled = false;
        panelOptions.Enabled = true;

        cbRealTime.Enabled = true;
        _loading = false;
      }
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

    private void Calculate_Predictions()
    {
      var predictionData = _predictionEditor.GetPredictionData();

      PredictionResult predictions = null;

      try
      {
        if (_series1.Count > 0)
          predictions = TeeChartHelper.Predictions_FromSeries(_series1, predictionData);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      if (predictions != null)
      {
        List<double> xvals;
        if (predictionData.BestGuess == BestGuess.Projected)
        {
          xvals = new List<double>();
          var lastTwo = _series1.XValues.Value.Take(_series1.Count).TakeLast(2).ToArray();
          var lastX = DateTime.FromOADate(lastTwo[1]);
          var span = lastX - DateTime.FromOADate(lastTwo[0]);

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

        _series3.Clear();
        _series4.Clear();
        _series5.Clear();

        TeeChartHelper.Add_Predictions(_series1, _series3, _series4, _series5, predictions, xvals);

        //MessageBox.Show($"BestWindowSize: {predictions.BestWindowSize}, MSE: {predictions.MSE}");
      }
    }

    int[] _anomalies = null;
    private void Calculate_Anomalies()
    {
      _anomalies = null;

      try
      {
        if (_series1.Count > 0)
          _anomalies = TeeChartHelper.Anomalies_FromSeries(_series1);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      if (_anomalies != null)
      {
        TeeChartHelper.Add_Anomalies(_series1, _series2, _anomalies);

        // Show Warnings / Notifications
        Add_Warnings(_series1, _anomalies);
      }
    }

    private void Add_Warnings(Series fromSeries, int[] anomalies)
    {
      tbWarnings.Clear();

      foreach (var i in anomalies)
      {
        tbWarnings.AppendText("Anomaly found on " + DateTime.FromOADate(fromSeries.XValues[i]).ToShortDateString() + " at Value " + fromSeries.YValues[i].ToString());
        tbWarnings.AppendText(Environment.NewLine);
      }
    }

    private void ImportTo(bool realTime)
    {
      ClearChart();

      _series1.VertAxis = VerticalAxis.Left;
      _series2.VertAxis = VerticalAxis.Left;
      _series3.VertAxis = VerticalAxis.Left;
      _series4.VertAxis = VerticalAxis.Right;
      _series5.VertAxis = VerticalAxis.Right;

      _series1.Title = "Data";

      _tChart1.Series.Add(_series1);


      if (_buttonSelected == 0)
      {
        _series2.Title = "Anomalies";
        _tChart1.Series.Add(_series2);
      }
      else if (_buttonSelected == 1)
      {
        _series3.Title = "Prediction";
        _tChart1.Series.Add(_series3);
        _series4.Title = "ConfidenceLowerBound";
        _tChart1.Series.Add(_series4);
        _series5.Title = "ConfidenceUpperBound";
        _tChart1.Series.Add(_series5);
      }

      if (_data.FirstOrDefault() != null)
      {
        if (realTime)
        {
          _seriesPointsCount = _data.Count();
          _seriesPointsAdded = 0;

          _timer1.Enabled = true;
          _timerAnomalies.Enabled = true;
        }
        else
        {
          foreach (var item in _data)
          {
            _series1.Add(item.Item1, item.Item2);
          }
        }
      }

      //tChart1.Header.Text = $"Using Calculation Engine: ML.NET";
      _tChart1.Header.Text = cbDataSets.Text;
    }

    private void SetData(string[] data)
    {
      Tuple<DateTime, double> result = null;
      string[] ss = null;

      _data = data.Select(x =>
      {

        ss = cbDataSets.SelectedIndex switch
        {
          0 => x.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries),
          1 => x.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries),
          2 => x.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries),
          _ => x.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries),
        };
        if ((ss[0] != "time_stamp") && (ss[0] != "Timestamp"))
        {
          try
          {
            switch (cbDataSets.SelectedIndex)
            {
              case 0:
                result = new Tuple<DateTime, double>(DateTime.Parse(ss[0].Trim(), CultureInfo.InvariantCulture), double.Parse(ss[3].Trim(), CultureInfo.InvariantCulture));
                break;
              case 1:
                result = new Tuple<DateTime, double>(DateTime.Parse(ss[0].Trim(), CultureInfo.InvariantCulture), double.Parse(ss[1].Trim(), CultureInfo.InvariantCulture));
                break;
              case 2: // C8                                
                var anow = DateTime.Now.AddSeconds(int.Parse(ss[0].Trim())).ToString();
                result = new Tuple<DateTime, double>(DateTime.Parse(anow.Trim(), CultureInfo.InvariantCulture), double.Parse(ss[1].Trim(), CultureInfo.InvariantCulture));
                break;
            }
          }
          catch (Exception)
          {
            MessageBox.Show("Unrecognizable data format.");
          }

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
      _tChart1.Series.Clear();
      _tChart1.Header.Text = "TeeChart";
    }

    private void BClearChart_Click(object sender, EventArgs e)
    {
      ClearChart();
    }

    private IEnumerable<Tuple<DateTime, double>> _data;
    private bool _inRealTime;
    private bool _loading;

    private void BData_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        var path = openFileDialog1.FileName;

        var a = File.ReadAllLines(path);

        var dataNoHeader = (string[])a.Where(line => (!line.Contains("time_stamp")) && (!line.Contains("Timestamp")));
        SetData(dataNoHeader);
        //SetData(File.ReadAllLines(path));
        lDataName.Text = Path.GetFileName(path);
        ImportTo(_inRealTime);
      }
    }

    private void BEditAlgorithm_Click(object sender, EventArgs e)
    {
      _predictionEditor.ShowDialog();
    }

    private bool ResetData(bool isRealTime)
    {
      SetDataSetDescription();
      switch (cbDataSets.SelectedIndex)
      {
        case 0:  // contiuous_factory_process
          SetData(Resources.continuous_factory_process.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
          break;
        case 1:  // Data_Samples
          SetData(Resources.Data_Samples.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
          break;
        case 2:  // C8 production data for Condition monitoring
          SetData(Resources.C8.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
          break;
      }

      ImportTo(isRealTime);

      var result = true;

      return result;
    }

    private void BResetData_Click(object sender, EventArgs e)
    {
      ResetData(_inRealTime);
      lDataName.Text = "";
    }

    private void SetDataSetDescription()
    {
      switch (cbDataSets.SelectedIndex)
      {
        case 0:
          tbDataSetDescription.Text = Resources.continuous_factory_process1;
          break;
        case 1:
          tbDataSetDescription.Text = "Sample Data without description";
          break;
        case 3:
          tbDataSetDescription.Text = Resources.Production_Plant_Data_for_Condition_Monitoring;
          break;
      }
    }

    private void BChartEditor_Click(object sender, EventArgs e)
    {
      _tChart1.ShowEditor();
    }

    private void CbAxisFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
      _tChart1.Axes.Bottom.Labels.DateTimeFormat = cbAxisFormat.Text;
    }

    private void CbAxisIncrement_SelectedIndexChanged(object sender, EventArgs e)
    {
      _tChart1.Axes.Bottom.Increment = cbAxisIncrement.SelectedIndex switch
      {
        0 => Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneYear),
        1 => Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneMonth),
        2 => Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneDay),
        3 => Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneHour),
        4 => Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneMinute),
        5 => Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneSecond),
        _ => Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneSecond),
      };
    }

    private void BViewData_Click(object sender, EventArgs e)
    {
      string filename;
      switch (cbDataSets.SelectedIndex)
      {
        case 0:
          filename = "continuous_factory_process.csv";
          if (!System.IO.File.Exists(filename))
            System.IO.File.WriteAllText(filename, Resources.continuous_factory_process);

          // or explicitely open file in notepad
          System.Diagnostics.Process.Start("notepad.exe", filename);

          break;
        case 1:
          filename = "Data_Samples.txt";
          tbDataSetDescription.Text = "Sample Data without description";

          if (!System.IO.File.Exists(filename))
            System.IO.File.WriteAllText(filename, Resources.Data_Samples);

          System.Diagnostics.Process.Start("notepad.exe", filename);
          break;
        case 2:
          filename = "C8.csv";
          tbDataSetDescription.Text = Resources.Production_Plant_Data_for_Condition_Monitoring;

          if (!System.IO.File.Exists(filename))
            System.IO.File.WriteAllText(filename, Resources.C8);

          System.Diagnostics.Process.Start("notepad.exe", filename);
          break;
      }
    }

    protected void DrawData_SmoothedMovAvgFunction(ArrayList payload)
    {
      //var timer1 = new Timer();
      /*
      if ((tChart1.Series.Count > 0) && (_trendTest))
      {
          _smoothedMovAvgFunction1 = new Steema.TeeChart.Functions.SmoothedMovAvgFunction
          {
              Period = 18D
          };

          _line1 = tChart1.Series[0];
          _line2 = new Line();
          _line3 = new Line();
          _area4 = new Area();

          //tChart1.Chart.Series.Add(_line1);
          tChart1.Chart.Series.Add(_line2);
          tChart1.Chart.Series.Add(_line3);
          tChart1.Chart.Series.Add(_area4);

          foreach (Series s in tChart1.Series)
          {
              s.Marks.Visible = false;
          }

          _line2.Function = _smoothedMovAvgFunction1;
          _line2.DataSource = _line1;

          _area4.LinePen.Color = Color.FromArgb(30, Color.Green);
          _area4.Color = Color.FromArgb(10, Color.Green);

          //_line1.Title = "cycles";
          _line2.Title = "mov-avg";
          _line3.Title = "prevision";
          _area4.Title = "trend";

          tChart1.Legend.Alignment = LegendAlignments.Right;

          //timer1.Interval = 300;
          //timer1.Tick += new System.EventHandler(Timer1_Tick);
          //timer1.Enabled = true;
      }
      //else
      //  timer1.Enabled = false;
      */
    }

    private void CbMovingAverage_CheckedChanged(object sender, EventArgs e)
    {
      if (cbMovingAverage.Checked)
        DrawData_SmoothedMovAvgFunction(null);
      //else
      //ClearDataMovingAverage();
    }

    private void LoadData()
    {
      if (_loading)
      {
        _loading = false;

        if (_inRealTime)
        {
          _timer1.Enabled = false;
          _timerAnomalies.Enabled = false;
        }
      }
      else
      {
        _loading = true;
        _inRealTime = cbRealTime.Checked;
        ResetData(_inRealTime);
      }
    }

    private void BAnomalies_Click(object sender, EventArgs e)
    {
      ClearChart();

      _buttonSelected = 0;

      bAnomalies.Enabled = false;
      bPrediction.Enabled = false;
      panelOptions.Enabled = false;

      if (cbRealTime.Checked)
        bStop.Enabled = true;

      if (cbRealTime.Checked)
        bAnomalies.Text = "LOADING IN REALTIME... CLICK TO STOP !";
      else
        bAnomalies.Text = "LOADING...";

      (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Active = true;
      _tChart1.Axes.Left.Grid.Visible = true;
      bOptions.Enabled = false;
      Application.DoEvents();

      LoadData();
      Calculate_Anomalies();
      _loading = false;

      if (!cbRealTime.Checked)
      {
        bAnomalies.Enabled = true;
        bPrediction.Enabled = true;
        bAnomalies.Text = "SHOW ANOMALIES SAMPLE";
        bOptions.Enabled = true;
        (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Active = false;
        panelOptions.Enabled = true;
      }
    }

    private void BPrediction_Click(object sender, EventArgs e)
    {
      ClearChart();

      _buttonSelected = 1;

      if (cbRealTime.Checked)
        bStop.Enabled = true;

      bAnomalies.Enabled = false;
      bPrediction.Enabled = false;
      panelOptions.Enabled = false;

      bPrediction.Text = "LOADING...";

      if (cbRealTime.Checked)
        bAnomalies.Text = "LOADING IN REALTIME... CLICK TO STOP !";
      else
        bPrediction.Text = "LOADING...";

      (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Active = true;
      _tChart1.Axes.Left.Grid.Visible = false;
      bOptions.Enabled = false;
      Application.DoEvents();

      LoadData();
      if (!cbRealTime.Checked)
        Calculate_Predictions();

      _loading = false;

      if (!cbRealTime.Checked)
      {
        bAnomalies.Enabled = true;
        bPrediction.Enabled = true;
        bPrediction.Text = "SHOW PREDICTION SAMPLE";
        bOptions.Enabled = true;
        panelOptions.Enabled = true;
        (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Active = false;
      }
    }

    private void BStop_Click(object sender, EventArgs e)
    {
      _timerAnomalies.Stop();
      _timer1.Stop();
      bStop.Enabled = false;
      (_tChart1.Tools[2] as Steema.TeeChart.Tools.Annotation).Active = false;
      panelOptions.Enabled = true;
      ClearChart();
    }
  }
}
