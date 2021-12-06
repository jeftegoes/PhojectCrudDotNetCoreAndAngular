using Examples.Charge.Application.Common.Messages;

namespace Examples.Charge.Application.Messages.Response
{
    public class PhoneNumberTypeResponse : BaseResponse
    {
        public int BusinessEntityID { get; set; }
        public string Name { get; set; }
    }
}
