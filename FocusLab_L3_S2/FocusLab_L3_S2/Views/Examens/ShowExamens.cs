using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocusLab_L3_S2.Views.Examens
{
    public partial class ShowExamens : Form
    {
        public ShowExamens()
        {
            InitializeComponent();
            foreach (src.Examens examen in Model.ExamensModel.getAll())
            {
                this.dataGridView1.Rows.Add(examen.Id, examen.DateExamen, examen.NomExamen, examen.Resultat, examen.TechnicienLab,
                    examen.SignatureMedecin, examen.Remarque);
            }

            utils.Utils.btnInDataGrid(dataGridView1, "edit");
            utils.Utils.btnInDataGrid(dataGridView1, "delete");
        }
    }
}
