using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    [NumClass(68)]
    [Serializable]
    public class PlansDates
    {
        private string _s_frm = @"yyyy-MM-dd HH:mm:ss";
        private DateTime? _PlZahaj;
        /// <summary>
        /// Начало планирования
        /// </summary>
        public DateTime? PlZahaj
        {
            set
            {
                _PlZahaj = value;
            }
            get
            {
                return _PlZahaj != null ? _PlZahaj :
                    PlPredani != null ? PlPredani :
                    Zahajeni != null ? Zahajeni :
                    Predani != null ? Predani :
                    Zaruka != null ? Zaruka : null;
            }
        }
        public string s_PlZahaj
        {
            get
            {
                if (PlZahaj == null) return "";
                else return PlZahaj.Value.ToString(_s_frm);
            }
        }
        /// <summary>
        /// Планированая сдача
        /// </summary>
        public DateTime? PlPredani { set; get; }
        public string s_PlPredani
        {
            get
            {
                if (PlPredani == null) return "";
                else return PlPredani.Value.ToString(_s_frm);
            }
        }
        /// <summary>
        /// Начало работы
        /// </summary>
        public DateTime? Zahajeni { set; get; }
        public string s_Zahajeni
        {
            get
            {
                if (Zahajeni == null) return "";
                else return Zahajeni.Value.ToString(_s_frm);
            }
        }
        /// <summary>
        /// Сдача работы
        /// </summary>
        public DateTime? Predani { set; get; }
        public string s_Predani
        {
            get
            {
                if (Predani == null) return "";
                else return Predani.Value.ToString(_s_frm);
            }
        }
        /// <summary>
        /// Гарантия
        /// </summary>
        public DateTime? Zaruka { set; get; }
        public string s_Zaruka
        {
            get
            {
                if (Zaruka == null) return "";
                else return Zaruka.Value.ToString(_s_frm);
            }
        }
        /// <summary>
        /// Дата последней стадии изменений - date_last_stage_update
        /// </summary>
        public DateTime? LastDate
        {
            get
            {
                return Zaruka != null ? Zaruka :
                    Predani != null ? Predani :
                    Zahajeni != null ? Zahajeni :
                    PlPredani != null ? PlPredani :
                    PlZahaj != null ? PlZahaj : null;
            }
        }
        public string s_LastDate
        {
            get
            {
                if (LastDate == null) return "";
                else return LastDate.Value.ToString(_s_frm);
            }
        }

        /// <summary>
        /// Сравнение содержимого 2 обьектов PlansDates
        /// </summary>
        /// <param name="Dats"></param>
        /// <returns></returns>
        public int CompareTo(PlansDates Dats)
        {
            int rez = 0;
            //  PlZahaj
            if (this.PlZahaj == null && Dats.PlZahaj != null) {; }
            else if (this.PlZahaj != null && Dats.PlZahaj == null) { return 1; }
            else if (this.PlZahaj != null && Dats.PlZahaj != null)
            {
                if (this.PlZahaj.Value.CompareTo(Dats.PlZahaj.Value) != 0) { return 2; }
            }
            //  LastDate
            if (this.LastDate == null && Dats.LastDate != null) {; }
            else if (this.LastDate != null && Dats.LastDate == null) { return 3; }
            else if (this.LastDate != null && Dats.LastDate != null)
            {
                if (this.LastDate.Value.CompareTo(Dats.LastDate.Value) != 0) { return 4; }
            }
            //  Zaruka
            if (this.Zaruka == null && Dats.Zaruka != null) {; }
            else if (this.Zaruka != null && Dats.Zaruka == null) { return 5; }
            else if (this.Zaruka != null && Dats.Zaruka != null)
            {
                if (this.Zaruka.Value.CompareTo(Dats.Zaruka.Value) != 0) { return 6; }
            }
            return rez;
        }
    }
}
