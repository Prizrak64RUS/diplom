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
        public int idEvent { get; set; }

        public Busy(int id, int idUser, int idPoint, int idEvent)
        {
            this.id = id;
            this.idUser = idUser;
            this.idPoint = idPoint;
            this.idEvent = idEvent;
        }

        public Busy(int idUser, int idPoint, int idEvent)
        {
            this.id = 0;
            this.idUser = idUser;
            this.idPoint = idPoint;
            this.idEvent = idEvent;
        }

        public Busy(int idUser, int idEvent)
        {
            this.id = 0;
            this.idUser = idUser;
            this.idPoint = 0;
            this.idEvent = idEvent;
        }

        public Busy()
        {
        }

    }
}
