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

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для General.xaml
    /// </summary>
    public partial class General : Window
    {
        internal SqlConnection connection = null;

        public General()
        {
            InitializeComponent();
        }

         void SqlConnect()
         {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Vladimir"].ConnectionString);
                connection.Open();
            }
            catch (Exception ex) { MessageBox.Show($"Проверьте подключение к базе данных. Подробнее об ошибке: {ex.Message}", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error); }
         }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnect();
            LoadData();
          
 
        }

        private void LoadData()
        {
            try
            {
                SqlCommand command = new SqlCommand(@"SELECT EName as 'Имя сотрудника', ELName as 'Фамилия сотрудника', AccessCode as 'Код доступа', Dolj.DoljName as 'Должность' FROM Employee INNER JOIN Dolj ON DOLJ_ID = Dolj.ID", connection);
                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Employee"); 
                dataAdp.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private bool CheckData()
        {
            SqlCommand com = new SqlCommand(@"SELECT EName, ELName, AccessCode FROM Employee WHERE EName = @EName AND ELName = @ELName AND AccessCode = @AccessCode", connection);
            com.Parameters.AddWithValue("@EName", NameTextBox.Text);
            com.Parameters.AddWithValue("@ELName", LastNameTextBox.Text);
            com.Parameters.AddWithValue("@AccessCode", CodeTextBox.Text);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                return false;
                
            }
            else
            {
                dr.Close();
                return true;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
          if(NameTextBox.Text != String.Empty && LastNameTextBox.Text != String.Empty && CodeTextBox.Text != String.Empty && DoljComboBox.Text != String.Empty)
            {
                if (CheckData() == true)
                {
                    SqlCommand command = new SqlCommand(@"INSERT INTO Employee (EName, ELName, AccessCode, DOLJ_ID) VALUES (@EName, @ELName, @AccessCode, @DOLJ_ID)", connection);
                    command.Parameters.AddWithValue("@EName", NameTextBox.Text);
                    command.Parameters.AddWithValue("@ELName", LastNameTextBox.Text);
                    command.Parameters.AddWithValue("@AccessCode", CodeTextBox.Text);
                    switch (DoljComboBox.Text)
                    {
                        case "Младший программист":
                            command.Parameters.AddWithValue("@DOLJ_ID", 1);
                            break;
                        case "Джун":
                            command.Parameters.AddWithValue("@DOLJ_ID", 2);
                            break;
                        case "Миддл":
                            command.Parameters.AddWithValue("@DOLJ_ID", 3);
                            break;
                        case "Сеньор":
                            command.Parameters.AddWithValue("@DOLJ_ID", 4);
                            break;
                        case "Тимлид":
                            command.Parameters.AddWithValue("@DOLJ_ID", 5);
                            break;
                        default:
                            MessageBox.Show("Ошибка.", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                    int num = command.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show($"Задействовано {num} строк(а)", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Information);
                       
                        LoadData();
                    }
                }
                else { MessageBox.Show("Данный сотрудник уже есть в базе данных!", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error); }
           }
            else
            {
                MessageBox.Show("Не все поля заполнены!", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
               
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command = new SqlCommand(@"DELETE FROM Employee WHERE EName = @EName AND ELName = @ELName AND AccessCode = @AccessCode", connection);
            command.Parameters.AddWithValue("@EName", NameTextBox.Text);
            command.Parameters.AddWithValue("@ELName", LastNameTextBox.Text);
            command.Parameters.AddWithValue("@AccessCode", CodeTextBox.Text);
            int num = command.ExecuteNonQuery();
            if (num > 0)
            {
                MessageBox.Show($"Задействовано {num} строк(а)", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Information);
                NameTextBox.Text = String.Empty;
                LastNameTextBox.Text = String.Empty;
                CodeTextBox.Text = String.Empty;
                LoadData();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGrid.SelectedItems[0];
                NameTextBox.Text = row["Имя сотрудника"].ToString();
                LastNameTextBox.Text = row["Фамилия сотрудника"].ToString();
                CodeTextBox.Text = row["Код доступа"].ToString();
                DoljComboBox.Text = row["Должность"].ToString();
            }
            catch(Exception ex) { MessageBox.Show("Пустая строка!", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Error); }
                


        }

        private void NameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) return;
            else
                e.Handled = true;
        }

        private void LastNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void SearchTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {   
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox.Text != "")
            {
                SqlCommand command = new SqlCommand($@"SELECT * FROM Employee WHERE EName LIKE '{SearchTextBox.Text}%' or ELName LIKE '{SearchTextBox.Text}%' or AccessCode LIKE '{SearchTextBox.Text}%' or DOLJ_ID LIKE '{SearchTextBox.Text}%'", connection);
                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Employee");
                dt.Load(command.ExecuteReader());
                DataGrid.ItemsSource = dt.DefaultView;
            }
            else 
            {
                LoadData();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Employee SET AccessCode = @AccessCode WHERE EName = @EName AND ELName = @ELName", connection);
            command.Parameters.AddWithValue("@EName", NameTextBox.Text);
            command.Parameters.AddWithValue("@ELName", LastNameTextBox.Text);
            command.Parameters.AddWithValue("@AccessCode", CodeTextBox.Text);
            int num = command.ExecuteNonQuery();
            if (num > 0)
            {
                MessageBox.Show($"Задействовано {num} строк(а)", "Администрация Shadow Company", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            connection.Close();          
            Application.Current.Shutdown();
        }
    }
}
