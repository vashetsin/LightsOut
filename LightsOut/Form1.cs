using BusinessLogic.Lights;
using DependencyInjection;
using Model.Lights;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LightsOut
{
    public partial class Form1 : Form
    {
        // TODO: take it from user input
        private int _dimension = 5;
        private LightsGrid _lightsGrid;
        private bool _processing = false;

        public Form1()
        {
            InitializeComponent();

            _lightsGrid = DI.CallOnScope<ILightsManager, LightsGrid>(m =>
                m.InitLightsGridInSolvableState(_dimension));

            InitLightsGrid();

            UpdateLightsGrid();
        }

        private string MakeCheckboxName(int x, int y)
        {
            return $"{x}-{y}";
        }

        private void InitLightsGrid()
        {
            for (int x = 0; x < _dimension; x++)
            {
                var pnl = new Panel();
                pnl.Location = new System.Drawing.Point(0, x * 20);
                pnl.Size = new System.Drawing.Size(20 * _dimension, 20);
                for (int y = 0; y < _dimension; y++)
                {
                    var chk = new CheckBox();
                    chk.Name = MakeCheckboxName(x, y);
                    chk.Location = new System.Drawing.Point(y * 20, 0);
                    chk.Size = new System.Drawing.Size(20, 20);
                    chk.CheckedChanged += Chk_CheckedChanged;
                    pnl.Controls.Add(chk);
                }
                panel1.Controls.Add(pnl);
            }
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (_processing)
            {
                return;
            }
            _processing = true;
            var chk = (CheckBox)sender;
            var arr = chk.Name.Split('-');
            var x = Convert.ToInt32(arr[0]);
            var y = Convert.ToInt32(arr[1]);

            _lightsGrid = DI.CallOnScope<ILightsManager, LightsGrid>(m =>
                m.Click(_lightsGrid, x, y));
            UpdateLightsGrid();
            _processing = false;
        }

        private void UpdateLightsGrid()
        {
            for (int x = 0; x < _dimension; x++)
            {
                for (int y = 0; y < _dimension; y++)
                {
                    var chk = panel1.Controls.Find(MakeCheckboxName(x, y), true).FirstOrDefault() as CheckBox;
                    chk.Checked = _lightsGrid.Lights[x][y].LightState == LightStateType.On;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
