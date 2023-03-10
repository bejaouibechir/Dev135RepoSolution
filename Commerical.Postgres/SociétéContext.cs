using Commercial.Model;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace Commerical.Postgres
{
    public partial class CommercialContext
    {
        NpgsqlConnection _connection;
        NpgsqlCommand _command;
        NpgsqlDataReader _reader;
        string _connectionstring;

        string _query;
        List<Société> _sociétés;
        public CommercialContext() {
            _connectionstring = ConfigurationManager
                   .ConnectionStrings["CommercialConnection2"].ConnectionString;
            _connection = new NpgsqlConnection (_connectionstring);
            _sociétés = new List<Société>();
        }

        public void Add(Société société)
        {
            NpgsqlParameter codeparam = new NpgsqlParameter("code", NpgsqlDbType.Integer);
            codeparam.Direction = ParameterDirection.Input;
            codeparam.Value = société.Code;

            NpgsqlParameter raisonparam = new NpgsqlParameter("raison", NpgsqlDbType.Text);
            raisonparam.Direction = ParameterDirection.Input;
            raisonparam.Value = société.Raison;

            NpgsqlParameter nclientsparam = new NpgsqlParameter("nclients", NpgsqlDbType.Integer);
            nclientsparam.Direction = ParameterDirection.Input;
            nclientsparam.Value = société.NombreClients;

            NpgsqlParameter caffaireparam = new NpgsqlParameter("caffaire", NpgsqlDbType.Numeric);
            caffaireparam.Direction = ParameterDirection.Input;
            caffaireparam.Value = société.Chiffre_Affaires;

            NpgsqlParameter detteparam = new NpgsqlParameter("dette", NpgsqlDbType.Numeric);
            detteparam.Direction = ParameterDirection.Input;
            detteparam.Value = société.Dettes;

            NpgsqlParameter imageparam = new NpgsqlParameter("image", NpgsqlDbType.Varchar);
            imageparam.Direction = ParameterDirection.Input;
            imageparam.Value = société.Image;

            NpgsqlParameter obsparam = new NpgsqlParameter("obs", NpgsqlDbType.Varchar);
            obsparam.Direction = ParameterDirection.Input;
            obsparam.Value = société.Observation;

            try
            {
                _query = "sp_addsociété";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddRange(new NpgsqlParameter[]
                { codeparam, raisonparam,nclientsparam });

                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            { _connection.Close(); }

        }
        
        public void Update(Société société)
        {
            NpgsqlParameter codeparam = new NpgsqlParameter("code", NpgsqlDbType.Integer);
            codeparam.Direction = ParameterDirection.Input;
            codeparam.Value = société.Code;

            NpgsqlParameter raisonparam = new NpgsqlParameter("raison", NpgsqlDbType.Text);
            raisonparam.Direction = ParameterDirection.Input;
            raisonparam.Value = société.Raison;

            NpgsqlParameter nclientsparam = new NpgsqlParameter("nclients", NpgsqlDbType.Integer);
            nclientsparam.Direction = ParameterDirection.Input;
            nclientsparam.Value = société.NombreClients;

            NpgsqlParameter caffaireparam = new NpgsqlParameter("caffaire", NpgsqlDbType.Numeric);
            caffaireparam.Direction = ParameterDirection.Input;
            caffaireparam.Value = société.Chiffre_Affaires;

            NpgsqlParameter detteparam = new NpgsqlParameter("dette", NpgsqlDbType.Numeric);
            detteparam.Direction = ParameterDirection.Input;
            detteparam.Value = société.Dettes;

            NpgsqlParameter imageparam = new NpgsqlParameter("image", NpgsqlDbType.Varchar);
            imageparam.Direction = ParameterDirection.Input;
            imageparam.Value = société.Image;

            NpgsqlParameter obsparam = new NpgsqlParameter("obs", NpgsqlDbType.Varchar);
            obsparam.Direction = ParameterDirection.Input;
            obsparam.Value = société.Observation;

            try
            {
                _query = "sp_updatesociété";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddRange(new NpgsqlParameter[]
                { codeparam, raisonparam,nclientsparam });

                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            { _connection.Close(); }
        }

        public void Delete(Société société)
        {
            NpgsqlParameter codeparam = new NpgsqlParameter("code", NpgsqlDbType.Integer);
            codeparam.Direction = ParameterDirection.Input;
            codeparam.Value = société.Code;

            try
            {
                _query = "sp_deletesociété";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Add(codeparam);

                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            { _connection.Close(); }
        }

        public Société GetSociété(int id)
        {
            Société result;
            NpgsqlParameter codeparam = new NpgsqlParameter("code", NpgsqlDbType.Integer);
            codeparam.Direction = ParameterDirection.Input;
            codeparam.Value = id;

            try
            {
                _query = "sp_getsociété";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.Add(codeparam);

                _connection.Open();
                _reader  = _command.ExecuteReader(CommandBehavior.SingleRow);
                _reader.Read();
                result = new Société();

                result.Code = int.Parse(_reader[0].ToString());
                result.Raison = _reader[1].ToString();
                result.NombreClients = (string.IsNullOrEmpty(_reader[2].ToString()) ? 0 : int.Parse(_reader[2].ToString()));
                result.Chiffre_Affaires = (string.IsNullOrEmpty(_reader[3].ToString()) ? 0M : decimal.Parse(_reader[3].ToString()));
                result.Dettes = (string.IsNullOrEmpty(_reader[4].ToString()) ? 0M : decimal.Parse(_reader[4].ToString()));
                result.Image = _reader[5].ToString();
                result.Observation = _reader[6].ToString();

                return result;


            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            { _connection.Close(); }
        }

        public IEnumerable<Société> ListSociété()
        {
            Société current;
            List<Société> result;
    
            try
            {
                _query = "sp_getsociétélist";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure;
              

                _connection.Open();
                _reader = _command.ExecuteReader(CommandBehavior.SingleRow);
                result = new List<Société>();
                while (_reader.Read())
                {
                    current = new Société();
                    current.Code = int.Parse(_reader[0].ToString());
                    current.Raison = _reader[1].ToString();
                    current.NombreClients = (string.IsNullOrEmpty(_reader[2].ToString()) ? 0 : int.Parse(_reader[2].ToString()));
                    current.Chiffre_Affaires = (string.IsNullOrEmpty(_reader[3].ToString()) ? 0M : decimal.Parse(_reader[3].ToString()));
                    current.Dettes = (string.IsNullOrEmpty(_reader[4].ToString()) ? 0M : decimal.Parse(_reader[4].ToString()));
                    current.Image = _reader[5].ToString();
                    current.Observation = _reader[6].ToString();
                    result.Add(current);
                } 
                return result;


            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            { _connection.Close(); }
        }

    }
}
