using RaminagrobisBTS.DAL.Depot;

namespace RaminagrobisBTS.DAL.Model
{
    public class Reference_DAL
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Libele { get; set; }
        public string Marque { get; set; }

        public Reference_DAL(string reference, string libele, string marque)
        {
            Ref = reference;
            Libele = libele;
            Marque = marque;
            var depot = new Reference_Depot();
            var preId = depot.GetIdByRef(Ref);
            if(preId == null || preId == 0)
            {
                depot.Insert(this);
            }
            else
            {
                Id = (int)preId;
            }
        }
        public Reference_DAL(int id, string reference, string libele, string marque)
        {
            Id = id;
            Ref = reference;
            Libele = libele;
            Marque = marque;
        }
    }
}
