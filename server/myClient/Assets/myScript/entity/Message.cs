

/**
 * Created by prizrak on 20.01.2015.
 */
namespace Assets.myScript.entity
{
    public class Message
    {
        public int id { get; set; }
        public string message { get; set; }
        public int idUser { get; set; }
        public int idUserTo { get; set; }
        public string date { get; set; }
        public int idEvent { get; set; }
        public Message() { }

        public Message(int id, string message, int idUser, int idUserTo, string date, int idEvent)
        {
            this.id = id;
            this.message = message;
            this.idUser = idUser;
            this.idUserTo = idUserTo;
            this.date = date;
            this.idEvent = idEvent;
        }

        public Message(string message, int idUser, int idUserTo, string date, int idEvent)
        {
            this.id = id;
            this.message = message;
            this.idUser = idUser;
            this.idUserTo = idUserTo;
            this.date = date;
            this.idEvent = idEvent;
        }
    }
}