/*
   Для банка «А» необходимо разработать программу консультанта для просмотра данных клиента. 
   У консультанта нет прав для изменения или просмотра некоторых данных. 
   Создайте класс, в котором будут содержаться следующие поля:

   Фамилия
   Имя
   Отчество
   Номер телефона
   Серия, номер паспорта
   Реализуйте методы доступа для следующих ситуаций:

   Консультант не имеет доступа к просмотру информации. 
   Вместо серии и номера паспорта он видит символы: «******************», — если поле не пустое.
   Консультант не может изменять поля «Фамилия», «Имя», «Отчество», но может их просматривать.
   Консультант может изменить «Номер телефона», но при этом поле должно быть всегда заполнено.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataConsultant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
