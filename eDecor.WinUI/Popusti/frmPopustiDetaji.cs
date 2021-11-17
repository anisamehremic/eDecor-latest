using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI.Popusti
{
    public partial class frmPopustiDetaji : Form
    {
        private readonly APIService _popustiService = new APIService("Popusti");
        private int? _id = null;
        public frmPopustiDetaji(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmPopustiDetaji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var result = await _popustiService.GetById<Model.Popusti>(_id);

                txtKod.Text = result.Kod;
                numPopist.Value = result.Popust.Value;
                cbStatus.Checked = result.Status;
            }
            else {
                txtKod.Text = "Dodaj popust";
            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) {

                var request = new PopustiUpsertRequest()
                {
                    Status = cbStatus.Checked,
                    Popust = (decimal)numPopist.Value,
                    Datum = DateTime.Now
                };

                Model.Popusti entity = null;
                if (_id.HasValue)
                {
                    request.Kod = txtKod.Text;
                    entity = await _popustiService.Update<Model.Popusti>(_id.Value, request);
                }
                else
                {
                    Guid g = Guid.NewGuid();
                    string GuidString = Convert.ToBase64String(g.ToByteArray());
                    GuidString = GuidString.Replace("=", "");
                    GuidString = GuidString.Replace("+", "");
                    GuidString = GuidString.Replace("/", "");

                    request.Kod = GuidString;
                    entity = await _popustiService.Insert<Model.Popusti>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }
                this.Close();
            }
        }
        private void numPopist_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeNumeric(sender as NumericUpDown, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }
    }
}
