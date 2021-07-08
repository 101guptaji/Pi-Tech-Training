using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for CountryStateComboBox.xaml
    /// </summary>
    public partial class CountryStateComboBox : Window
    {
        SqlConnection conn =  new SqlConnection(ConfigurationManager.ConnectionStrings["trainingConnStr"].ConnectionString);
        DataSet ds = null;
        public CountryStateComboBox()
        {
            InitializeComponent();
            BindComboBox(cmbCountry);
        }

        public void BindComboBox(ComboBox combo)
        {
            
            SqlDataAdapter da = new SqlDataAdapter("Select * from Country", conn);
            ds = new DataSet();
            da.Fill(ds, "Country");
            combo.ItemsSource = ds.Tables["Country"].DefaultView;
            combo.DisplayMemberPath = ds.Tables["Country"].Columns["CON_NAME"].ToString();
            combo.SelectedValuePath = ds.Tables["Country"].Columns["CON_ID"].ToString();
        }
        private void cmbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbCountry.SelectedValue!=null)
            {
                
                int CountryID = int.Parse(cmbCountry.SelectedValue.ToString());
                LoadImage(CountryID);
                txtScapital.Text = string.Empty;
                BindStates(CountryID);
            }

            //object selected = cmbCountry.SelectedItem;
            //DataRow row = ((DataRowView)selected).Row;

            //// Get the raw bytes of the image
            //byte[] photoSource = (byte[])row["FLAG"];

            //// Create the bitmap object
            //// NOTE: This is *not* a GDI+ Bitmap object
            //BitmapImage bitmap = new BitmapImage();
            //MemoryStream strm = new MemoryStream();

            //int offset = 78;
            //strm.Write(photoSource, offset, photoSource.Length - offset);

            //// Read the image into the bitmap object
            //bitmap.BeginInit();
            //bitmap.StreamSource = strm;
            //bitmap.EndInit();

            //// Set the Image with the Bitmap
            //Cflag.Source = bitmap;




            //cmbState.SelectedValue = string.Empty;
            //txtScapital.Text = string.Empty;
            //cmbState.Items.Clear();
            ////State binding
            ////cmbState.ItemsSource.
            //SqlDataAdapter da = new SqlDataAdapter($"Select * from State where CON_ID='{CountryId}'", conn);
            //da.Fill(ds, "State");
            //cmbState.ItemsSource = ds.Tables["State"].DefaultView;
            //cmbState.DisplayMemberPath = ds.Tables["State"].Columns["State_Name"].ToString();
            //cmbState.SelectedValuePath = ds.Tables["State"].Columns["State_ID"].ToString();


        }

        private void BindStates(int countryID)
        {

            if (ds.Tables.Contains("State"))
                ds.Tables.Remove("State");
            SqlDataAdapter da = new SqlDataAdapter($"Select * from State where CON_ID='{countryID}'", conn);
            da.Fill(ds, "State");
            cmbState.DataContext = ds.Tables["State"];
            cmbState.DisplayMemberPath = ds.Tables["State"].Columns["State_Name"].ToString();
            cmbState.SelectedValuePath = ds.Tables["State"].Columns["State_ID"].ToString();

            //string sql = "Select * from State where CON_ID = @id";
            //SqlCommand command = new SqlCommand(sql, conn);
            //command.Parameters.AddWithValue("id", countryID);
            //conn.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //DataTable table = new DataTable();
            //table.Load(reader);
            //conn.Close();

            //cmbState.DataContext = table;
            //cmbState.DisplayMemberPath = "STATE_NAME";
            //cmbState.SelectedValuePath = "STATE_ID";
        }

        private void LoadImage(int countryID)
        {
            string express = $"CON_ID='{countryID}'";
            DataRow[] rows = ds.Tables["Country"].Select(express);

            txtCcapital.Text = rows[0]["CAPITAL"].ToString();

            byte[] photo = (byte[])rows[0]["FLAG"];
            MemoryStream stream = new MemoryStream(photo);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            stream.Seek(0, SeekOrigin.Begin);
            bitmap.StreamSource = stream;
            bitmap.EndInit();
            Cflag.Source = bitmap;
        }

        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbState.SelectedValue != null)
            {
                int sID = int.Parse(cmbState.SelectedValue.ToString());
                string express = $"State_ID='{sID}'";
                DataRow[] rows = ds.Tables["State"].Select(express);

                txtScapital.Text = rows[0]["S_Capital"].ToString();
            }

        }
    }
}
