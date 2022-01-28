using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using S06Eventtrigger.Contracts.Item.ContractDefinition;

namespace S06Eventtrigger.Contracts.Item
{
    public partial class ItemService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ItemDeployment itemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ItemDeployment>().SendRequestAndWaitForReceiptAsync(itemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ItemDeployment itemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ItemDeployment>().SendRequestAsync(itemDeployment);
        }

        public static async Task<ItemService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ItemDeployment itemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, itemDeployment, cancellationTokenSource);
            return new ItemService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ItemService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> IndexQueryAsync(IndexFunction indexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IndexFunction, BigInteger>(indexFunction, blockParameter);
        }

        
        public Task<BigInteger> IndexQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IndexFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> PaidWeiQueryAsync(PaidWeiFunction paidWeiFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PaidWeiFunction, BigInteger>(paidWeiFunction, blockParameter);
        }

        
        public Task<BigInteger> PaidWeiQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PaidWeiFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> PriceInWeiQueryAsync(PriceInWeiFunction priceInWeiFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceInWeiFunction, BigInteger>(priceInWeiFunction, blockParameter);
        }

        
        public Task<BigInteger> PriceInWeiQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceInWeiFunction, BigInteger>(null, blockParameter);
        }
    }
}
