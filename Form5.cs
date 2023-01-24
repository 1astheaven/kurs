using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form5 : Form
    {
        public List<User> list = new List<User>();

        public User user = new User();
        public Form5()
        {
            InitializeComponent();
            if (Serializer.IsFile("users.txt"))
            {
                list = Serializer.LoadFromFile("users.txt");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            user.Login = textBox1.Text;
            user.Pass = textBox2.Text;
            foreach (var user in list)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Не введен логин или пароль");
                    return;
                }
                if (user.Login == textBox1.Text)
                {
                    MessageBox.Show("Логин уже существует, введите другой");
                    return;
                }
            }
            list.Add(user);
            Serializer.SaveToFile("users.txt", list);
            Form2 singin = new Form2();
            MessageBox.Show("Регистрация успешна");
            this.Hide();
            singin.Show();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
