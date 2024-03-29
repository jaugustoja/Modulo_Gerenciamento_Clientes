﻿using Projeto_Controle_Vendas.br.com.projeto.dao;
using Projeto_Controle_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.view
{
    public partial class Frmclientes : Form
    {
        public Frmclientes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            
            obj.Nome = textNome.Text;
            obj.RG = maskedTextRG.Text;
            obj.CPF = maskedTextCPF.Text;
            obj.Email = textEmail.Text;
            obj.Telefone = maskedTextTelefone.Text;
            obj.Celular = maskedTextCelular.Text;
            obj.CEP = maskedTextCEP.Text;
            obj.Endereco = textEndereco.Text;
            obj.Numero = int.Parse(textNumero.Text);
            obj.Complemento = textComplemento.Text;
            obj.Bairro = textBairro.Text;
            obj.Cidade = textCidade.Text;
            obj.Estado = comboEstado.Text;

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);
        }

        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frmclientes_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = textNameConsulta.Text;

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.buscarClientePorNome(nome);

            if(tabelaCliente.Rows.Count == 1)
            {
                tabelaCliente.DataSource = null;
                tabelaCliente.DataSource = dao.listarClientes();
            }
        }
    }
}
