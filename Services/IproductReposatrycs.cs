using E_commrec.Models;

namespace E_commrec.Services
{
    public interface IproductReposatrycs
    {

        public List<Prouduct> getAll();

        ////

        public Prouduct getById(int id);


        public int Create(Prouduct pro);

        public int Update(int id, Prouduct prou);


        public int Delete(int id);


    }
}
