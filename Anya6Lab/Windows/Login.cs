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
    public partial class Login : Form
    {
        const string Username = "Admin";
        const string Password = "Qwerty123";
        int tryes = 4;
        public Login()
        {
            InitializeComponent();
        }

        private void CheckUser(object sender, MouseEventArgs e)
        {
            //Такая, некая заглушка того, что у нас есть система входа)
            if (Username == LoginBox.Text)
            {
                if (Password == PasswordBox.Text)
                {
                    this.Close();
                    Settings.WindowIndex = 1;
                }
                else { tryes--; ErrorLabel.Visible = true; TryesLabel.Visible = true; TryesLabel.Text = "ОСТАЛОСЬ ПОПЫТОК: " + tryes; }
                if (tryes == 0)
                {
                    MessageBox.Show("Плохишам вход запрещен");
                    Environment.Exit(0);
                }
            }
            else { tryes--; ErrorLabel.Visible = true; TryesLabel.Visible = true; TryesLabel.Text = "ОСТАЛОСЬ ПОПЫТОК: " + tryes; }
            if (tryes == 0)
            {
                MessageBox.Show("Плохишам вход запрещен");
                Environment.Exit(0);
            }
        }
    }
}
