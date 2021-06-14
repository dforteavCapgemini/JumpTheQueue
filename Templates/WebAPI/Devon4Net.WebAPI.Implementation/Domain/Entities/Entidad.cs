using System;
using System.Collections.Generic;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Domain.Entities
{
    public abstract class Entidad
    {
        int _id;

        public virtual int Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }

    }
}
