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
using System.Windows.Shapes;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для RegAuth.xaml
    /// </summary>
    public partial class RegAuth : Window
    {
        internal SqlConnection connection = null;

        public RegAuth()
        {
            InitializeComponent();           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnect();
            CheckBox.Checked += (s,a) => { mailTextBox.IsEnabled = true; AuthButton.IsEnabled = false; CodeTextBox.IsEnabled = false; RegButton.IsEnabled = true; };
            CheckBox.Unchecked += (s, a) => { mailTextBox.IsEnabled = false; AuthButton.IsEnabled = true; CodeTextBox.IsEnabled = true; RegButton.IsEnabled = false; };
        }



        async void SqlConnect()
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Vladimir"].ConnectionString);
                await connection.OpenAsync();
                if (connection.State == ConnectionState.Open)
                MessageBox.Show("Добро пожаловать", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Проверьте подключение к базе данных. Подробнее об ошибке: {ex.Message}", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(NameTextBox.Text != String.Empty && LastNameTextBox.Text != String.Empty && CodeTextBox.Text != String.Empty)
                {
                    SqlCommand command = new SqlCommand(@"SELECT * FROM Employee WHERE EName = @EName AND ELName = @ELName AND AccessCode = @AccessCode", connection);
                    command.Parameters.AddWithValue("@EName", NameTextBox.Text);
                    command.Parameters.AddWithValue("@ELName", LastNameTextBox.Text);
                    command.Parameters.AddWithValue("@AccessCode", CodeTextBox.Text);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("Авторизация прошла успешно!", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Information);                     
                        General general = new General();
                        general.Show();
                        Close();
                        dr.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Проверьте корректность введенных данных!", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error);
                        dr.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены! Будьте внимательны.", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                                  
            }
            catch(Exception ex) { MessageBox.Show($"Ошибка. Подробнее об ошибке: {ex.Message}", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error); }
            
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameTextBox.Text != String.Empty && LastNameTextBox.Text != String.Empty && mailTextBox.Text != String.Empty)
                {
                    Mail mail = new Mail(mailTextBox.Text);
                    mail.Send(NameTextBox.Text, LastNameTextBox.Text);

                    SqlCommand command = new SqlCommand(@"INSERT INTO Employee (EName, ELName, AccessCode) VALUES (@EName, @ELName, @AccessCode)", connection);
                    command.Parameters.AddWithValue("@EName", NameTextBox.Text);
                    command.Parameters.AddWithValue("@ELName", LastNameTextBox.Text);
                    command.Parameters.AddWithValue("@AccessCode", mail.AccessCode);
                    int num = command.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Регистрация завершена! Ваш новый код доступа отправлен на вашу электронную почту. Теперь можете авторизоваться. Спасибо!", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены! Будьте внимательны.", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex) { }
            
        }

        private void CodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CodeTextBox.Text.Length < 6)
            {
                IndicateCode.Content = "X";
                IndicateCode.Foreground = Brushes.Red;
            }
            else
            {
                IndicateCode.Content = "Требование выполняется!";
                IndicateCode.Foreground = Brushes.Green;
            }
        }

        private void NameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) return;
            else
                e.Handled = true;
        }

        private void CodeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) return;
            else
                e.Handled = true;
        }

        private void LastNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) return;
            else
                e.Handled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connection.Close();
        }
    }
}
