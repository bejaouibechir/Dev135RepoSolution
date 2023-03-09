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

        }
        

        public void Update(Société société)
        {
            throw new NotImplementedException();
        }

        public void Delete(Société société)
        {
            throw new NotImplementedException();
        }

        public Société GetSociété(int société)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Société> ListSociété()
        {
            throw new NotImplementedException();
        }

    }
}
