using HashPasswords;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_Gusarova_Pr_25._106
{
    // Переносим директивы работы с БД прямо внутрь пространства имён формы
    using System.Data.Entity;
    using _5_Gusarova_Pr_25._106.Models;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void firstname_Click(object sender, EventArgs e) { }
        private void lblHash_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка полей
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            try
            {
                // Хешируем пароль
                string hashedPass = PasswordHasher.GetHash(txtPassword.Text);
                lblHash.Text = "Хеш: " + hashedPass;

                // Создаем пользователя
                User newUser = new User
                {
                    Login = Guid.NewGuid(),

                    // Пароль переводим в массив байтов
                    PasswordHash = Encoding.UTF8.GetBytes(hashedPass)
                };

                // 4. Сохраняем в БД
                var db = Helper.GetContext();
                db.User.Add(newUser);
                db.SaveChanges();

                MessageBox.Show("Пользователь успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}