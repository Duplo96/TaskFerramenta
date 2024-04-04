using Task_Ferramenta.Models;

namespace Task_Ferramenta.Repositories
{
    public class ProdottoRepo : IRepo<Prodotto>
    {


        private static ProdottoRepo? _instance;

        public static ProdottoRepo getInstance()
        {
            if (_instance == null)
                _instance = new ProdottoRepo();
            return _instance;
        }

        private ProdottoRepo() { }
        public bool delete(int id)
        {
            bool risultato = false;
            using (TaskFerramentaContext ctx = new TaskFerramentaContext())
            {
                try
                {
                    Prodotto pro = ctx.Prodottos.Single(c => c.ProdottoId == id);
                    ctx.Prodottos.Remove(pro);
                    ctx.SaveChanges();

                    risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }

        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = new List<Prodotto>();

            using (TaskFerramentaContext ctx = new TaskFerramentaContext())
            {
                elenco = ctx.Prodottos.ToList();
            }

            return elenco;
        }

        public Prodotto? GetById(int id)
        {
            Prodotto? pro = null;

            using (TaskFerramentaContext ctx = new TaskFerramentaContext())
                pro = ctx.Prodottos.FirstOrDefault(l => l.ProdottoId == id);

            return pro;
        }

        public bool insert(Prodotto t)
        {
            bool risultato = false;
            using (TaskFerramentaContext ctx = new TaskFerramentaContext())
            {
                try
                {
                    ctx.Prodottos.Add(t);
                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }

        public bool update(Prodotto t)
        {
            bool risultato = false;

            using (TaskFerramentaContext ctx = new TaskFerramentaContext())
            {
                try
                {
                    Prodotto temp = ctx.Prodottos.Single(l => l.Codice == t.Codice);

                    t.ProdottoId = temp.ProdottoId;
                    t.Codice = temp.Codice;
                    t.Nome = t.Nome is not null ? t.Nome : temp.Nome;
                    t.Descrizione = t.Descrizione is not null ? t.Descrizione : temp.Descrizione;
                    t.Prezzo = t.Prezzo == 0 ? temp.Prezzo : t.Prezzo;
                    t.Quantita = temp.Quantita;
                    t.Categoria = t.Categoria is not null ? t.Categoria : temp.Categoria;

                    ctx.Entry(temp).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }

        public bool updateQnt(Prodotto t)
        {
            bool risultato = false;

            using (TaskFerramentaContext ctx = new TaskFerramentaContext())
            {
                try
                {
                    Prodotto temp = ctx.Prodottos.Single(l => l.Codice == t.Codice);

                    t.ProdottoId = temp.ProdottoId;
                    t.Nome = temp.Nome;
                    t.Codice =  temp.Codice;
                    t.Descrizione =  temp.Descrizione;
                    t.Prezzo = temp.Prezzo;

                    ctx.Entry(temp).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }

        public Prodotto? GetByCodice(string codice)
        {
            Prodotto? prod = null;

            using (TaskFerramentaContext ctx = new TaskFerramentaContext())
                prod = ctx.Prodottos.FirstOrDefault(l => l.Codice == codice);

            return prod;
        }
    }
}
