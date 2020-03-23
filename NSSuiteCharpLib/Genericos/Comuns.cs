using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace NSSuiteCSharpLib.Genericos
{
    internal class Comuns
    {
        public static void salvarXML(string xml, string caminho, string nome)
        {
            string localParaSalvar = caminho + nome + ".xml";
            string ConteudoSalvar = xml.Replace(@"\""", "");
            File.WriteAllText(localParaSalvar, ConteudoSalvar);
        }
        public static void salvarPDF(string pdf, string caminho, string nome)
        {
            string localParaSalvar = caminho + nome + ".pdf";
            byte[] bytes = Convert.FromBase64String(pdf);
            if (File.Exists(localParaSalvar))
                File.Delete(localParaSalvar);
            using (BinaryWriter writer = new BinaryWriter(new FileStream(localParaSalvar, FileMode.CreateNew))) 
                writer.Write(bytes, 0, bytes.Length);       
        }
        public static void gravarLinhaLog(string conteudo)
        {
            string caminho = @".\log\";

            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            string data = DateTime.Now.ToShortDateString();
            string hora = DateTime.Now.ToShortTimeString();
            string nomeArq = data.Replace("/", "");

            using (StreamWriter outputFile = new StreamWriter(caminho + nomeArq + ".txt", true))
                outputFile.WriteLine(data + " " + hora + " - " + conteudo);
            
        }

    }
}