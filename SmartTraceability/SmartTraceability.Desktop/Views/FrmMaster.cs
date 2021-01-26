 
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SmartTraceability.Desktop.Views
{
    public partial class FrmMaster : Form
    {
        //Fields Menu
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currenteChildForm;

        //Ctor
        public FrmMaster()
        {
            InitializeComponent();

            //Menu
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(110, 5);
            pnlMenu.Controls.Add(leftBorderBtn);

            Reset();

            //Form
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                currentBtn = (IconButton)senderBtn;
                //currentBtn.ForeColor = color;
                //currentBtn.ForeColor = Color.FromArgb(179, 218, 255);
                currentBtn.ForeColor = Color.FromArgb(26, 117, 255);
                currentBtn.IconColor = color;
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                //leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                //leftBorderBtn.Location = new Point(currentBtn.Location.X, 0);
                leftBorderBtn.Location = new Point(currentBtn.Location.X, (currentBtn.Height - 5));
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                //currentBtn.ForeColor = Color.White;
                //currentBtn.IconColor = Color.White;
                currentBtn.ForeColor = Color.FromArgb(51, 153, 255);
                currentBtn.IconColor = Color.FromArgb(51, 153, 255);
                //currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                //currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void Reset()
        {
            ActivateButton(btnHome, Color.FromArgb(51, 153, 255));
            OpenChildForm(new FrmReader());
            lblTitleFormChild.Text = "Home";
        }

        private void OpenChildForm(Form childForm)
        {
            if (currenteChildForm != null)
            {
                if (currenteChildForm.Text == childForm.Text)
                {
                    //notifyIcon1.ShowBalloonTip(100, "Smart Traceability", "Activo!", ToolTipIcon.Info);
                    WindowState = FormWindowState.Normal;
                    return;
                }

                if (currenteChildForm.Text != "Home")
                {
                    //open only form
                    currenteChildForm.Close();
                }
            }

            currenteChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleFormChild.Text = childForm.Text;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, Color.FromArgb(0, 204, 255));
            ActivateButton(sender, Color.FromArgb(51, 153, 255));
            OpenChildForm(new FrmReader());
        }

        //private void btnSettings_Click(object sender, EventArgs e)
        //{
        //    //ActivateButton(sender, Color.FromArgb(51, 153, 255));
        //    ////OpenChildForm(new FrmSettings());
        //    //OpenChildForm(new FrmServiceController());

        //    FrmServiceController frm = new FrmServiceController();
        //    frm.ShowDialog(this);
        //    frm.Dispose();
        //}

        //private void btnInfo_Click(object sender, EventArgs e)
        //{
        //    //ActivateButton(sender, Color.FromArgb(51, 153, 255));
        //    FrmServiceController frm = new FrmServiceController();
        //    frm.ShowDialog(this);
        //    frm.Dispose();
        //}

        //private void btnContact_Click(object sender, EventArgs e)
        //{
        //    //ActivateButton(sender, Color.FromArgb(0, 153, 255));
        //    //ActivateButton(sender, Color.FromArgb(51, 153, 255));
        //    //OpenChildForm(new FrmContact());

        //    FrmContact frm = new FrmContact();
        //    //frm.TopLevel = false;
        //    //frm.FormBorderStyle = FormBorderStyle.None;
        //    //frm.ShowIcon = false;

        //    frm.ShowDialog(this);
        //    frm.Dispose();
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, Color.Aqua);
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FrmInicio_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnWindowRestore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //this.Show();
        //    //ActivateButton(sender, Color.FromArgb(51, 153, 255));
        //    OpenChildForm(new FrmReader());
        //}
    }
}
