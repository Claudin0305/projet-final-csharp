using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.src;

namespace FocusLab_L3_S2.Views.Examens
{
    public partial class ExamensRegister : Form
    {
        src.Examens examen = null;
        public ExamensRegister(src.Examens examen)
        {
            this.examen = examen;
            InitializeComponent();
        }
    }
}
