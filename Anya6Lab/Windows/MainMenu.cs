using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anya6Lab.Windows
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void OpenDataSender(object sender, MouseEventArgs e)
        {
            Settings.WindowIndex = 2;
            Settings.DBQuery = "SELECT * FROM поставщики";
        }

        private void OpenGoods(object sender, MouseEventArgs e)
        {
            Settings.WindowIndex = 2;
            Settings.DBQuery = "SELECT * FROM топливо";
        }

        private void OpenWayList(object sender, MouseEventArgs e)
        {
            Settings.WindowIndex = 2;
            Settings.DBQuery = "SELECT путевой_лист.номер_путевого_листа, топливо.марка_топлива, поставщики.название_поставщика, путевой_лист.дата FROM путевой_лист INNER JOIN поставщики ON поставщики.id_поставщиков = путевой_лист.id_поставщиков INNER JOIN топливо ON топливо.id_топлива = путевой_лист.id_топлива";
        }

        private void InfoWindow(object sender, MouseEventArgs e)
        {
            MessageBox.Show("В разработке :)");
        }
    }
}
