using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
    class VideoBLL
    {
        public static void Create(tbl_Video a)
        {
            using (dbBibliotecaEntities db = new dbBibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tbl_Video.Add(a);
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

        public static tbl_Video Get(int? id)
        {
            dbBibliotecaEntities db = new dbBibliotecaEntities();
            return db.tbl_Video.Find(id);
        }

        public static void Update(tbl_Video tbl_Video)
        {
            using (dbBibliotecaEntities db = new dbBibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tbl_Video.Attach(tbl_Video);
                        db.Entry(tbl_Video).State = System.Data.Entity.EntityState.Modified;
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
                        tbl_Video tbl_Video = db.tbl_Video.Find(id);
                        db.Entry(tbl_Video).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<tbl_Video> List()
        {
            dbBibliotecaEntities db = new dbBibliotecaEntities();
            return db.tbl_Video.ToList();
        }

        public static List<tbl_Video> ListToNames()
        {
            dbBibliotecaEntities db = new dbBibliotecaEntities();
            List<tbl_Video> result = new List<tbl_Video>();
            db.tbl_Video.ToList().ForEach(x =>
                result.Add(
                    new tbl_Video
                    {
                        titulo = x.titulo,
                        idVideo = x.idVideo
                    }));
            return result;
        }
    }
}
