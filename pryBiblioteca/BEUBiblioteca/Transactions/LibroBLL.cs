using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
    class tbl_LibroBLL
    {
        public static void Create(tbl_Libro a)
        {
            using (dbBibliotecaEntities db = new dbBibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tbl_Libro.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static tbl_Libro Get(int? id)
        {
            dbBibliotecaEntities db = new dbBibliotecaEntities();
            return db.tbl_Libro.Find(id);
        }

        public static void Update(tbl_Libro tbl_Libro)
        {
            using (dbBibliotecaEntities db = new dbBibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tbl_Libro.Attach(tbl_Libro);
                        db.Entry(tbl_Libro).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (dbBibliotecaEntities db = new dbBibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tbl_Libro tbl_Libro = db.tbl_Libro.Find(id);
                        db.Entry(tbl_Libro).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<tbl_Libro> List()
        {
            dbBibliotecaEntities db = new dbBibliotecaEntities();
            return db.tbl_Libro.ToList();
        }

        public static List<tbl_Libro> ListToNames()
        {
            dbBibliotecaEntities db = new dbBibliotecaEntities();
            List<tbl_Libro> result = new List<tbl_Libro>();
            db.tbl_Libro.ToList().ForEach(x =>
                result.Add(
                    new tbl_Libro
                    {
                        Titulo = x.Titulo,
                        idLibro = x.idLibro
                    }));
            return result;
        }
    }
}
