using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Resultado
{

    public class Entidad<T> : Ficha
    {

        public T MyEntidad { get; set; }

        public Entidad()
            : base()
        {
        }

    }

}