
namespace Assets.myScript.entity
{
    public class News
    {
        public int id { get; set; }
        public int id_event { get; set; }
        public string description { get; set; }
        public string date_write { get; set; } 

        public News() { }
        public News(int id, int id_event, string description, string date_write)
        {
            this.id = id;
            this.id_event = id_event;
            this.description = description;
            this.date_write = date_write;
        }

        public News(int id_event, string description, string date_write)
        {
            this.id = 0;
            this.id_event = id_event;
            this.description = description;
            this.date_write = date_write;
        }
    }
}