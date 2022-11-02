using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [Serializable]
    [NumClass(7)]
    public class LogWrite
    {
        public int NumClass { set; get; }
        public int NumFunction { set; get; }
        public int NumError { set; get; }
        public int NumRow { set; get; }
        public int NumCol { set; get; }
        public string Func { set; get; }
        public string ChainOfFunctions { set; get; }

        public LogWrite(object sender, System.Reflection.MethodInfo mb)
        {
            GetIntNum(sender, mb);
        }

        private void GetIntNum(object sender, System.Reflection.MethodInfo mb)
        {
            Type t = sender.GetType();
            foreach (object item in t.GetCustomAttributes(false))
            {
                if (item.GetType().Name == typeof(Atributes.NumClass).Name)
                {
                    Type nc = item.GetType();
                    this.NumClass = (int)nc.GetProperty("Number").GetValue(item);
                }
            }
            if (mb != null)
            {
                foreach (object item in mb.GetCustomAttributes(false))
                {
                    if (item.GetType().Name == typeof(Atributes.NumFunction).Name)
                    {
                        Type nc = item.GetType();
                        this.NumFunction = (int)nc.GetProperty("Number").GetValue(item);
                    }
                }
                this.Func = mb.Name;
            }
            StackTrace st = new StackTrace(true);
            if (st.FrameCount > 3)
            {
                StackFrame frame = st.GetFrame(4);
                this.NumRow = frame.GetFileLineNumber();
                this.NumCol = frame.GetFileColumnNumber();
            }
            foreach (StackFrame item in st.GetFrames())
            {
                if (string.IsNullOrWhiteSpace(this.ChainOfFunctions)) this.ChainOfFunctions = string.Format("{0}({1}, {2})", item.GetMethod().Name, item.GetFileLineNumber(), item.GetFileColumnNumber());
                else this.ChainOfFunctions += " -> " + string.Format("{0}({1}, {2})", item.GetMethod().Name, item.GetFileLineNumber(), item.GetFileColumnNumber());
            }
        }
    }
}
