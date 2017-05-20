using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Registro_Viajes
{
    public partial class registroViaje : Form
    {
        public registroViaje()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Me.Label7.Text = CStr(Me.MonthCalendar1.SelectionRange.Start)
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Me.Label7.Text = CStr(Me.DateTimePicker1.Value)
        }
    }
}
