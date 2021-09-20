using Customer.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Customer.Repository
{
    public class CustomerRepository
    {
        DynamicParameters parm = new DynamicParameters();
        readonly DBConnection db = new DBConnection();
        public void Insert(customer cm)
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@id", cm.Id);
                parm.Add("@cusName", cm.cusName);
                parm.Add("@cusEmail", cm.cusEmail);
                parm.Add("@cusAddress", cm.cusAddress);
                parm.Add("@entrydate", DateTime.Now);
                parm.Add("@updateDate", DateTime.Now);
                parm.Add("@depId", cm.depId);
                parm.Add("@flag", "Insert");
                db.con.Execute("sp_custom", parm, commandType: CommandType.StoredProcedure);
                GetCustomerList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public List<customer> GetCustomerList()
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@flag", "list");
                var data = SqlMapper.Query<customer>(db.con, "sp_custom", parm, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public customer GetById(int id)
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@id", id);
                parm.Add("@flag", "GetById");
                var data = SqlMapper.Query<customer>(db.con, "sp_custom", parm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public void Delete(int id)
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@id", id);
                parm.Add("@flag", "Delete");
                db.con.Execute("sp_custom", parm, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public customer Edit(int id)
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@id", id);
                parm.Add("@flag", "GetById");
                var data = SqlMapper.Query<customer>(db.con, "sp_custom", parm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }


        public void Update(customer cm)
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@id", cm.Id);
                parm.Add("@cusName", cm.cusName);
                parm.Add("@cusEmail", cm.cusEmail);
                parm.Add("@cusAddress", cm.cusAddress);
                parm.Add("@depId", cm.depId);
                parm.Add("@updateDate", DateTime.Now);
                parm.Add("@flag", "Update");
                db.con.Execute("sp_custom", parm, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }
    }
}