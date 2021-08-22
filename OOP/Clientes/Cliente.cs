using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes
{
    public class Cliente
    {
        private string nome;
        private string telefone;
        private string cpf;

        public string Nome => this.nome;

        public string Telefone => this.telefone;

        public string CPF => this.cpf;

        public Cliente(string nome, string telefone, string cpf)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.cpf = cpf;
        }
        public void Gravar()
        {
            
            using (var file = File.AppendText(CaminhoArquivo()))
            {
                string data = $"{this.nome};{this.telefone};{this.cpf}";
                file.WriteLine(data);
            }
        }
        private static string CaminhoArquivo() 
        {
            return ConfigurationManager.AppSettings["db"];
        }
        public static List<Cliente> LerClientes()
        {
            var clientes = new List<Cliente>();
            if (File.Exists(CaminhoArquivo()))
            {
                using(StreamReader arquivo = File.OpenText(CaminhoArquivo()))
                {
                    string linha;
                    int count = 0;
                    while((linha = arquivo.ReadLine()) != null)
                    {
                        count++;
                        if (count == 1)
                            continue;
                        string[] dados = linha.Split(";");

                        clientes.Add(new Cliente(dados[0], dados[1], dados[2]));
                    }

                }
            }
           
            return clientes;
        }
    }
}
