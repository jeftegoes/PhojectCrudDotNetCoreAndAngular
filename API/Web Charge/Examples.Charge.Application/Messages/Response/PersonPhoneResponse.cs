using Examples.Charge.Application.Common.Messages;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonPhoneResponse : BaseResponse
    {
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
    }
}
