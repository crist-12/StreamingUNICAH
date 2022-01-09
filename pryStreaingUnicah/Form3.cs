using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryStreaingUnicah
{
    public partial class Form3 : Form
    {
        StreamingUnicahEntities1 entityStreaming = new StreamingUnicahEntities1();
        long idEstudios = 0;
        bool editar = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            var tEstudios = from c in entityStreaming.Estudios
                                   select new
                                   {
                                       c.IdEstudios,
                                       c.NombreEstudio,
                                       c.FechaFundacion,
                                       c.FKPais,
                                       c.EstadoEstudio
                                   };
            dgEstudios.DataSource = tEstudios.CopyAnonymusToDataTable();
            dgEstudios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        

        private void dgPaises_SelectionChanged(object sender, EventArgs e)
        {
            if (dgEstudios.RowCount > 0)
            {
                try
                {
                    idEstudios = Convert.ToInt64(dgEstudios.SelectedCells[0].Value);
                    var tEstudios = entityStreaming.Estudios.FirstOrDefault(x => x.IdEstudios == idEstudios);
                    txtNombreEstudio.Text = tEstudios.NombreEstudio;
                    chkEstado.Checked = tEstudios.EstadoEstudio;
                    txtPais.Text = Convert.ToString(tEstudios.FKPais);
                    //Calendario = Convert.ToDateTime(tEstudios.FechaFundacion.Date);
                    editar = true;

                }
                catch (Exception)
                {

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombreEstudio.Text = "";
            chkEstado.Checked = false;
            idEstudios = 0;
            txtPais.Text = "";
            //Calendario.Value = Calendario.;
            editar = false;
        }

        private void txtDescTipoPelicula_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreEstudio.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingresar descripcion");
                return;
            }

            if (editar)
            {
                var tTipoP = entityStreaming.Estudios.FirstOrDefault(x => x.IdEstudios == idEstudios);
                tTipoP.NombreEstudio = txtNombreEstudio.Text;
                tTipoP.FKPais = Convert.ToByte(txtPais.Text);
                tTipoP.EstadoEstudio = chkEstado.Checked;
                tTipoP.FechaFundacion = Calendario.Value;

                entityStreaming.SaveChanges();
            }
            else
            {
                try
                {
                    Estudios tbEstudios = new Estudios();
                    tbEstudios.NombreEstudio = txtNombreEstudio.Text;
                    tbEstudios.EstadoEstudio = chkEstado.Checked;
                    tbEstudios.FechaFundacion = Calendario.Value;
                    tbEstudios.FKPais = Convert.ToByte(txtPais.Text);

                    entityStreaming.Estudios.Add(tbEstudios);
                    entityStreaming.SaveChanges();//se confirma la insercion

                }
                catch (Exception) { }

            }
            txtNombreEstudio.Text = "";
            txtPais.Text = "";
            //Calendario.SelectionStart = Calendario.SelectionStart;
            chkEstado.Checked = false;
            idEstudios = 0;
            editar = false;

            var tEstudios = from p in entityStreaming.Estudios
                            select new
                            {
                                p.IdEstudios,
                                p.EstadoEstudio,
                                p.NombreEstudio,
                                p.FKPais,
                                p.FechaFundacion
                            };
            dgEstudios.DataSource = tEstudios.CopyAnonymusToDataTable();

            MessageBox.Show("Informacion guardada!");


        }

        private void dgEstudios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
