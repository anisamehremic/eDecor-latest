using eDecor.WinUI.Drzave;
using eDecor.WinUI.Gradovi;
using eDecor.WinUI.Izvjestaji;
using eDecor.WinUI.Kategorije;
using eDecor.WinUI.Podkategorije;
using eDecor.WinUI.Korisnici;
using eDecor.WinUI.Klijenti;
using eDecor.WinUI.Notifikacije;
using eDecor.WinUI.Artikli;
using eDecor.WinUI.Ocjene;
using eDecor.WinUI.Pretplate;
using eDecor.WinUI.Rezervacije;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            customizeDesign();
        }

        private Form ActiveForm = null;
        private void OpenChildForm(Form ChildForm)
        {
            //if (ActiveForm != null)
                //ActiveForm.Close();
            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            //ChildForm.FormBorderStyle = FormBorderStyle.None;
            //ChildForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(ChildForm);
            panelChildForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        #region SubMenu
        private void customizeDesign()
        {
            panelKorisniciSubmenu.Visible = false;
            panelKupciSubmenu.Visible = false;
            panelRezervacijeSubmenu.Visible = false;
            panelVozilaSubmenu.Visible = false;
            panelNovostiSubmenu.Visible = false;
            panelPretplateSubmenu.Visible = false;
            panelLokacijeSubmenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelKorisniciSubmenu.Visible == true)
                panelKorisniciSubmenu.Visible = false;
            if (panelKupciSubmenu.Visible == true)
                panelKupciSubmenu.Visible = false;
            if (panelRezervacijeSubmenu.Visible == true)
                panelRezervacijeSubmenu.Visible = false;
            if (panelVozilaSubmenu.Visible == true)
                panelVozilaSubmenu.Visible = false;
            if (panelNovostiSubmenu.Visible == true)
                panelNovostiSubmenu.Visible = false;
            if (panelPretplateSubmenu.Visible == true)
                panelPretplateSubmenu.Visible = false;
            if(panelLokacijeSubmenu.Visible == true)
            panelLokacijeSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        #endregion

        #region KorisniciSubmenu
        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            showSubMenu(panelKorisniciSubmenu);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKorisnici());
            hideSubMenu();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKorisniciDetalji(null));
            hideSubMenu();
        }
        #endregion

        #region KlijentiSubmenu
        private void btnKupaci_Click(object sender, EventArgs e)
        {
            showSubMenu(panelKupciSubmenu);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKlijenti());
            hideSubMenu();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKlijentiDetalji(null));
            hideSubMenu();
        } 
        #endregion

        #region RezervacijeSubmenu
        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            showSubMenu(panelRezervacijeSubmenu);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmRezervacije());
            hideSubMenu();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmRezervacijeDetalji(null));
            hideSubMenu();
        }
        #endregion

        #region ArtikliSubmenu
        private void btnVozila_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVozilaSubmenu);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmArtikli());
            hideSubMenu();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmArtikliDetalji(null));
            hideSubMenu();
        }

        private void btnKategorije_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKategorije());
            hideSubMenu();
        }

        private void btnProizvodjaci_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPodkategorije());
            hideSubMenu();
        }

        private void btnOsiguranja_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPodkategorijeDetalji(null));
            hideSubMenu();
        }
        #endregion

        #region RegistracijeSubmenu
        private void btnRegistracije_Click(object sender, EventArgs e)
        {

            OpenChildForm(new frmOcjene());
            hideSubMenu();
        }
        #endregion

        #region NovostiSubmenu
        private void btnNovosti_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNovostiSubmenu);
        }
        private void button27_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNotifikacije());
            hideSubMenu();
        }
        private void button26_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNotifikacijeDetalji(null));
            hideSubMenu();
        }
        #endregion

        #region PretplateSubmenu
        private void btnPretplate_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPretplateSubmenu);
        }
        private void button32_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPretplate());
            hideSubMenu();
        }
        private void button31_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPretplateDetalji(null));
            hideSubMenu();
        }
        #endregion

        #region LokacijeSubmenu
        private void btnLokacijeMain_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLokacijeSubmenu);
        }

        private void btnGradovi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGradovi(null));
            hideSubMenu();
        }

        private void btnDrzave_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDrzave(null));
            hideSubMenu();
        }
        #endregion

        private void btnIzvjestaji_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmIzvjestaji());
            hideSubMenu();
        }

        private void btnOdjaviSe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region FunkcionalostiForm
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelMenuBarr_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close(); 
        }


        int lx, ly;
        int sw, sh;
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximize.Visible = false;
            btnRestoreDown.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestoreDown_Click(object sender, EventArgs e)
        {
            btnMaximize.Visible = true;
            btnRestoreDown.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

    }
}
