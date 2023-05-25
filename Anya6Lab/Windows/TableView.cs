using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Collections;

namespace Anya6Lab.Windows
{
    public partial class TableView : Form
    {
        public static readonly string Root = Environment.CurrentDirectory;
        public string query = Settings.DBQuery;
        public SQLiteConnection connect = new SQLiteConnection("data source=" + Root + @"\test_db");
        public DataTable dt = new DataTable();
        public DataSet dst = new DataSet();
        public SQLiteCommand cmd = new SQLiteCommand();
        public SQLiteDataAdapter da = new SQLiteDataAdapter();
        public TableView()
        {
            InitializeComponent();
        }

        private void LoadData(object sender, EventArgs e)
        {
            connect.Open();
            cmd = new SQLiteCommand(query, connect);
            da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            DataGrid.DataSource = dt.DefaultView;
            connect.Close();
        }

        private void CloseForm(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
