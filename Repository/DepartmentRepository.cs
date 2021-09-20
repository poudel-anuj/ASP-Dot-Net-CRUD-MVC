
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Department.Models;

namespace Customer.Repository
{
    public class DepartmentRepository
    {
        DynamicParameters parm = new DynamicParameters();
        readonly DBConnection db = new DBConnection();
        public void Insert(tblDepartment dm)
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@id", dm.id);
                parm.Add("@departName", dm.departName);
                parm.Add("@status", dm.status);
                parm.Add("@entrydate", DateTime.Now);
                parm.Add("@flag", "Insert");
                db.con.Execute("sp_depart", parm, commandType: CommandType.StoredProcedure);
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

        public List<tblDepartment> GetDepartmentList()
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@flag", "list");
                var data = SqlMapper.Query<tblDepartment>(db.con, "sp_depart", parm, commandType: CommandType.StoredProcedure).ToList();
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

        public tblDepartment GetById(int id)
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@id", id);
                parm.Add("@flag", "GetById");
                var data = SqlMapper.Query<tblDepartment>(db.con, "sp_depart", parm, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
                db.con.Execute("sp_depart", parm, commandType: CommandType.StoredProcedure);
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

        public tblDepartment Edit(int id)
        {
            db.Connection();
            try
            {
                db.con.Open();

                parm.Add("@id", id);
                parm.Add("@flag", "GetById");
                var data = SqlMapper.Query<tblDepartment>(db.con, "sp_depart", parm, commandType: CommandType.StoredProcedure).FirstOrDefault();
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


        public void Update(tblDepartment dm)
        {
            db.Connection();
            try
            {
                db.con.Open();
                parm.Add("@id", dm.id);
                parm.Add("@departName", dm.departName);
                parm.Add("@status", dm.status);
                parm.Add("@entrydate", DateTime.Now);
                parm.Add("@flag", "Insert");
                db.con.Execute("sp_depart", parm, commandType: CommandType.StoredProcedure);
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