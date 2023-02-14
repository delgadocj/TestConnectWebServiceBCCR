using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestConnectWebServiceBCCR
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            this.txtCode.Focus();
            this.dtDate.Value = DateTime.Now;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestConnectWebServiceBCCR.wsindicadoreseconomicos.wsindicadoreseconomicos mytestobject = new TestConnectWebServiceBCCR.wsindicadoreseconomicos.wsindicadoreseconomicos();
            try
            {

                if (ValidateInput())
                {
                    txtResult.Text = mytestobject.ObtenerIndicadoresEconomicosXML(
                        this.txtCode.Text, 
                        this.dtDate.Value.ToString("dd/MM/yyyy"), 
                        this.dtDate.Value.ToString("dd/MM/yyyy"), 
                        "Test", 
                        "N", 
                        this.txtEmail.Text, 
                        this.txtToken.Text);
                }

            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally {
                mytestobject.Dispose();                
            }
                        
        }

        private bool ValidateInput() {
            if (this.txtCode.Text == String.Empty) {
                MessageBox.Show("The code is required.");
                return false;
            }

            if (this.txtEmail.Text == String.Empty)
            {
                MessageBox.Show("The email is required.");
                return false;
            }

            if (this.txtToken.Text == String.Empty)
            {
                MessageBox.Show("The token is required.");
                return false;
            }

            return true;
        }
    }
}
