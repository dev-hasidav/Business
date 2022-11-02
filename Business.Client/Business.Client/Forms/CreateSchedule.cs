using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business.Client.Forms
{
    public partial class CreateSchedule : Form
    {
        public Business.Models.Task Ts { set; get; }
        private BindingSource binTs = new BindingSource();
        private BindingSource binSchedule = new BindingSource();
        private BindingSource binOnce = new BindingSource();
        private BindingSource binMinute = new BindingSource();
        private BindingSource binHour = new BindingSource();
        private BindingSource binDay = new BindingSource();
        private BindingSource binMonth = new BindingSource();
        public bool IsParent { set; get; } = true;
        public CreateSchedule()
        {
            InitializeComponent();
            rbtOneTime.Location = new Point(105, 14);
            rbtReusable.Location = new Point(180, 14);
            rbtTimeParent.Location = new Point(189, 14);
        }
        private void CreateSchedule_Load(object sender, EventArgs e)
        {
            if (!IsParent)
            {
                rbtReusable.Visible = false;
                rbtTimeParent.Visible = true;
                if (Ts.Param.Schedule.Interval == Period.TimeParent) rbtTimeParent.Checked = true;
                else rbtOneTime.Checked = true;
            }
            SetInterval();
            ResetAllPanel();

            _TaskBinding();
        }

        #region  ==========  Binding  ==========
        private void _TaskBinding()
        {

            #region  ==========  Ts

            binTs.DataSource = Ts;

            Binding bndTs = new Binding("Value", binTs, "DateRun")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatDate;
            bndTs.Parse += ParseDate;
            dtpDateFirstRun.DataBindings.Add(bndTs);

            #endregion

            #region  ==========  Ts Schedule
            binSchedule.DataSource = Ts.Param.Schedule;

            bndTs = new Binding("Value", binSchedule, "DateEndTask")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatDate;
            bndTs.Parse += ParseDate;
            dtpDateEndTask.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", binSchedule, "IsStartEnd")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkStartEnd.DataBindings.Add(bndTs);

            bndTs = new Binding("Value", binSchedule, "DataEnd")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpTimeDayEnd.DataBindings.Add(bndTs);

            bndTs = new Binding("Value", binSchedule, "DataStart")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpTimeDayStart.DataBindings.Add(bndTs);

            #endregion

            #region  ==========  Ts Schedule.Once
            binOnce.DataSource = Ts.Param.Schedule.Once;

            bndTs = new Binding("Value", binOnce, "Once")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatDate;
            bndTs.Parse += ParseDate;
            dtpCreateTaskOnceDate.DataBindings.Add(bndTs);

            #endregion

            #region  ==========  Ts Schedule.Minute
            binMinute.DataSource = Ts.Param.Schedule.Minute;

            bndTs = new Binding("Value", binMinute, "Minute")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            numCreateTaskMinute.DataBindings.Add(bndTs);

            #endregion

            #region  ==========  Ts Schedule.Hour
            binHour.DataSource = Ts.Param.Schedule.Hour;

            bndTs = new Binding("Value", binHour, "Hour")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpCreateTaskHour.DataBindings.Add(bndTs);

            #endregion

            #region  ==========  Ts Schedule.Day
            binDay.DataSource = Ts.Param.Schedule.Day;

            bndTs = new Binding("Value", binDay, "Day")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpCreateTaskDayTime.DataBindings.Add(bndTs);

            #endregion

            #region  ==========  Ts Schedule.Week

            bndTs = new Binding("Value", Ts.Param.Schedule.Week[DayOfWeek.Monday], "Time")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpWeek1.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", Ts.Param.Schedule.Week[DayOfWeek.Monday], "Enable")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkCreateTaskWeek1.DataBindings.Add(bndTs);

            bndTs = new Binding("Value", Ts.Param.Schedule.Week[DayOfWeek.Tuesday], "Time")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpWeek2.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", Ts.Param.Schedule.Week[DayOfWeek.Tuesday], "Enable")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkCreateTaskWeek2.DataBindings.Add(bndTs);

            bndTs = new Binding("Value", Ts.Param.Schedule.Week[DayOfWeek.Wednesday], "Time")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpWeek3.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", Ts.Param.Schedule.Week[DayOfWeek.Wednesday], "Enable")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkCreateTaskWeek3.DataBindings.Add(bndTs);

            bndTs = new Binding("Value", Ts.Param.Schedule.Week[DayOfWeek.Thursday], "Time")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpWeek4.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", Ts.Param.Schedule.Week[DayOfWeek.Thursday], "Enable")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkCreateTaskWeek4.DataBindings.Add(bndTs);

            bndTs = new Binding("Value", Ts.Param.Schedule.Week[DayOfWeek.Friday], "Time")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpWeek5.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", Ts.Param.Schedule.Week[DayOfWeek.Friday], "Enable")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkCreateTaskWeek5.DataBindings.Add(bndTs);

            bndTs = new Binding("Value", Ts.Param.Schedule.Week[DayOfWeek.Saturday], "Time")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpWeek6.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", Ts.Param.Schedule.Week[DayOfWeek.Saturday], "Enable")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkCreateTaskWeek6.DataBindings.Add(bndTs);

            bndTs = new Binding("Value", Ts.Param.Schedule.Week[DayOfWeek.Sunday], "Time")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpWeek7.DataBindings.Add(bndTs);

            bndTs = new Binding("Checked", Ts.Param.Schedule.Week[DayOfWeek.Sunday], "Enable")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            chkCreateTaskWeek7.DataBindings.Add(bndTs);

            #endregion

            #region  ==========  Ts Schedule.Month
            binMonth.DataSource = Ts.Param.Schedule.Month;

            bndTs = new Binding("Value", binMonth, "Month")
            {
                ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };
            bndTs.Format += FormatTime;
            bndTs.Parse += ParseTime;
            dtpCreateTaskMonthDate.DataBindings.Add(bndTs);

            #endregion

        }
        #endregion

        #region  ==========  bin event  ==========
        private void FormatDate(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                DateTimeOffset dt = (DateTimeOffset)e.Value;
                e.Value = dt.ToLocalTime().DateTime;
            }
            else
            {
                e.Value = DateTime.Now;
            }
        }
        private void ParseDate(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                DateTime ddd = (DateTime)e.Value;
                e.Value = (new DateTimeOffset(ddd)).ToUniversalTime();
            }
            else
            {
                e.Value = DateTime.Now;
            }
        }
        private void FormatTime(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                DateTimeOffset dt = (DateTimeOffset)e.Value;
                e.Value = dt.DateTime;
            }
            else
            {
                e.Value = DateTime.Now;
            }
        }
        private void ParseTime(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                DateTime ddd = (DateTime)e.Value;
                e.Value = new DateTimeOffset(ddd);
            }
            else
            {
                e.Value = DateTime.Now;
            }
        }
        #endregion

        #region  ==========  Exit  ==========
        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (Ts.Param.Schedule.Interval)
            {
                case Period.Once:
                case Period.Day:
                case Period.Week:
                case Period.Month:
                case Period.TimeParent:
                    Ts.Param.Schedule.IsStartEnd = false;
                    break;
                case Period.Minute:
                case Period.Hour:
                case Period.None:
                    break;
            }
            Ts.DateRun = Ts.ReCalculateDateRun(DateTimeOffset.Now.ToUniversalTime());
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        private void chkStartEnd_CheckedChanged(object sender, EventArgs e)
        {
            dtpTimeDayStart.Enabled = dtpTimeDayEnd.Enabled = chkStartEnd.Checked;
        }
        private void rbtTypeScheduleMenu_CheckedChanged(object sender, EventArgs e)
        {
            ResetPanel();
            if (rbtOneTime.Checked)
            {
                pnlCreateTaskOnce.Visible = true;
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel1Collapsed = true;
                Ts.Param.Schedule.Interval = Period.Once;
            }
            else if (rbtTimeParent.Checked)
            {
                //pnlCreateTaskOnce.Visible = true;
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel1Collapsed = false;
                Ts.Param.Schedule.Interval = Period.TimeParent;
            }
            else if (rbtReusable.Checked)
            {
                splitContainer2.Panel1Collapsed = false;
                splitContainer1.Panel1Collapsed = false;
                if (rbtMinute.Checked)
                {
                    pnlCreateTaskMinute.Visible = true;
                    Ts.Param.Schedule.Interval = Period.Minute;
                }
                else if (rbtHour.Checked)
                {
                    pnlCreateTaskHour.Visible = true;
                    Ts.Param.Schedule.Interval = Period.Hour;
                }
                else if (rbtDay.Checked)
                {
                    groupBox5.Visible = false;
                    pnlCreateTaskDay.Visible = true;
                    Ts.Param.Schedule.Interval = Period.Day;
                }
                else if (rbtWeek.Checked)
                {
                    groupBox5.Visible = false;
                    pnlCreateTaskWeek.Visible = true;
                    Ts.Param.Schedule.Interval = Period.Week;
                }
                else if (rbtMonth.Checked)
                {
                    groupBox5.Visible = false;
                    pnlCreateTaskMonth.Visible = true;
                    Ts.Param.Schedule.Interval = Period.Month;
                }
            }
        }
        private void SetInterval()
        {
            switch (Ts.Param.Schedule.Interval)
            {
                case Period.Once:
                    splitContainer2.Panel1Collapsed = true;
                    rbtOneTime.Checked = true;
                    break;
                case Period.Minute:
                    splitContainer1.Panel1Collapsed = false;
                    rbtReusable.Checked = true;
                    rbtMinute.Checked = true;
                    break;
                case Period.Hour:
                    splitContainer1.Panel1Collapsed = false;
                    rbtReusable.Checked = true;
                    rbtHour.Checked = true;
                    break;
                case Period.Day:
                    splitContainer1.Panel1Collapsed = false;
                    groupBox5.Visible = false;
                    rbtReusable.Checked = true;
                    rbtDay.Checked = true;
                    break;
                case Period.Week:
                    splitContainer1.Panel1Collapsed = false;
                    groupBox5.Visible = false;
                    rbtReusable.Checked = true;
                    rbtWeek.Checked = true;
                    break;
                case Period.Month:
                    splitContainer1.Panel1Collapsed = false;
                    groupBox5.Visible = false;
                    rbtReusable.Checked = true;
                    rbtMonth.Checked = true;
                    break;
                case Period.TimeParent:
                    splitContainer2.Panel1Collapsed = true;
                    rbtTimeParent.Checked = true;
                    break;
                case Period.None:
                    break;
            }
        }
        private void ResetPanel()
        {
            pnlCreateTaskDay.Visible = pnlCreateTaskHour.Visible = pnlCreateTaskMinute.Visible =
                pnlCreateTaskMonth.Visible = pnlCreateTaskOnce.Visible = pnlCreateTaskWeek.Visible = false;
        }
        private void ResetAllPanel()
        {
            splitContainer1.Panel1Collapsed = true;
            pnlCreateTaskDay.Dock = pnlCreateTaskHour.Dock = pnlCreateTaskMinute.Dock =
                pnlCreateTaskMonth.Dock = pnlCreateTaskOnce.Dock = pnlCreateTaskWeek.Dock = DockStyle.Fill;
            pnlCreateTaskDay.Location = pnlCreateTaskHour.Location = pnlCreateTaskMinute.Location =
                pnlCreateTaskMonth.Location = pnlCreateTaskOnce.Location = pnlCreateTaskWeek.Location = new Point(0, 0);
            ResetPanel();
            rbtTypeScheduleMenu_CheckedChanged(null, null);
        }
        private void dtpTimeDay_ValueChanged(object sender, EventArgs e)
        {
            dtpTimeDayStart.MaxDate = dtpTimeDayEnd.Value;
            dtpTimeDayEnd.MinDate = dtpTimeDayStart.Value;
        }
        private void dtpTaskStart_ValueChanged(object sender, EventArgs e)
        {
            dtpDateFirstRun.MaxDate = dtpDateEndTask.Value;
            dtpDateEndTask.MinDate = dtpDateFirstRun.Value;
        }
        private void chkCreateTaskWeek_CheckedChanged(object sender, EventArgs e)
        {
            dtpWeek1.Enabled = chkCreateTaskWeek1.Checked;
            dtpWeek2.Enabled = chkCreateTaskWeek2.Checked;
            dtpWeek3.Enabled = chkCreateTaskWeek3.Checked;
            dtpWeek4.Enabled = chkCreateTaskWeek4.Checked;
            dtpWeek5.Enabled = chkCreateTaskWeek5.Checked;
            dtpWeek6.Enabled = chkCreateTaskWeek6.Checked;
            dtpWeek7.Enabled = chkCreateTaskWeek7.Checked;
        }

    }
}
