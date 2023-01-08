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
        private int _numberPassport;        // Номер паспорта
        public List<Phone> phoneNumber;     // Номера телефонов

        #endregion

        #region Свойства
        public string LastName
        {
            get { return _lastName; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string Patronumic
        {
            get { return _patronumic; }
        }

        public int Series
        {
            get { return _series; }
        }

        public int NumberPassporty
        {
            get { return _numberPassport; }
        }
        #endregion

        #region Конструкторы
        public Client
            (
            string lastName, string firstName,
            string patronumic, int series, int numberPasport
            )
        {
            this._lastName = lastName;
            this._firstName = firstName;
            this._patronumic = patronumic;
            this._series = series;
            this._numberPassport = numberPasport;
            this.phoneNumber = new List<Phone>();
        }
        #endregion
    }
}
