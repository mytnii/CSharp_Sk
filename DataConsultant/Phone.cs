using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsultant
{
    /// <summary>
    /// Телефон
    /// </summary>
    internal class Phone
    {
        #region Поля
        private string _phoneNumber;  // Номер телефона
        #endregion

        #region Свойства
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        #endregion

        #region Конструкторы
        public Phone()
        {

        }
        #endregion
    }
}
