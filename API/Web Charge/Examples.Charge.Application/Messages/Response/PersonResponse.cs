using Examples.Charge.Application.Common.Messages;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonResponse : BaseResponse
    {
        public int BusinessEntityID { get; set; }
        public string Name { get; set; }
    }
}
