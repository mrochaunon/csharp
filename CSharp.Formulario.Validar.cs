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
        public static bool Validar(Form formulario, ErrorProvider provedorDeErro)
        {
            var resultadoValidacao = true;
            provedorDeErro.Clear();

            foreach (Control controle in formulario.Controls)
            {
                if (controle.Tag == null)
                {
                    continue;
                }

                var controleTag = controle.Tag.ToString().ToUpper();

                if (controleTag.Contains("*") && string.IsNullOrEmpty(controle.Text))
                {
                    resultadoValidacao = DefinirErro(provedorDeErro, controle, "Campo obrigatório.");
                }
                else
                {
                    if (controleTag.Contains("ANO"))
                    {
                        if (!Regex.IsMatch(controle.Text, @"^[0-9]{4}$")) //Regular Expressions, vem conteudo em: http://piazinho.com.br
                        {
                            resultadoValidacao = DefinirErro(provedorDeErro, controle, "Digite o ano no formado 'YYYY'.");
                        }
                    }
                    else if (controleTag.Contains("PLACA"))
                        {                                        //  AAA - 0000
                            if (!Regex.IsMatch(controle.Text, @"^[A-Z]{3}-?[0-9]{4}$"))
                            {
                                resultadoValidacao = DefinirErro(provedorDeErro, controle, "Digite a placa no formado 'AAA-0000'.");
                            }
                        }
                }
            }
            return resultadoValidacao;
        }
        

        private static bool DefinirErro(ErrorProvider provedorDeErro, Control controle, String mensagemErro)
        {
            provedorDeErro.SetError(controle, mensagemErro);
            controle.Focus();
            return false;
        }
    }
}
