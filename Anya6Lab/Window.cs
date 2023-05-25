using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anya6Lab
{
    public partial class Window : Form
    {
        //Переменные позиции мыши и нажатой кнопки мыши
        private Point mouseOffset;
        private bool isMouseDown = false;
        //Проверка на то, что пользователь зашел в программу

        public Window()
        {
            InitializeComponent();
        }

        //Если левая кнопка мыши нажата, то получаем позицию окна и мыши
        private void Tree_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }
        //Если мышь в этот момент двигается, то двигаем приблизительно по позиции курсора
        private void Tree_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        //Если левая кнопка мыши отпущена, то окно больше не двигается
        private void Tree_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        //Событие закрытия окна
        private void CloseWindow(object sender, MouseEventArgs e)
        {
            Environment.Exit(0);
        }
        //Событие скрытия окна
        private void HideWindow(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FirstStart(object sender, EventArgs e)
        {
            Windows.Login Login = new Windows.Login();
            Login.MdiParent = this;
            Login.Show();
        }

        private void StatusChecker_Tick(object sender, EventArgs e)
        {
            switch(Settings.WindowIndex)
            {
                case 1:
                    Windows.MainMenu MainMenu = new Windows.MainMenu();
                    MainMenu.MdiParent = this;
                    MainMenu.Show();
                    Settings.WindowIndex = 0;
                    break;
                case 2:
                    Windows.TableView DataSender = new Windows.TableView();
                    DataSender.MdiParent = this;
                    DataSender.Show();
                    Settings.WindowIndex = 0;
                    break;
            }
        }
    }
}
