using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    public class Busy
    {

        public int id { get; set; }
        public int idUser { get; set; }
        public int idPoint { get; set; }
        public int idGroup { get; set; }

        public Busy(int id, int idUser, int idPoint, int idGroup)
        {
            this.id = id;
            this.idUser = idUser;
            this.idPoint = idPoint;
            this.idGroup = idGroup;
        }

        public Busy(int idUser, int idPoint, int idGroup)
        {
            this.id = 0;
            this.idUser = idUser;
            this.idPoint = idPoint;
            this.idGroup = idGroup;
        }

        public Busy(int idUser, int idGroup)
        {
            this.id = 0;
            this.idUser = idUser;
            this.idPoint = 0;
            this.idGroup = idGroup;
        }

        public Busy()
        {
        }

    }
}
