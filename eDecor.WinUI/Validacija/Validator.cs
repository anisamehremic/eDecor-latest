using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI.Validacija
{
    public class Validator
    {
        public static void ObaveznoPoljeTxt(TextBox textBox, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                err.SetError(textBox, poruka);
                e.Cancel = true;
            }
            else
            {
                err.SetError(textBox, null);
            }
        }
        public static void KorisnickoIme(TextBox textBox, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text.Length < 3)
            {
                err.SetError(textBox, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                err.SetError(textBox, null);
            }
        }
        public static void ObaveznoPoljeMtxt(MaskedTextBox textBox, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                err.SetError(textBox, poruka);
                e.Cancel = true;
            }
            else
            {
                err.SetError(textBox, null);
            }
        }
        public static void ObaveznoPoljeDtp(DateTimePicker dtp, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(dtp.Text))
            {
                err.SetError(dtp, poruka);
                e.Cancel = true;
            }
            else
            {
                err.SetError(dtp, null);
            }
        }
        public static void ObaveznoPoljeCmb(ComboBox cmb, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (cmb.SelectedIndex<=0)
            {
                err.SetError(cmb, poruka);
                e.Cancel = true;
            }
            else
            {
                err.SetError(cmb, null);
            }
        }
        public static void ObaveznoPoljeClb(CheckedListBox clb, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (clb.CheckedItems.Count == 0)
            {
                err.SetError(clb, poruka);
                e.Cancel = true;
            }
            else
            {
                err.SetError(clb, null);
            }
        }
        public static void ObaveznoPoljeRtxt(RichTextBox rtxt, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(rtxt.Text))
            {
                err.SetError(rtxt, poruka);
                e.Cancel = true;
            }
            else
            {
                err.SetError(rtxt, null);
            }
        }

        public static void ObaveznoPoljeNumeric(NumericUpDown numeric, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (numeric.Value==0)
            {
                err.SetError(numeric, poruka);
                e.Cancel = true;
            }
            else
            {
                err.SetError(numeric, null);
            }
        }
    }
}
