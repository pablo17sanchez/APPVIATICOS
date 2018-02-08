﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Departamento
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Objetal> Objetales { get; set; }
    }
}
