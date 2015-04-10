﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Amry.Gst.Web.Models
{
    class GstAzureStorage : IGstDataSource
    {
        static readonly CloudTable Table;

        readonly IGstDataSource _dataSource;

        static GstAzureStorage()
        {
            var account = CloudStorageAccount.DevelopmentStorageAccount;
            var client = account.CreateCloudTableClient();
            Table = client.GetTableReference("gst");
            Table.CreateIfNotExists();
        }

        public GstAzureStorage(IGstDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<IList<IGstLookupResult>> LookupGstData(GstLookupInputType inputType, string input)
        {
            switch (inputType) {
                case GstLookupInputType.GstNumber: {
                    var getOp = TableOperation.Retrieve<CachedGstEntity>(CachedGstEntity.GetPartitionKeyForGstNumber(input), "");
                    var getResult = await Table.ExecuteAsync(getOp);
                    if (getResult.Result != null) {
                        return new[] {(IGstLookupResult) getResult.Result};
                    }
                    var lookupResults = await _dataSource.LookupGstData(inputType, input);
                    if (lookupResults.Count == 0) {
                        return lookupResults;
                    }
                    var cachedResult = CachedGstEntity.Create(lookupResults[0]);
                    var insertOp = TableOperation.Insert(cachedResult, true);
                    var insertResult = await Table.ExecuteAsync(insertOp);
                    return new[] {(IGstLookupResult) insertResult.Result};
                }

                case GstLookupInputType.BusinessRegNumber: {
                    var getOp = TableOperation.Retrieve<CachedGstEntity>(CachedGstEntity.GetPartitionKeyForBusinessRegNumber(input), "");
                    var getResult = await Table.ExecuteAsync(getOp);
                    if (getResult.Result != null) {
                        return new[] {(IGstLookupResult) getResult.Result};
                    }
                    var lookupResults = await _dataSource.LookupGstData(inputType, input);
                    if (lookupResults.Count == 0) {
                        return lookupResults;
                    }
                    {
                        // Insert business reg number partition key
                        var cachedResult = CachedGstEntity.Create(lookupResults[0], input);
                        var insertOp = TableOperation.Insert(cachedResult);
                        Table.ExecuteAsync(insertOp);
                    }
                    {
                        // Insert GST number partition key
                        var cachedResult = CachedGstEntity.Create(lookupResults[0]);
                        var insertOp = TableOperation.Insert(cachedResult, true);
                        var insertResult = await Table.ExecuteAsync(insertOp);
                        return new[] {(IGstLookupResult) insertResult.Result};
                    }
                }

                case GstLookupInputType.BusinessName: {
                    var lookupResults = await _dataSource.LookupGstData(inputType, input);
                    if (lookupResults.Count == 0) {
                        return lookupResults;
                    }
                    foreach (var result in lookupResults) {
                        var cachedResult = CachedGstEntity.Create(result);
                        var insertOp = TableOperation.Insert(cachedResult);
                        Table.ExecuteAsync(insertOp);
                    }
                    return lookupResults;
                }
            }

            // Code should not be able to reach here
            throw new NotSupportedException();
        }
    }
}