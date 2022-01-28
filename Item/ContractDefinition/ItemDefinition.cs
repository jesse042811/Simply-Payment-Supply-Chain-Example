using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace S06Eventtrigger.Contracts.Item.ContractDefinition
{


    public partial class ItemDeployment : ItemDeploymentBase
    {
        public ItemDeployment() : base(BYTECODE) { }
        public ItemDeployment(string byteCode) : base(byteCode) { }
    }

    public class ItemDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5060405161038638038061038683398101604081905261002f9161005b565b600380546001600160a01b0319166001600160a01b03949094169390931790925560005560025561009e565b60008060006060848603121561007057600080fd5b83516001600160a01b038116811461008757600080fd5b602085015160409095015190969495509392505050565b6102d9806100ad6000396000f3fe6080604052600436106100385760003560e01c80632986c0e5146101ee5780633c8da5881461021657806383d12eef1461022c576101e2565b366101e257600054341461009d5760405162461bcd60e51b815260206004820152602160248201527f576520646f6e277420737570706f7274207061727469616c207061796d656e746044820152607360f81b60648201526084015b60405180910390fd5b600154156100e55760405162461bcd60e51b81526020600482015260156024820152744974656d20697320616c726561647920706169642160581b6044820152606401610094565b34600160008282546100f79190610242565b909155505060035460025460405160248101919091526000916001600160a01b031690349060440160408051601f198184030181529181526020820180516001600160e01b031663800fb83f60e01b179052516101549190610268565b60006040518083038185875af1925050503d8060008114610191576040519150601f19603f3d011682016040523d82523d6000602084013e610196565b606091505b50509050806101df5760405162461bcd60e51b815260206004820152601560248201527444656c697665727920646964206e6f7420776f726b60581b6044820152606401610094565b50005b3480156101df57600080fd5b3480156101fa57600080fd5b5061020460025481565b60405190815260200160405180910390f35b34801561022257600080fd5b5061020460005481565b34801561023857600080fd5b5061020460015481565b6000821982111561026357634e487b7160e01b600052601160045260246000fd5b500190565b6000825160005b81811015610289576020818601810151858301520161026f565b81811115610298576000828501525b50919091019291505056fea26469706673582212206e5c96290bba114815bbfc1215c0039ce43bc6b2f348a4db80054943a987317964736f6c634300080b0033";
        public ItemDeploymentBase() : base(BYTECODE) { }
        public ItemDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_parentContract", 1)]
        public virtual string ParentContract { get; set; }
        [Parameter("uint256", "_priceInWei", 2)]
        public virtual BigInteger PriceInWei { get; set; }
        [Parameter("uint256", "_index", 3)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class IndexFunction : IndexFunctionBase { }

    [Function("index", "uint256")]
    public class IndexFunctionBase : FunctionMessage
    {

    }

    public partial class PaidWeiFunction : PaidWeiFunctionBase { }

    [Function("paidWei", "uint256")]
    public class PaidWeiFunctionBase : FunctionMessage
    {

    }

    public partial class PriceInWeiFunction : PriceInWeiFunctionBase { }

    [Function("priceInWei", "uint256")]
    public class PriceInWeiFunctionBase : FunctionMessage
    {

    }

    public partial class IndexOutputDTO : IndexOutputDTOBase { }

    [FunctionOutput]
    public class IndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PaidWeiOutputDTO : PaidWeiOutputDTOBase { }

    [FunctionOutput]
    public class PaidWeiOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PriceInWeiOutputDTO : PriceInWeiOutputDTOBase { }

    [FunctionOutput]
    public class PriceInWeiOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
