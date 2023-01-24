using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WinFormsApp2
{
    public partial class Form3 : Form
    {
        private const string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        //Метод для переворачивания строки
        private string Reverse(string inputText)
        {
            //Переменная для хранения результата
            var reversedText = string.Empty;
            foreach (var s in inputText)
            {
                //Добавляем символ в начало строки
                reversedText = s + reversedText;
            }

            return reversedText;
        }

        //Метод шифрования/дешифрования
        public string EncryptDecrypt(string text, string symbols, string cipher)
        {
            //Перевод текст в нижний регистр
            text = text.ToLower();

            var outputText = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                //Поиск позиции символа в строке алфавита
                var index = symbols.IndexOf(text[i]);
                if (index >= 0)
                {
                    //Замена символа на шифр
                    outputText += cipher[index].ToString();
                }
                else outputText += " ";
            }
            return outputText;
        }

        //Шифрование текста
        public string EncryptText(string plainText)
        {
            return EncryptDecrypt(plainText, alphabet, Reverse(alphabet));
        }

        //Расшифровка текста
        public string DecryptText(string encryptedText)
        {
            return EncryptDecrypt(encryptedText, Reverse(alphabet), alphabet);
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Подтверждаете выход?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
             Application.Exit();
            else
             return; 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var atbash = new Form3();
            var message = VvodBox1.Text;
            if(string.IsNullOrEmpty(VvodBox1.Text))
            {
                MessageBox.Show("Введите текст");
                return;
            }
            var encryptedMessage = atbash.EncryptText(message);
            var decryptedMessage = atbash.DecryptText(encryptedMessage);
            richTextBox1.Text = "Зашифрованное сообщение:" + "\r\n" + Convert.ToString(encryptedMessage) + "\r\n" + "\r\n" + "Расшифрованное сообщение:" + "\r\n" + Convert.ToString(decryptedMessage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            VvodBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа предназначена для шифрования/расшифровки текста методом Атбаш." + "\r\n" + 
                            "Для распознования текста введите его в поле Шифрование. Для получения результата нажмите на кнопку Ввести." + "\r\n" + 
                            "В окне Результат будет отображена расшифровка/шифрование введенного Вами текста." + "\r\n" + 
                            "Нажмите Сбросить, чтобы ввести новый текст." + "\r\n" + 
                            "Нажмите Выход, чтобы выйти из программы", "Справка");
        }
    }
}
