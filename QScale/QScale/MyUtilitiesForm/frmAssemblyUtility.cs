using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using CustomObjects;

namespace QScale.MyUtilitiesForm
{
    public partial class frmAssemblyUtility : Form
    {
        public frmAssemblyUtility()
        {
            InitializeComponent();
        }

        private void frmAssemblyUtility_Load(object sender, EventArgs e)
        {
            cmbObjectName.DataSource = AssemblyUtility.GetObjectList();
        }

        private void btnGetProperty_Click(object sender, EventArgs e)
        {
            //string SelectedType = cmbObjectName.Text as Type;
            Type t = typeof(TruckIn);

            // enumerate the properties of the type
            foreach (PropertyInfo propInfo in t.GetProperties())
            {
                //Type pt = p.PropertyType;
                string PropName = propInfo.Name;
                string PropType = propInfo.PropertyType.ToString();
                txtPropertyNamesAndType.AppendText(PropName + "-" + PropType + Environment.NewLine);

            }
        }


    }
}
