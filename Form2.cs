using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        public List<User> list = new List<User>();
        public Form2()
        {
            InitializeComponent();
            if (Serializer.IsFile("users.txt"))
            {
                list = Serializer.LoadFromFile("users.txt");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var user in list)
            {
                if (string.IsNullOrEmpty(loginField.Text) || string.IsNullOrEmpty(passField.Text))
                {
                    MessageBox.Show("Не введен логин или пароль");
                    return;
                }
                if (user.Login == loginField.Text && user.Pass == passField.Text)
                {
                    MessageBox.Show("Вход выполнен");
                    this.Hide();
                    Form3 mf = new Form3();
                    mf.Show();
                    return;
                }
                //if (user.Login != loginField.Text || user.Pass != passField.Text)
                //{
                //    MessageBox.Show("Неверный логин или пароль");
                //    return;
                //}
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа предназначена для шифрования/расшифровки текста методом Атбаш." + "\r\n" +
                            "Для распознования текста введите его в поле Шифрование. Для получения результата нажмите на кнопку Ввести." + "\r\n" +
                            "В окне Результат будет отображена расшифровка/шифрование введенного Вами текста." + "\r\n" +
                            "Нажмите Сбросить, чтобы ввести новый текст." + "\r\n" +
                            "Нажмите Выход, чтобы выйти из программы", "Справка");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 frm5 = new Form5();
            this.Hide();
            frm5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private object FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        private void Add(User user)
        {
            throw new NotImplementedException();
        }

        private bool Any(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
