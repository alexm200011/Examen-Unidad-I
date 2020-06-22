using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
    class CategoriaBLL
    {
        public static List<tblCategoria> List()
        {
            dbBibliotecaEntities db = new dbBibliotecaEntities();
            return db.tblCategoria.ToList();
        }
    }
}
