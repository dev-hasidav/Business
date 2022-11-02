using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    /// <summary>
    /// Статус документа
    /// </summary>
    [NumClass(52)]
    [Serializable]
    public class StatusZakazka
    {
        /// <summary>
        /// Статус для POHODA
        /// </summary>
        public Pohoda.Xml.EnumContractState StatusP { private set; get; }

        /// <summary>
        /// Статус для POHODA - текст
        /// </summary>
        public string StatusPText { private set; get; }

        /// <summary>
        /// Статус для ODOO
        /// </summary>
        public StatusCrm StatusO {private set; get; }

        /// <summary>
        /// Статус для ODOO - текст
        /// </summary>
        public string StatusOText { private set; get; }

        /// <summary>
        /// Конструктор для создания класса для POHODA
        /// </summary>
        /// <param name="stat"></param>
        public StatusZakazka(Pohoda.Xml.EnumContractState stat)
        {
            StatusP = stat;
            ConvertToOdoo();
        }

        /// <summary>
        /// Конструктор для создания класса для ODOO
        /// </summary>
        /// <param name="stat"></param>
        public StatusZakazka(StatusCrm stat)
        {
            StatusO = stat;
            ConvertToPohoda();
        }


        private void ConvertToPohoda()
        {
            switch (StatusO)
            {
                case StatusCrm.None:
                    StatusP = Pohoda.Xml.EnumContractState.None;
                    StatusPText = "none";
                    StatusOText = "none";
                    break;
                case StatusCrm.New:
                    StatusP = Pohoda.Xml.EnumContractState.planned;
                    StatusPText = "planned";
                    StatusOText = "new";
                    break;
                case StatusCrm.Qualified:
                    StatusP = Pohoda.Xml.EnumContractState.opened;
                    StatusPText = "opened";
                    StatusOText = "qualified";
                    break;
                case StatusCrm.Proposition:
                    StatusP = Pohoda.Xml.EnumContractState.delivered;
                    StatusPText = "delivered";
                    StatusOText = "proposition";
                    break;
                case StatusCrm.Won:
                    StatusP = Pohoda.Xml.EnumContractState.closed;
                    StatusPText = "closed";
                    StatusOText = "won";
                    break;
                default:
                    StatusP = Pohoda.Xml.EnumContractState.None;
                    StatusPText = "none";
                    StatusOText = "none";
                    break;
            }
        }
        private void ConvertToOdoo()
        {
            switch (StatusP)
            {
                case Pohoda.Xml.EnumContractState.None:
                    StatusO = StatusCrm.None;
                    StatusPText = "none";
                    StatusOText = "none";
                    break;
                case Pohoda.Xml.EnumContractState.planned:
                    StatusO = StatusCrm.New;
                    StatusPText = "planned";
                    StatusOText = "new";
                    break;
                case Pohoda.Xml.EnumContractState.opened:
                    StatusO = StatusCrm.Qualified;
                    StatusPText = "opened";
                    StatusOText = "qualified";
                    break;
                case Pohoda.Xml.EnumContractState.delivered:
                    StatusO = StatusCrm.Proposition;
                    StatusPText = "delivered";
                    StatusOText = "proposition";
                    break;
                case Pohoda.Xml.EnumContractState.closed:
                    StatusO = StatusCrm.Won;
                    StatusPText = "closed";
                    StatusOText = "won";
                    break;
                default:
                    StatusO = StatusCrm.None;
                    StatusPText = "none";
                    StatusOText = "none";
                    break;
            }
        }

        public bool CompareTo(StatusZakazka Stat)
        {
            return (this.StatusP == Stat.StatusP) && (this.StatusO == Stat.StatusO);
        }
        public bool CompareTo(Pohoda.Xml.EnumContractState Stat)
        {
            return this.StatusP == Stat;
        }
        public bool CompareTo(StatusCrm Stat)
        {
            return this.StatusO == Stat;
        }
    }

}
