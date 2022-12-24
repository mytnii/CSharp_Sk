using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsultant
{
    internal class Client
    {
        #region Поля
        private string _lastName;            // Фамилия
        private string _firstName;           // Имя
        private string _patronumic;          // Отчество
        private int _series;                 // Серия паспорта
        private int _numberPassporty;        // Номер паспорта
        public List<string> phoneNumber;     // Номера телефонов

        #endregion
    }
}
