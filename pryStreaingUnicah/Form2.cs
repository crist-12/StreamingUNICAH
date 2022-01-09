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
    public partial class Form2 : Form
    {
        StreamingUnicahEntities1 entityStreaming = new StreamingUnicahEntities1();
        long idClasificaciones = 0;
        bool editar = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var tClasificaciones = from c in entityStreaming.Clasificaciones
                                 select new
                                 {
                                     c.IdClasificaciones,
                                     c.DescripcionClasficacion,
                                     c.EstadoClasificacion
                                 };
            dgClasificaciones.DataSource = tClasificaciones.CopyAnonymusToDataTable();
            dgClasificaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescClasificacion.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingresar descripcion");
                return;
            }

            if (editar)
            {
                var tTipoP = entityStreaming.Clasificaciones.FirstOrDefault(x => x.IdClasificaciones == idClasificaciones);
                tTipoP.DescripcionClasficacion = txtDescClasificacion.Text;
                tTipoP.EstadoClasificacion = chkEstado.Checked;

                entityStreaming.SaveChanges();
            }
            else
            {
                try
                {
                    Clasificaciones tbClasificacion = new Clasificaciones();
                    tbClasificacion.DescripcionClasficacion = txtDescClasificacion.Text;
                    tbClasificacion.EstadoClasificacion = chkEstado.Checked;
                    entityStreaming.Clasificaciones.Add(tbClasificacion);

                    entityStreaming.SaveChanges();//se confirma la insercion

                }
                catch (Exception) { }

            }
            txtDescClasificacion.Text = "";
            chkEstado.Checked = false;
            idClasificaciones = 0;
            editar = false;

            var tClasificacion = from p in entityStreaming.Clasificaciones
                                select new
                                {
                                    p.IdClasificaciones,
                                    p.DescripcionClasficacion,
                                    p.EstadoClasificacion
                                };
            dgClasificaciones.DataSource = tClasificacion.CopyAnonymusToDataTable();

            MessageBox.Show("Informacion guardada!");


        }

        private void dgClasificaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgClasificaciones.RowCount > 0)
            {
                try
                {
                    idClasificaciones = Convert.ToInt64(dgClasificaciones.SelectedCells[0].Value);
                    var tClasificaion = entityStreaming.Clasificaciones.FirstOrDefault(x => x.IdClasificaciones == idClasificaciones);
                    txtDescClasificacion.Text = tClasificaion.DescripcionClasficacion;
                    chkEstado.Checked = tClasificaion.EstadoClasificacion;
                    editar = true;

                }
                catch (Exception)
                {

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDescClasificacion.Text = "";
            chkEstado.Checked = false;
            idClasificaciones = 0;
            editar = false;
        }

        private void txtDescTipoPelicula_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtDescClasificacion.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingresar descripcion");
                return;
            }

            if (editar)
            {
                var tTipoP = entityStreaming.Clasificaciones.FirstOrDefault(x => x.IdClasificaciones == idClasificaciones);
                tTipoP.DescripcionClasficacion = txtDescClasificacion.Text;
                tTipoP.EstadoClasificacion = chkEstado.Checked;

                entityStreaming.SaveChanges();
            }
            else
            {
                try
                {
                    Clasificaciones tbClasificacion = new Clasificaciones();
                    tbClasificacion.DescripcionClasficacion = txtDescClasificacion.Text;
                    tbClasificacion.EstadoClasificacion = chkEstado.Checked;
                    entityStreaming.Clasificaciones.Add(tbClasificacion);

                    entityStreaming.SaveChanges();//se confirma la insercion

                }
                catch (Exception) { }

            }
            txtDescClasificacion.Text = "";
            chkEstado.Checked = false;
            idClasificaciones = 0;
            editar = false;

            var tClasificacion = from p in entityStreaming.Clasificaciones
                                 select new
                                 {
                                     p.IdClasificaciones,
                                     p.DescripcionClasficacion,
                                     p.EstadoClasificacion
                                 };
            dgClasificaciones.DataSource = tClasificacion.CopyAnonymusToDataTable();

            MessageBox.Show("Informacion guardada!");


        }

      
    }
}
