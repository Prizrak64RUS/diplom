using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    class Log_type
    {
        public String description { get; set; }
        public int id { get; set; }

        public Log_type(String description, int id)
        {
            this.description = description;
            this.id = id;
        }
    }
}
