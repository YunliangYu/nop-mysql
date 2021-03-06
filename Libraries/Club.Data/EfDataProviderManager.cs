﻿using System;
using Club.Core;
using Club.Core.Data;

namespace Club.Data
{
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings settings):base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {

            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new SiteException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                case "sqlce":
                    return new SqlCeDataProvider();
                case "mysql":
                    return new MySqlDataProvider();
                default:
                    throw new SiteException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

    }
}
