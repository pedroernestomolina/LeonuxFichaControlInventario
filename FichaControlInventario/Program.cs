using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FichaControlInventario
{

    static class Program
    {

        public static DataProvider.Infra.IProvData MyData; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MyData= new DataProvider.Data.ProvData();
            var r01= MyData.Inicializa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Application.Exit();
            }
            else 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var frm = new Form1();
                if (frm.CargarData()) 
                {
                    Application.Run(frm);
                }
            }
        }

    }

}
