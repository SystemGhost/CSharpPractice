using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Программа пересчитывает растояние из мили в километры
 */
namespace Mili_Kilometres
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //Нажатие клавиши в поле редактирования
        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            /*
             * Правильными символами является цифры, Enter, Backspace
             * точку заменяем на цифру
             * чтобы запрещенный символ не отображался в поле редактирования присвоим значение true свойству Handled параметра е
             * 
             */

            if (e.KeyChar >= '0' && (e.KeyChar <= '9'))
            {
                //цифра
                return;
            }

            if (e.KeyChar == '.')
            {
                //точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    //запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                //Enter, Backspace, Esc
                if (e.KeyChar == (char)Keys.Enter)
                {
                    //нажата клавиша Enter
                    //Установить курсор на кнопку ОК
                    button1.Focus();
                }
                return;
            }

            //остальные символы запрещены
            e.Handled = true;
        }
        //Щелчок по кнопке ОК
        private void button1_Click_1(object sender, EventArgs e)
        {
            double mile;        //мили
            double km;          //километры

            /*
             * Если в редактировании нет данных
             * то при попытке прелбразовать пустую строку в число возникнет исключние
             */
            try
            {
                mile = Convert.ToDouble(textBox1.Text);
                km = checked(mile * 1.609344);
                label2.Text = km.ToString("n") + " km.";
            }
            catch
            {
                //обработка исключения
                //перемещаем курсор в поле редактирования
                textBox1.Focus();
            }
        }
    }
}
