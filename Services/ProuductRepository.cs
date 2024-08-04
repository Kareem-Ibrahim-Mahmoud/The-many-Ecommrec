using E_commrec.Models;

namespace E_commrec.Services
{
    public class ProuductRepository :IproductReposatrycs
    {
        private Context context;
        public ProuductRepository(Context _conte)
        {
            context = _conte;

        }
        

        public List<Prouduct> getAll()
        {
            return context.prouducts.ToList();
            
        }
        ////
        
        public Prouduct getById(int id)
        {
            return context.prouducts.FirstOrDefault(s=>s.Id==id);


        }


        public int Create(Prouduct pro)
        {
            context.prouducts.Add(pro);

           return context.SaveChanges();

        }

        public int Update(int id, Prouduct prou)
        {
            Prouduct prouduct =context.prouducts.FirstOrDefault(s => s.Id == id);
            prouduct.Name = prou.Name;
            prouduct.Price = prou.Price;
           // prouduct.Id = prou.Id;
            prou.Color = prou.Color;

            int raw = context.SaveChanges();
            return raw;


        }


        public int Delete(int id)
        {
            Prouduct prouduct = context.prouducts.FirstOrDefault(s => s.Id == id);
            context.prouducts.Remove(prouduct);

            int raw = context.SaveChanges();
            return raw;

        }

    }
}
