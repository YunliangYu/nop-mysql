﻿using Club.Core.Data;
using Club.Data.Initializers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;
namespace Club.Data
{
    public class MySqlDataProvider : IDataProvider
    {
        public virtual void InitConnectionFactory()
        {
            var connectionFactory = new MySqlConnectionFactory();
            //TODO fix compilation warning (below)
            #pragma warning disable 0618
            Database.DefaultConnectionFactory = connectionFactory;
        }

        /// <summary>
        /// Initialize database
        /// </summary>
        public virtual void InitDatabase()
        {
            InitConnectionFactory();
            SetDatabaseInitializer();
        }

        /// Set database initializer        /// </summary>
        public virtual void SetDatabaseInitializer()
        {            //pass some table names to ensure that we have nopCommerce 2.X installed
            var tablesToValidate = new[] { "Customer", "Discount", "Order", "Product", "ShoppingCartItem" };            //custom commands (stored proedures, indexes)

            var customCommands = new List<string>();            //use webHelper.MapPath instead of HostingEnvironment.MapPath which is not available in unit tests
            customCommands.AddRange(ParseCommands(HostingEnvironment.MapPath("~/App_Data/MySql.Indexes.sql"), false));            //use webHelper.MapPath instead of HostingEnvironment.MapPath which is not available in unit tests
            customCommands.AddRange(ParseCommands(HostingEnvironment.MapPath("~/App_Data/MySql.StoredProcedures.sql"), false));
            var initializer = new CreateTablesIfNotExist<SiteObjectContext>(tablesToValidate, customCommands.ToArray());
            Database.SetInitializer(initializer);
        }
        protected virtual string[] ParseCommands(string filePath, bool throwExceptionIfNonExists)
        {
            if (!File.Exists(filePath))
            {
                if (throwExceptionIfNonExists) throw new ArgumentException(string.Format("Specified file doesn't exist - {0}", filePath));
                else
                    return new string[0];
            }
            var statements = new List<string>(); using (var stream = File.OpenRead(filePath)) using (var reader = new StreamReader(stream))
            {
                var statement = ""; while ((statement = ReadNextStatementFromStream(reader)) != null)
                {
                    statements.Add(statement);
                }
            }
            return statements.ToArray();
        }
        protected virtual string ReadNextStatementFromStream(StreamReader reader)
        {
            var sb = new StringBuilder();
            string lineOfText;
            while (true)
            {
                lineOfText = reader.ReadLine(); if (lineOfText == null)
                {
                    if (sb.Length > 0) return sb.ToString();
                    else
                        return null;
                }                //MySql doesn't support GO, so just use a commented out GO as the separator
                if (lineOfText.TrimEnd().ToUpper() == "-- GO") break;

                sb.Append(lineOfText + Environment.NewLine);
            }
            return sb.ToString();
        }
        /// <summary>
        /// A value indicating whether this data provider supports stored procedures        /// </summary>
        public virtual bool StoredProceduredSupported
        {
            get { return true; }
        }

        public virtual bool BackupSupported
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a support database parameter object (used by stored procedures)        /// </summary>
        /// <returns>Parameter</returns>
        public virtual DbParameter GetParameter()
        {
            return new MySqlParameter();
        }

        /// <summary>
        /// Maximum length of the data for HASHBYTES functions
        /// returns 0 if HASHBYTES function is not supported
        /// </summary>
        /// <returns>Length of the data for HASHBYTES functions</returns>
        public int SupportedLengthOfBinaryHash()
        {
            return 0; //for SQL Server 2008 and above HASHBYTES function has a limit of 8000 characters.
        }
    }
}