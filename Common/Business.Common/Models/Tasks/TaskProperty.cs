using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Business.Models
{
    [Serializable]
    [NumClass(9)]
    [System.Diagnostics.DebuggerDisplay("Id: {Id}, Name: {Name}, Source: {ServerSource.Name}, Receiver: {ServerReceiver.Name}, IsTrigers: {IsTrigers}")]
    public partial class Task
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Id родителя
        /// </summary>
        public int IdParent { set; get; }

        /// <summary>
        /// Имя задачи
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Сервер источник информации
        /// </summary>
        public Servers ServerSource { set; get; }

        /// <summary>
        /// Сервер приёмник информации
        /// </summary>
        public Servers ServerReceiver { set; get; }

        /// <summary>
        /// True - запускаемая задача
        /// </summary>
        public bool IsRun { set; get; } = false;

        /// <summary>
        /// Тип задачи - тригерная или по расписанию задача
        /// </summary>
        public TypeTasks IsTrigers { set; get; } = TypeTasks.None;

        /// <summary>
        /// True - задача уже запущенна
        /// </summary>
        public bool IsWorks { set; get; } = false;

        /// <summary>
        /// True - В последнем запуске задачи возникла ошибка
        /// </summary>
        public bool IsError { set; get; } = false;

        /// <summary>
        /// Дата очередного запуска задачи
        /// </summary>
        public DateTimeOffset DateRun { set; get; } = DateTimeOffset.Now.ToUniversalTime();

        /// <summary>
        /// 
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// Дополнительные параметры
        /// </summary>
        public TaskDop Param { set; get; } = new TaskDop();

        /// <summary>
        /// Коллекция дочерних задач
        /// </summary>
        public List<Task> ListChilden { set; get; } = new List<Task>();

        /// <summary>
        /// Родительская задача
        /// </summary>
        public Task Parent { set; get; }

        public string MessageSchedule
        {
            get
            {
                string str = "", str_Parent = "", str_Schedule = "", str_Period = "", str_StartStop = "";
                DateTimeOffset dt_new = DateTimeOffset.Now;
                string s_Bk = "\r\n";
                if (this.Id == 1 || this.Id == 2)
                {
                    return "Корневые метки";
                }
                else
                {
                    if (IsTrigers == TypeTasks.Trigger)
                    {
                        str_Parent = string.Format("Триггерная задача");
                    }
                    else
                    {
                        if (this.IdParent == 1 || this.IdParent == 2)
                        {
                            str_Parent = string.Format("Родительская задача по расписанию.{0}" +
                                "",
                                s_Bk
                            );
                        }
                        else
                        {
                            str_Parent = string.Format("Дочерняя задача по расписанию.{0}" +
                                "",
                                s_Bk
                            );
                        }
                        switch (this.Param.Schedule.Interval){
                            case Period.Once:
                                str_Schedule = string.Format("Запустится один раз в ({1:dddd}) {1:dd-MMM-yyyy HH:mm}{0}",
                                    s_Bk, this.DateRun.LocalDateTime);
                                break;
                            case Period.TimeParent:
                                str_Schedule = string.Format("Смотри расписание родительской задачи.", s_Bk);
                                break;
                            case Period.Minute:
                                str_Schedule = string.Format("Запускается каждую {1} минуту.{0}", s_Bk, this.Param.Schedule.Minute.Minute);
                                break;
                            case Period.Hour:
                                str_Schedule = string.Format("Запускается каждый {1:hh} час в {1:mm} минут.{0}", s_Bk, this.Param.Schedule.Hour.Hour);
                                break;
                            case Period.Day:
                                str_Schedule = string.Format("Запускается каждый {1:dd} день в {1:HH:mm}.{0}", s_Bk, this.Param.Schedule.Day.Day);
                                break;
                            case Period.Week:
                                str_Schedule = "";
                                if (this.Param.Schedule.Week[DayOfWeek.Monday].Enable)
                                {
                                    str_Schedule = string.Format("Запускается каждый понедельник в {1:HH:mm}.{0}", 
                                        s_Bk, this.Param.Schedule.Week[DayOfWeek.Monday].Time.LocalDateTime);
                                }
                                if (this.Param.Schedule.Week[DayOfWeek.Tuesday].Enable)
                                {
                                    str_Schedule += string.Format("Запускается каждый вторник в {1:HH:mm}.{0}", 
                                        s_Bk, this.Param.Schedule.Week[DayOfWeek.Tuesday].Time.LocalDateTime);
                                }
                                if (this.Param.Schedule.Week[DayOfWeek.Wednesday].Enable)
                                {
                                    str_Schedule += string.Format("Запускается каждую среду в {1:HH:mm}.{0}", 
                                        s_Bk, this.Param.Schedule.Week[DayOfWeek.Wednesday].Time.LocalDateTime);
                                }
                                if (this.Param.Schedule.Week[DayOfWeek.Thursday].Enable)
                                {
                                    str_Schedule += string.Format("Запускается каждый четверг в {1:HH:mm}.{0}", 
                                        s_Bk, this.Param.Schedule.Week[DayOfWeek.Thursday].Time.LocalDateTime);
                                }
                                if (this.Param.Schedule.Week[DayOfWeek.Friday].Enable)
                                {
                                    str_Schedule += string.Format("Запускается каждую пятницу в {1:HH:mm}.{0}", 
                                        s_Bk, this.Param.Schedule.Week[DayOfWeek.Friday].Time.LocalDateTime);
                                }
                                if (this.Param.Schedule.Week[DayOfWeek.Saturday].Enable)
                                {
                                    str_Schedule += string.Format("Запускается каждую субботу в {1:HH:mm}.{0}", 
                                        s_Bk, this.Param.Schedule.Week[DayOfWeek.Saturday].Time.LocalDateTime);
                                }
                                if (this.Param.Schedule.Week[DayOfWeek.Sunday].Enable)
                                {
                                    str_Schedule += string.Format("Запускается каждый воскресенье в {1:HH:mm}.{0}", 
                                        s_Bk, this.Param.Schedule.Week[DayOfWeek.Sunday].Time.LocalDateTime);
                                }
                                break;
                            case Period.Month:
                                str_Schedule = string.Format("Запускается каждый месяц {1:dd} числа в {1:HH:mm}.{0}", s_Bk, this.Param.Schedule.Month.Month);
                                break;
                            case Period.None:
                                str_Schedule = string.Format("Расписание НЕ определено.{0}", s_Bk);
                                break;
                        };
                        if (this.Param.Schedule.IsStartEnd)
                        {
                            str_Period = string.Format("Расписание будет использоватся каждый день в промежутке {0:HH:mm}   по {1:HH:mm}{2}",
                                this.Param.Schedule.DataStart.ToLocalTime(),
                                this.Param.Schedule.DataEnd.ToLocalTime(),
                                s_Bk);
                        }
                        str_StartStop = string.Format("Задача будет работать до   {0:dd-MMM-yyyy HH:mm}{1}",
                                this.Param.Schedule.DateEndTask.LocalDateTime, s_Bk);
                        if (dt_new.CompareTo(this.Param.Schedule.DateEndTask) > 0)
                        {
                            str_Period = "Расписание не будет использоватся никогда";
                        }
                    }
                    str = string.Format("{0}{1}{2}{3}", str_Parent, str_Schedule, str_Period, str_StartStop);
                }
                return str;
            }
        }
    }
    
    [Serializable]
    public class TaskDop
    {
        /// <summary>
        /// Guid задачи
        /// </summary>
        public string IdGuid
        {
            set;
            get;
        } = Guid.NewGuid().ToString().Replace("-", "0");

        [XmlIgnore]
        private Business.Actions _Action = Business.Actions.None;
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Actions")]
        public Business.Actions Action
        {
            set { _Action = value; ActionProp = new ActionProperty(_Action); }
            get { return _Action; }
        } 

        /// <summary>
        /// Свойства действия
        /// </summary>
        [XmlIgnore]
        public ActionProperty ActionProp { private set; get; }

        /// <summary>
        /// Дата последнего запуска задачи
        /// </summary>
        [XmlIgnore]
        public DateTimeOffset DateLastRun { set; get; } = DateTimeOffset.Now.ToUniversalTime();
        public string sDateLastRun
        {
            get { return DateLastRun.ToString("o"); }
            set { DateLastRun = DateTimeOffset.Parse(value); }
        }

        /// <summary>
        /// Дата успешного последнего запуска задачи
        /// </summary>
        [XmlIgnore]
        public DateTimeOffset DateLastRunOk { set; get; } = DateTimeOffset.Now.ToUniversalTime();
        public string sDateLastRunOk
        {
            get { return DateLastRunOk.ToString("o"); }
            set { DateLastRunOk = DateTimeOffset.Parse(value); }
        }

        /// <summary>
        /// Коллекция баз для сервера (SQL и Pohoda) источника
        /// </summary>
        public List<InfoBasePohoda> CollectionBaseSource { set; get; } = new List<InfoBasePohoda>();

        /// <summary>
        /// Коллекция баз для сервера (SQL и Pohoda) приёмника
        /// </summary>
        public List<InfoBasePohoda> CollectionBaseReceiver { set; get; } = new List<InfoBasePohoda>();

        /// <summary>
        /// Расписание запуска задачи
        /// </summary>
        public Schedule Schedule { set; get; } = new Schedule();
    }

    [Serializable]
    public class Schedule
    {
        /// <summary>
        /// Указывает интервал (периодичность) выполнения задачи
        /// </summary>
        public Period Interval
        {
            set;
            get;
        }
            = Business.Period.None;

        /// <summary>
        /// Дата и время окончания выполнения задачи
        /// </summary>
        [XmlIgnore]
        public DateTimeOffset DateEndTask { set; get; } = DateTimeOffset.Now.ToUniversalTime().AddYears(5);
        public string sDateEndTask
        {
            get { return DateEndTask.ToString("o"); }
            set { DateEndTask = DateTimeOffset.Parse(value); }
        }

        /// <summary>
        /// Запускать задачу только в указанный период времени (true) или нет (false)
        /// </summary>
        public bool IsStartEnd { set; get; } = false;

        /// <summary>
        /// Время начала запуска, если IsStartEnd = true
        /// </summary>
        [XmlIgnore]
        public DateTimeOffset DataStart { set; get; } = new DateTimeOffset(2019, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0));
        public string sDataStart
        {
            get { return DataStart.ToString("o"); }
            set { DataStart = DateTimeOffset.Parse(value); }
        }

        /// <summary>
        /// Время окончания запуска, если IsStartEnd = true
        /// </summary>
        [XmlIgnore]
        public DateTimeOffset DataEnd { set; get; } = new DateTimeOffset(2019, 1, 1, 23, 59, 59, new TimeSpan(0, 0, 0));
        public string sDataEnd
        {
            get { return DataEnd.ToString("o"); }
            set { DataEnd = DateTimeOffset.Parse(value); }
        }

        /// <summary>
        /// Расписание на один раз запуска
        /// </summary>
        public SchOnce Once { set; get; } = new SchOnce();

        /// <summary>
        /// Расписание для задачи запускающуюся каждую N минуту начиная с
        /// </summary>
        public SchMinute Minute { set; get; } = new SchMinute();

        /// <summary>
        /// Расписание для задачи запускающуюся каждую N час начиная с
        /// </summary>
        public SchHour Hour { set; get; } = new SchHour();

        /// <summary>
        /// Расписание для задачи запускающуюся каждую N день начиная с
        /// </summary>
        public SchDay Day { set; get; } = new SchDay();

        /// <summary>
        /// Расписание для задачи запускающуюся каждую N месяц начиная с
        /// </summary>
        public SchMonth Month { set; get; } = new SchMonth();

        /// <summary>
        /// Расписание для задачи запускающуюся каждую N день недели начиная с
        /// </summary>
        public SchWeek Week { set; get; } = new SchWeek();
    }

    /// <summary>
    /// Расписание на один раз запуска
    /// </summary>
    [Serializable]
    public class SchOnce
    {
        /// <summary>
        /// Дата и время запуска задачи
        /// </summary>
        [XmlIgnore]
        public DateTimeOffset Once { set; get; } = DateTimeOffset.Now.ToUniversalTime();
        public string sOnce
        {
            get { return Once.ToString("o"); }
            set { Once = DateTimeOffset.Parse(value); }
        }
    }

    /// <summary>
    /// Расписание для задачи запускающуюся каждую N минуту начиная с
    /// </summary>
    [Serializable]
    public class SchMinute
    {
        public int Minute { set; get; } = 1;
    }

    /// <summary>
    /// Расписание для задачи запускающуюся каждую N час начиная с
    /// </summary>
    [Serializable]
    public class SchHour
    {
        [XmlIgnore]
        public DateTimeOffset Hour { set; get; } = new DateTimeOffset(2019, 1, 1, 1, 0, 0, new TimeSpan(0, 0, 0));
        public string sHour
        {
            get { return Hour.ToString("o"); }
            set { Hour = DateTimeOffset.Parse(value); }
        }
    }

    /// <summary>
    /// Расписание для задачи запускающуюся каждую N день начиная с
    /// </summary>
    [Serializable]
    public class SchDay
    {
        [XmlIgnore]
        public DateTimeOffset Day { set; get; } = new DateTimeOffset(2019, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0));
        public string sDay
        {
            get { return Day.ToString("o"); }
            set { Day = DateTimeOffset.Parse(value); }
        }
    }

    /// <summary>
    /// Расписание для задачи запускающуюся каждую N день недели начиная с
    /// </summary>
    [Serializable]
    public class SchWeek: Dictionary<DayOfWeek, WeekElem>, IXmlSerializable
    {
        private string s_Element = "WeekElem";
        private string s_Key = "Key";
        private string s_ValWeek = "Week";
        private string s_ValEnable = "Enable";
        private string s_ValTime = "Time";

        public SchWeek()
        {
            this.Add(DayOfWeek.Monday, new WeekElem() { Week = DayOfWeek.Monday });
            this.Add(DayOfWeek.Tuesday, new WeekElem() { Week = DayOfWeek.Tuesday });
            this.Add(DayOfWeek.Wednesday, new WeekElem() { Week = DayOfWeek.Wednesday });
            this.Add(DayOfWeek.Thursday, new WeekElem() { Week = DayOfWeek.Thursday });
            this.Add(DayOfWeek.Friday, new WeekElem() { Week = DayOfWeek.Friday });
            this.Add(DayOfWeek.Saturday, new WeekElem() { Week = DayOfWeek.Saturday });
            this.Add(DayOfWeek.Sunday, new WeekElem() { Week = DayOfWeek.Sunday });
        }
        protected SchWeek(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
            base(info, context)
        {
            object o1 = info.FullTypeName;
            object o2 = info.GetEnumerator();
            object o3 = info.GetType();
            object o4 = info.MemberCount;
            object o5 = info.ObjectType;
            object o6 = info.ToString();
        }

        public XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement) { return; }
            reader.Read();
            this.Clear();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                object key = reader.GetAttribute(s_Key);
                object valueWeek = reader.GetAttribute(s_ValWeek);
                object valueEnable = reader.GetAttribute(s_ValEnable);
                object valueTime = reader.GetAttribute(s_ValTime);
                WeekElem we = new WeekElem();
                we.Week = (DayOfWeek)Funcs.EnumsFn.GetIdEnum(typeof(DayOfWeek), valueWeek.ToString());
                we.Enable = bool.Parse(valueEnable.ToString());
                we.Time = DateTimeOffset.Parse(valueTime.ToString());
                this.Add((DayOfWeek)Funcs.EnumsFn.GetIdEnum(typeof(DayOfWeek), key.ToString()), we);
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var key in this.Keys)
            {
                writer.WriteStartElement(s_Element);
                writer.WriteAttributeString(s_Key, key.ToString());
                writer.WriteAttributeString(s_ValWeek, this[key].Week.ToString());
                writer.WriteAttributeString(s_ValEnable, this[key].Enable.ToString());
                writer.WriteAttributeString(s_ValTime, this[key].Time.ToString());
                writer.WriteEndElement();
            }
        }
    }

    /// <summary>
    /// Расписание для задачи запускающуюся каждую N месяц начиная с
    /// </summary>
    [Serializable]
    public class SchMonth
    {
        [XmlIgnore]
        public DateTimeOffset Month { set; get; } = new DateTimeOffset(2019, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0));
        public string sMonth
        {
            get { return Month.ToString("o"); }
            set { Month = DateTimeOffset.Parse(value); }
        }
    }

    [Serializable]
    public class WeekElem
    {
        public DayOfWeek Week { set; get; }
        public bool Enable { set; get; } = false;
        [XmlIgnore]
        public DateTimeOffset Time { set; get; } = new DateTimeOffset(2019, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0));
        public string sTime
        {
            get { return Time.ToString("o"); }
            set { Time = DateTimeOffset.Parse(value); }
        }
    }
}
