using System;
using System.Text;

namespace ModuloPesquisador.Infra
{
    public class AppAuxGrifaTexto
    {

        public static String ProcessaTexto(String valorTexto,String textPesquisa)
        {

            if (textPesquisa != null) {

                String[] texto = textLimpo(textPesquisa).Split();
                String[] valorPesquisa = textLimpo(valorTexto).Split();
                String[] textoOriginal = valorTexto.Split();

                for (int i = 0; i < texto.Length; i++)
                {
                    if (texto[i].Length > 2)
                    {
                        for (int j = 0; j < valorPesquisa.Length; j++)
                        {
                            int posicao = valorPesquisa[j].indexOf(texto[i]);
                            if (posicao > -1)
                            {
                                String a = textoOriginal[j];

                                a = a.substring(0, posicao) + "<span style='background-color: #FFFF00'>" + a.substring(posicao, posicao + texto[i].Length) + "</span>" + a.substring(posicao + texto[i].Length);
                                textoOriginal[j] = a;
                            }
                        }
                    }
                }
                return montaString(textoOriginal); ;
            }
            else
            {
                return valorTexto;
            }
        }

        private static string textLimpo(String texto)
        {   
            return Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(texto)).ToUpper();
        }

        private static string montaString(String [] valor)
        {
            String resultado = "";

            for (int i = 0; i< valor.Length;i++)
            {
                resultado += valor[i] + " ";
            }

            return resultado.Trim();
        }
    }
}
