using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Resultado
{

    public class Lista<T> : Ficha
    {

        public List<T> MyLista { get; set; }
        public int cntRegistro { get; set; }


        public Lista()
            : base()
        {
            MyLista = null;
            cntRegistro = 0;
        }

    }

}