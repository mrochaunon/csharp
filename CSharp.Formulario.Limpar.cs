using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.Apoio
{
    public static class Formulario
    {
        public static void Limpar(Control classeControle)
        {
            foreach (Control controleFor in classeControle.Controls)
            {
                
                if (controleFor is TextBoxBase) // Podendo ser: if (controle is TextBox || controle is MaskedTextBox)
                {
                    //controle.Text = string.Empty;
                    //((TextBoxBase)controle).Text = string.Empty; //TextBoxBase = Classe base na Herança.
                    ((TextBoxBase)controleFor).Clear(); //TextBoxBase = Classe base na Herança.
                }
                else if (controleFor is ComboBox)
                {
                    ((ComboBox)controleFor).SelectedIndex = -1; //Conversão = CAST
                }
                else if (controleFor is GroupBox)
                {
                    Limpar(controleFor);
                }
            }
        }

        private static bool DefinirErro(ErrorProvider provedorDeErro, Control controle, String mensagemErro)
        {
            provedorDeErro.SetError(controle, mensagemErro);
            controle.Focus();
            return false;
        }
    }
}
