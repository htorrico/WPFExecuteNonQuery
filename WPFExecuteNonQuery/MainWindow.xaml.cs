using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WPFExecuteNonQuery
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=HUGO-PC\\SQLEXPRESS;Initial Catalog=Neptuno5;User ID=userTecsup;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertarCategorias", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcategoria", int.Parse(txtIdCategoria.Text));
                    cmd.Parameters.AddWithValue("@nombrecategoria", txtNombreCategoria.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@CodCategoria", txtCodCategoria.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoría ingresada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la categoría: " + ex.Message);
            }
        }
    }
}
