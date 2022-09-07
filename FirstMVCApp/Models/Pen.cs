namespace FirstMVCApp.Models
{
    public class Pen
    {
        public int PenId { get; set; }
        public string PenName { get; set; } 
        public float Price { get; set; }

        public Pen() { }
        public Pen(int penId, string penName, float price)
        {
            PenId = penId;
            PenName = penName;
            Price = price;
        }

        public static List<Pen> pens = new List<Pen>();

        public static List<Pen> getAllPens()
        {
            pens.Add(new Pen(1, "Parker", 800));
            pens.Add(new Pen(2, "Reynolds", 900));
            return pens;
        }
    }
}
