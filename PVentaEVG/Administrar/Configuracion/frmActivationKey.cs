using System;
using System.Collections.Generic;
using POSDLL;
using POSDLL.Security;
using POSDLL.Utilities;
namespace POSApp.Forms
{
    public partial class frmActivationKey : Telerik.WinControls.UI.RadForm
    {
        public frmActivationKey()
        {
            InitializeComponent();
        }
        bool success = false;
        public Boolean Success { get { return success; } }
        EncryptDecrypt cripto = new EncryptDecrypt();//encriptar
        WindowsRegistry reg = new WindowsRegistry();//Desencriptar
        private void frmActivationKey_Load(object sender, EventArgs e)
        {
            ReadINI();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            success = false;
            this.Close();
        }
        void ReadINI()
        {
           
            try
            {
                Dictionary<String, String> CamposLLave = new Dictionary<string, string>();

                String sActivationKey = reg.ReadValue("POS_ActivationKey", "");
                if (!String.IsNullOrEmpty(sActivationKey))

                {
                    String sCadena = fDesencriptaCadena(sActivationKey);
                    String[] sCandenaCampos = sCadena.Split('~');

                    foreach (var item in sCandenaCampos)
                    {
                        CamposLLave.Add(item.Split('/')[0].ToString(), item.Split('/')[1].ToString());

                    }

                    if (CamposLLave["Key"].ToString() == "###mxItSolutionsActivationSistembyBooss###")
                    {
                        txtCliente.Text = "Licencia Activa para: " + CamposLLave["Cliente"].ToString();
                       
                        System.Windows.Forms.MessageBox.Show("Esta copia de MxVentas Esta Activada...");
                    }

                }




            }
            catch (Exception)
            {
                
                throw;
            }
            
            //base de datos
            txtCurrentKey.Text = cripto.Decrypt(reg.ReadValue("POS_ActivationKey", cripto.Encrypt("")));






        }
        void WriteINI()
        {
            //base de datos
            reg.WriteValue("POS_ActivationKey", txtCurrentKey.Text);
            AppSettings.SetValue("Config", "ProcessorId", Class.clsMain.CPUInfo());
            success = true;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WriteINI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            System.Windows.Forms.Clipboard.SetText(txtCadenaSol.Text.Trim());
            System.Windows.Forms.MessageBox.Show("Solicitud de activacion copiado en memoria.");
        }
        private static String fDesencriptaCadena(String sCadena)
        {
            try
            {
                var Aes = new POSDLL.Security.clsEncryptionAES();
                return Aes.Decode(sCadena);

            }
            catch (Exception)
            {

                throw new Exception("Error la cadena de solicitud no es la correcta"); ;
            }
        }

        private static String fEncriptaCadena(String sCadena)
        {
            try
            {
                var Aes = new POSDLL.Security.clsEncryptionAES();
                return Aes.Encode(sCadena);

            }
            catch (Exception)
            {

                throw new Exception("Error la cadena de solicitud no es la correcta"); ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                System.Windows.Forms.MessageBox.Show("El nombre completo de cliente es requerido."); 
            }
            else
            {
                String ScadenaSolicitud = "CpuId/" + Class.clsMain.CPUInfo() + "~" +
                                           "Sistema/mxVentas~" +
                                           "Version/1.0~" +
                                           "Edicion/DEMO~" +
                                           "Funcionalidades/0~" +
                                           "FechaValor/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2,'0') +"-"+ DateTime.Now.Day.ToString().PadLeft(2,'0') + "~" +
                                           "Key/666666~" +
                                           "Cliente/" + txtCliente.Text.Trim();

                String ScadenaEcriptada = fEncriptaCadena(ScadenaSolicitud);

                txtCadenaSol.Text = ScadenaEcriptada;

            }

           

        }

    }
}
